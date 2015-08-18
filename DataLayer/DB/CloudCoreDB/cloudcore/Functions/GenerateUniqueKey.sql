CREATE FUNCTION [cloudcore].[GenerateUniqueKey]
(
  @Prefix varchar(3),
  @Seed BIGINT,
  @Length int
)
RETURNS VARCHAR(20)
AS
BEGIN
    declare @LOFSTR integer
    declare @I integer
    declare @NOASSTRING varchar(16)
    declare @DIGSTRING varchar(16)
    declare @ASTR varchar(16)
    declare @BSTR varchar(2)
    declare @AINT integer
    declare @BINT integer
    declare @CHKNUMBER integer
    declare @UNIQUEKEY varchar(20)
  -- Get Check Digit
  set @NOASSTRING = cast(@Seed as varchar(16))
  set @DIGSTRING = ''
  set @LOFSTR = len(@NOASSTRING)
  set @ASTR = ''
  set @AINT = 0
  while len(@DIGSTRING) < @LOFSTR
    begin
      set @I = ((len(@DIGSTRING) + 1) % 3)
      if (@I = 1) 
        set @BINT = 7
      if (@I = 2) 
        set @BINT = 3
      if (@I = 0) 
        set @BINT = 1

      set @DIGSTRING = @DIGSTRING + cast(@BINT as char(1))
      set @AINT = @LOFSTR - len(@DIGSTRING) + 1
      set @AINT = cast(substring(@NOASSTRING, @AINT, 1) as integer)
      set @AINT = @AINT * @BINT
      set @BSTR = cast(@AINT as varchar(2))
      set @ASTR = substring(@BSTR, len(@BSTR), 1) + @ASTR
    end

  set @AINT = len(@ASTR)
  set @I = 1
  set @BINT = 0

  while (@I < @AINT + 1)
    begin
      set @BINT = @BINT + cast(substring(@ASTR, @I, 1) as integer)
      set @I = @I + 1
    end

  set @ASTR = cast(@BINT as varchar(16))
  set @AINT = cast(substring(@ASTR, len(@ASTR), 1) as integer)

  if (@AINT = 0) 
    set @CHKNUMBER = 0 
  else 
    Set @CHKNUMBER = 10 - @AINT

  -- Create Key using Unique No, Check Digit and Shop ID
  set @UNIQUEKEY = cast(@Seed as varchar(15)) + cast(@CHKNUMBER as char(1))
  while (len(@UNIQUEKEY) < @Length - 4) 
    set @UNIQUEKEY = '0' + @UNIQUEKEY
  
  return @Prefix + '-' + @UNIQUEKEY
END
GO

