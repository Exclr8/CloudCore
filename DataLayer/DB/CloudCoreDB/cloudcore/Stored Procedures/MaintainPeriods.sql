-- =============================================
-- Author:		Mark Diamond
-- Create date: 5/5/2010
-- Description:	See Ticket #104
--				Will ensure that periods exist 
--				for 10 years in to the future
-- =============================================
CREATE PROCEDURE [cloudcore].[MaintainPeriods] 

AS
BEGIN

	SET NOCOUNT ON;

	IF EXISTS (SELECT TOP(1)NULL FROM [cloudcore].Period)
	BEGIN
		DECLARE @StartDate datetime
			SELECT @StartDate = DATEADD(dd,1,MAX(EndDate)) FROM [cloudcore].Period
		DECLARE @EndDate datetime
			SELECT @EndDate = DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@StartDate)+1,0))
		DECLARE @PeriodMonth tinyint
			SELECT @PeriodMonth = DATEPART(MONTH, @StartDate)
		DECLARE @PeriodYear int
			SELECT @PeriodYear = DATEPART(YEAR, @StartDate)

		WHILE (DATEDIFF(MONTH, GETDATE(), (SELECT MAX(EndDate) FROM [cloudcore].Period)) < 120) /* 120 Double check this value!!!*/
		BEGIN
			INSERT INTO [cloudcore].Period (StartDate, EndDate, PeriodMonth, PeriodYear) 
				VALUES (@StartDate, @EndDate, @PeriodMonth, @PeriodYear)
			
			SET @StartDate = DATEADD(MONTH,1,@StartDate)
			SELECT @EndDate = DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@StartDate)+1,0))
			SELECT @PeriodMonth = DATEPART(MONTH, @StartDate)
			SELECT @PeriodYear = DATEPART(YEAR, @StartDate)
		END
	END
	ELSE
	BEGIN
		
		INSERT INTO [cloudcore].Period (StartDate, EndDate, PeriodMonth, PeriodYear) 
				VALUES (@StartDate, @EndDate, @PeriodMonth, @PeriodYear)	
	END

END