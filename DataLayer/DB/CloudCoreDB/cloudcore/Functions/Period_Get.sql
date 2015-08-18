CREATE function [cloudcore].[Period_Get](@DATE datetime)
RETURNS int
AS
BEGIN
  Declare @SEQ int

  Select @SEQ = PeriodSeq 
    from [cloudcore].Period
   where StartDate <= @DATE
     and EndDate >= @DATE
     
  RETURN(@SEQ)
END