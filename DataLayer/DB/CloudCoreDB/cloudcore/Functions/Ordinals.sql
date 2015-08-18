CREATE FUNCTION [cloudcore].[Ordinals]
(
      @Number INT
)
RETURNS varchar(10)
AS
BEGIN
     
      DECLARE @Outcome VARCHAR(10)
 
      SET @Outcome = (SELECT CASE WHEN ((@Number % 100) > 10) AND ((@Number % 100) < 14)  THEN CAST(@Number AS varchar(5)) + 'th' END)
     
      IF @Outcome IS NULL
      BEGIN
            SET @Outcome = (SELECT CASE WHEN (@Number % 10) = 1 THEN CAST(@Number AS varchar(5)) + 'st'
                                    WHEN (@Number % 10) = 2 THEN CAST(@Number AS varchar(5)) + 'nd'
                                    WHEN (@Number % 10) = 3 THEN CAST(@Number AS varchar(5)) + 'rd' 
                                    ELSE CAST(@Number AS varchar(5)) + 'th' END)
      END
      RETURN @Outcome
 
END
 
 
GO