CREATE FUNCTION [cloudcore].[PROPER]
(@STRING VARCHAR (255))
RETURNS VARCHAR (255)
AS
begin
  declare @LENGTH int
  declare @POSITION int

  if @STRING is NULL or @STRING = '' return @STRING;

  if len(@STRING) = 1 return upper(@STRING);

  set @POSITION = 0;

  select @STRING = ltrim(@STRING) ;
  select  @LENGTH = len(@STRING);


  select @STRING = upper(substring(@STRING, 1, 1)) + 
                   lower(substring(@STRING, 2, @LENGTH -1));

  while @LENGTH > 0
  begin
    set @POSITION = charindex(' ', @STRING, @POSITION + 1);

    if @POSITION = 0 return @STRING;

    select @STRING = substring(@STRING, 1, @POSITION) + 
                     upper(substring(@STRING, @POSITION + 1, 1)) + 
                     substring(@STRING, @POSITION + 2, @LENGTH - @POSITION -1);
  end

  return @STRING
end