CREATE TABLE [cloudcore].[Period] (
    [PeriodSeq]   INT      IDENTITY (1, 1) NOT NULL,
    [StartDate]   DATETIME NOT NULL,
    [EndDate]     DATETIME NOT NULL,
    [PeriodMonth] INT      NOT NULL,
    [PeriodYear]  INT      NOT NULL,
    [PeriodTitle] AS       ((CONVERT([nvarchar](30),[StartDate],(106))+' - ')+CONVERT([nvarchar](30),[EndDate],(106))),
    CONSTRAINT [PK_Period] PRIMARY KEY CLUSTERED ([PeriodSeq] ASC),
    CONSTRAINT [UNQ_Period_Period] UNIQUE NONCLUSTERED ([PeriodMonth] ASC, [PeriodYear] ASC)
);

