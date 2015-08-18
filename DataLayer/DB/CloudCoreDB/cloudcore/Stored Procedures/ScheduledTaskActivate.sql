CREATE PROCEDURE [cloudcore].[ScheduledTaskToggleActiveStatus]
    @ScheduledTaskId int
as
  begin
    update  cloudcore.ScheduledTask
       set  StatusId = case when Active = 0 then 
                                case when StatusId = 101 then 0 else StatusId end
                            else 
                                100
                       end,
            Active = case when Active = 1 then 0 else 1 end
     where  ScheduledTaskId = @ScheduledTaskId
  end