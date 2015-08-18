CREATE TABLE [cloudcore].[SystemTally] (
    [TallyId]   INT IDENTITY (1, 1) NOT NULL,
    [ZeroBased] INT NOT NULL,
    CONSTRAINT [PK_SystemTally] PRIMARY KEY CLUSTERED ([TallyId] ASC)
);


GO
CREATE TRIGGER [cloudcore].[CCSystemTallyDelete] 
ON [cloudcore].[SystemTally]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	raiserror('[CloudCore]: You can not delete from this system table.', 16, 1)
END