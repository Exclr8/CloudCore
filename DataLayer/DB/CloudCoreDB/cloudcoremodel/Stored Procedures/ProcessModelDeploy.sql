create procedure [cloudcoremodel].[ProcessModelDeploy] --[cloudcoremodel].[ProcessModelDeploy] '11071973-0002-0000-0000-3ABF9E872D90', 0
	@processGuid as uniqueidentifier,
	@SystemModuleId as int
as
begin
	declare @newVersion as int

	set @newVersion = isnull((select MAX(pr.ProcessRevision) 
						 from [cloudcoremodel].ProcessRevision pr
						inner join [cloudcoremodel].ProcessModel pm
						   on pr.ProcessModelId = pm.ProcessModelId 
						where pm.ProcessGuid = @processGuid),0)
	
	if (exists(select null
				 from [cloudcoremodel].ProcessModel pr
				inner join [cloudcoremodel].ProcessRevision rev
				   on pr.ProcessModelId = rev.ProcessModelId
				inner join [cloudcore].Activity a
				   on rev.ProcessRevisionId = a.ProcessRevisionId
				where a.ProcessGuid = @processGuid
				  and rev.ProcessRevision = @newVersion))
	begin
		raiserror('Process has already been deployed', 16, 1) 
		return
	end

	--Activity
	--Update
	update act
	   set act.ActivityModelId = newam.ActivityModelId,
		   act.ProcessRevisionId = newam.ProcessRevisionId,
		   act.OnlyVisibleAtLocation = newam.OnlyVisibleAtLocation,
		   act.LocationRadius = newam.LocationRadius
	  from [cloudcore].Activity act
	 inner join [cloudcoremodel].ActivityModel am
		on act.ActivityModelId = am.ActivityModelId 
	 inner join [cloudcoremodel].ActivityModel newam
		on am.ActivityGuid = newam.ActivityGuid 
	 inner join [cloudcoremodel].ProcessRevision pr
		on newam.ProcessRevisionId = pr.ProcessRevisionId 
	 inner join [cloudcoremodel].ProcessModel pm
		on pr.ProcessModelId = pm.ProcessModelId 
	 where pm.ProcessGuid = @processGuid
	   and pr.ProcessRevision = @newVersion 
	   and (act.ActivityModelId <> newam.ActivityModelId
			or act.ProcessRevisionId <> newam.ProcessRevisionId
			or am.ActivityName <> newam.ActivityName
			or am.ActivityTypeId <> newam.ActivityTypeId
			or am.Startable <> newam.Startable
			or am.OnlyVisibleAtLocation <> newam.OnlyVisibleAtLocation
			or am.LocationRadius <> newam.LocationRadius)
			
	update am
	   set am.ActivityName = newam.ActivityName,
		   am.ActivityTypeId = newam.ActivityTypeId,
		   am.Startable = newam.Startable,
		   am.OnlyVisibleAtLocation = newam.OnlyVisibleAtLocation,
		   am.LocationRadius = newam.LocationRadius
	  from [cloudcore].Activity act
	 inner join [cloudcoremodel].ActivityModel am
		on act.ActivityModelId = am.ActivityModelId 
	 inner join [cloudcoremodel].ActivityModel newam
		on am.ActivityGuid = newam.ActivityGuid 
	 inner join [cloudcoremodel].ProcessRevision pr
		on newam.ProcessRevisionId = pr.ProcessRevisionId 
	 inner join [cloudcoremodel].ProcessModel pm
		on pr.ProcessModelId = pm.ProcessModelId 
	 where pm.ProcessGuid = @processGuid
	   and pr.ProcessRevision = @newVersion 
	   and (act.ActivityModelId <> newam.ActivityModelId
			or act.ProcessRevisionId <> newam.ProcessRevisionId
			or am.ActivityName <> newam.ActivityName
			or am.ActivityTypeId <> newam.ActivityTypeId
			or am.Startable <> newam.Startable
			or am.OnlyVisibleAtLocation <> newam.OnlyVisibleAtLocation
			or am.LocationRadius <> newam.LocationRadius)
			
	declare @AssemblyName varchar(400)
	
    select @AssemblyName = AssemblyName
    from cloudcore.SystemModule
	where SystemModuleId = @SystemModuleId
		
	--Insert Activities that doesnt exist
	insert into [cloudcore].Activity(ActivityModelId, ProcessRevisionId, SystemModuleId, ActivityGuid,SubProcessGuid, ProcessGuid, ActivityTypeId, OnlyVisibleAtLocation, LocationRadius)				 
	select distinct am.ActivityModelId, pm.ProcessRevisionId, 
	       @SystemModuleId,
		   am.ActivityGuid, SP.SubProcessGuid, @processGuid, am.ActivityTypeId, am.OnlyVisibleAtLocation, am.LocationRadius
	  from [cloudcoremodel].vwProcessModel pm
	 inner join [cloudcoremodel].ActivityModel am
	    on pm.ActivityModelId = am.ActivityModelId
	 inner join [cloudcoremodel].SubProcess SP
	    on SP.SubProcessId = am.SubProcessId
	 where pm.ProcessGuid = @processGuid
	   and pm.ProcessRevisionId = (select MAX(ProcessRevisionId) 
							      from [cloudcoremodel].vwProcessModel pm2
							     where pm2.ProcessGuid = pm.ProcessGuid)
	   and not exists(select null 
					    from [cloudcoremodel].vwProcessModel pm1
					   inner join [cloudcore].Activity a
					      on pm1.ActivityModelId = a.ActivityModelId
					   where a.ActivityModelId = pm.ActivityModelId) 

	--update worklist with replacement activities
	update wl 
	   set wl.ActivityId = repact.ActivityId 
	  from [cloudcore].Worklist wl
	 inner join [cloudcore].Activity act
		on wl.ActivityId = act.ActivityId 
	 inner join [cloudcoremodel].ActivityModel am
		on act.ActivityModelId = am.ActivityModelId 
	 inner join [cloudcoremodel].ActivityModel amnew
	   on amnew.ActivityModelId = am.ReplacementId
	 inner join [cloudcore].Activity repact
		on amnew.ActivityModelId = repact.ActivityModelId
	 inner join [cloudcoremodel].ProcessRevision pr
		on am.ProcessRevisionId = pr.ProcessRevisionId 
	 inner join [cloudcoremodel].ProcessModel pm
		on pr.ProcessModelId = pm.ProcessModelId
	 where pm.ProcessGuid = @processGuid
	   and pr.ProcessRevision <= @newVersion-1 
	   and amnew.ActivityGuid <> am.ActivityGuid 

	declare @Placeholder varchar(max)
		
	--delete unused event sp's and rule functions
	declare @Activity varchar(max)
	declare @Ind tinyint

	
	declare ActivityCur cursor
	for
	select case am.ActivityTypeId
		   when 2 then 'CCEvent_'
		   else 'CCRule_'
		   end
		   + REPLACE(am.ActivityGuid, '-', '_'), am.ActivityTypeId
	  from [cloudcore].Activity act
	 inner join [cloudcoremodel].ActivityModel am
		on act.ActivityModelId = am.ActivityModelId 
	 inner join [cloudcoremodel].ProcessRevision pr
		on am.ProcessRevisionId = pr.ProcessRevisionId 
	 inner join [cloudcoremodel].ProcessModel pm
		on pr.ProcessModelId = pm.ProcessModelId 
	 where pm.ProcessGuid = @processGuid 
	   and pr.ProcessRevision = @newVersion-1
	   and (am.ActivityTypeId = 2 OR am.ActivityTypeId = 4)
	 
	open ActivityCur

	fetch from ActivityCur
	into @Activity, @Ind
	
	while @@FETCH_STATUS = 0
	begin
		if (@Ind = 2)
		begin
			if exists(select null
						from sys.sysobjects
					   where type = 'P'
						 and name = @Activity)
			begin

				set @Placeholder = 'drop procedure [cloudcore].' + @Activity
				exec(@Placeholder)
			end
		end
		else
		begin
			if exists(select null
						from sys.sysobjects 
					   where type = 'FN'
						 and name = @Activity)
			begin
				set @Placeholder = 'drop function ' + @Activity
				exec(@Placeholder)
			end
		end
		
		fetch next from ActivityCur
		into @Activity, @Ind
	end

	close ActivityCur
	deallocate ActivityCur
	
	--delete old activities
	delete act
	  from [cloudcore].Activity act
	 inner join [cloudcoremodel].ActivityModel am
		on act.ActivityModelId = am.ActivityModelId 
	 inner join [cloudcoremodel].ProcessRevision pr
		on am.ProcessRevisionId = pr.ProcessRevisionId 
	 inner join [cloudcoremodel].ProcessModel pm
		on pr.ProcessModelId = pm.ProcessModelId 
	 where pm.ProcessGuid = @processGuid 
	   and pr.ProcessRevision <= @newVersion-1
   
end
