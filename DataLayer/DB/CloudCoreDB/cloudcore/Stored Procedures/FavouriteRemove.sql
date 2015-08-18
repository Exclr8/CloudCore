CREATE PROCEDURE [cloudcore].[FavouriteRemove]
	@UserId int, 
	@FavouriteGuid uniqueidentifier, 
	@FavouriteTypeId int
AS
  delete from [cloudcore].Favourite 
         where UserId = @UserId 
		   and FavouriteGuid = @FavouriteGuid
		   and FavouriteTypeId = @FavouriteTypeId