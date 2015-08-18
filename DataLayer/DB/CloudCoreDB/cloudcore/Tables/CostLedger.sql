CREATE TABLE [cloudcore].[CostLedger] (
    [LedgerID]        BIGINT   IDENTITY (1, 1) NOT NULL,
    [InstanceId]      BIGINT   NOT NULL,
    [ActivityModelId] INT      NOT NULL,
    [Cost]            MONEY    NOT NULL,
    [TransDate]       DATETIME CONSTRAINT [DF_CostLedger_TransDate] DEFAULT (getdate()) NOT NULL,
    [PeriodSeq]       INT      CONSTRAINT [DF_CostLedger_PeriodSeq] DEFAULT ([cloudcore].[Period_Today]()) NOT NULL,
    [Exported]        BIT      CONSTRAINT [DF_CostLedger_Exported] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CostLedger] PRIMARY KEY CLUSTERED ([LedgerID] ASC),
    CONSTRAINT [FK_CostLedger_ActivityModel] FOREIGN KEY ([ActivityModelId]) REFERENCES [cloudcoremodel].[ActivityModel] ([ActivityModelId]),
    CONSTRAINT [FK_CostLedger_Period] FOREIGN KEY ([PeriodSeq]) REFERENCES [cloudcore].[Period] ([PeriodSeq])
);


GO
CREATE TRIGGER [cloudcore].[CostLedgerInsert] on [cloudcore].[CostLedger]

   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @PeriodSeq int
	set @PeriodSeq = isnull((select top 1 PeriodSeq from [cloudcore].Period where GETDATE() between StartDate and EndDate),0)
	
	if @PeriodSeq > 0
	begin
		update c
		   set PeriodSeq = @PeriodSeq
		  from [cloudcore].CostLedger c
		 inner join Inserted i on c.LedgerID = i.LedgerID
	end
END