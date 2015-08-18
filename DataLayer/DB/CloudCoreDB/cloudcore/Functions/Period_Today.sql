CREATE function [cloudcore].[Period_Today]()

RETURNS int
AS
BEGIN
  RETURN (Select PeriodSeq 
            from [cloudcore].Period 
           where GetDate() between StartDate and EndDate)
END