CREATE PROCEDURE [cloudcore].[RestartFailedWorklistItemByActivity]
	@ActivityId int	
AS
begin
	update w
	   set StatusTypeId = 0
	  from cloudcore.Worklist w
	 inner join cloudcoremodel.StatusType st on w.StatusTypeId = st.StatusTypeId
	 where st.StatusTypeName = 'Failed'
	 and w.ActivityId = @ActivityId

	 select w.InstanceId
	   from cloudcore.Worklist w
	  where ActivityId = @ActivityId
	    and StatusTypeId = 0
end