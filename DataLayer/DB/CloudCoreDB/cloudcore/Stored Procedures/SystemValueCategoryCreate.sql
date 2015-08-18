CREATE PROCEDURE [cloudcore].[SystemValueCategoryCreate]
	@CategoryName varchar(100),
	@CategoryId int out
AS
BEGIN
	if not exists (Select null from [cloudcore].SystemValueCategory where CategoryName = @CategoryName)
	BEGIN
		Insert into [cloudcore].SystemValueCategory(CategoryName) values(@CategoryName)
		set @CategoryId = SCOPE_IDENTITY()
	END
    ELSE
	BEGIN
        set @CategoryId = null
		raiserror(N'The specified System Value Category already exists, please enter a unique name.',18, 1) 
		return
	END
END