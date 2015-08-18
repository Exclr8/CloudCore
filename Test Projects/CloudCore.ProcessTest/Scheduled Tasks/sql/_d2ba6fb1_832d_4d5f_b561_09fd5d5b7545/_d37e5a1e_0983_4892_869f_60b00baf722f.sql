create procedure [cloudcore].[CCScheduledTask_d37e5a1e_0983_4892_869f_60b00baf722f]
as
begin
    declare @SecondsToRun int = 4,
            @EndDateTime datetime

    select @EndDateTime = dateadd(second, @SecondsToRun, getdate())
    while getdate() < @EndDateTime
    begin
        print 'Simulating time passing for test scheduled task...'
    end
end
go
