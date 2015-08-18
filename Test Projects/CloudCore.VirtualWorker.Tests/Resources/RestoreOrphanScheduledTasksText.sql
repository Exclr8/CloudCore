declare @OldDate datetime = getdate() - 365

update [cloudcore].[ScheduledTask] 
set [Started] = @OldDate,
    [StatusId] = 1, 
    [Active] = 1,
    [InitDate] = @OldDate, 
    [NextRunDate] = @OldDate,
    KeepAliveDate = @OldDate