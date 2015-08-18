/* For SQL Azure backward compatibility */
CREATE FUNCTION [cloudcore].[fn_varbintohexstr]
(
	@pbinin varbinary(max)
)
RETURNS nvarchar(max)
AS
BEGIN
	declare @value nvarchar(max)

	select @value = lower(convert(nvarchar(max), @pbinin, 1))
	RETURN @value
END
