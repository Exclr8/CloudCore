CREATE PROCEDURE [cloudcore].[FavouriteAdd]
	@UserId int,
	@FavouriteGuid uniqueidentifier, 
	@FavouriteTypeId smallint
AS

	declare @favouriteCount smallint = 0

  if @FavouriteTypeId = 0
	begin	
		select @favouriteCount = count(UserId)
		from [cloudcore].Favourite
		where UserId = @UserId
		and FavouriteTypeId = @FavouriteTypeId

		if(@favouriteCount >= 7)
			begin
				RAISERROR ('You are only allowed 7 menu item favourites.  Please delete one to add another.', 16, 1)
				return
			end
	end


  insert into [cloudcore].Favourite (UserId, FavouriteGuid, FavouriteTypeId)
      values (@UserId, @FavouriteGuid, @FavouriteTypeId)
