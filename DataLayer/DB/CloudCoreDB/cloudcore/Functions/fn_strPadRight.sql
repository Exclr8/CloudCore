CREATE FUNCTION [cloudcore].[fn_strPadRight]
(
    @OrigString VARCHAR(MAX) = NULL,
    @PadLength INT = 0,
    @PadChar CHAR(1) = ' '
)
RETURNS VARCHAR(MAX)
AS
BEGIN
    DECLARE @Result VARCHAR(MAX); 
    DECLARE @OrigLength INT;
 
    SET @OrigLength = LEN(@OrigString);
     
    IF (@OrigLength >= @PadLength)
    BEGIN
        SET @Result = @OrigString
    END
    ELSE
    BEGIN
        SET @Result = @OrigString + REPLICATE(@PadChar, @PadLength - @OrigLength);
    END
 
    RETURN @Result
END
