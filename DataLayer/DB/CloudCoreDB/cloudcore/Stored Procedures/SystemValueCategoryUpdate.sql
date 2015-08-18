CREATE PROCEDURE [cloudcore].[SystemValueCategoryUpdate]
	@SystemValueCategoryId int,
	@SystemValueCategoryName varchar(50)
AS
	update cloudcore.SystemValueCategory
	   set CategoryName = @SystemValueCategoryName
	 where CategoryId = @SystemValueCategoryId


