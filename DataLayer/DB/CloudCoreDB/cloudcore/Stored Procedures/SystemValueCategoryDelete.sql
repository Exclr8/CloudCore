CREATE PROCEDURE [cloudcore].[SystemValueCategoryDelete]
	@SystemValueCategoryId int
AS
	delete
	  from cloudcore.SystemValueCategory
	 where CategoryId = @SystemValueCategoryId


