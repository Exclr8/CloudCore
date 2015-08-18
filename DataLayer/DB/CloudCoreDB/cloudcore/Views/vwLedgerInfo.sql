create view [cloudcore].[vwLedgerInfo]
as
	select  [LedgerID],
            [InstanceId],
            [ActivityModelId],
            [Cost],
            [TransDate],
            [PeriodSeq],
            [Exported]
    from    [cloudcore].CostLedger
