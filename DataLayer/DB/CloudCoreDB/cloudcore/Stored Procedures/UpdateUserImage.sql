CREATE PROCEDURE [cloudcore].[UpdateUserImage] 
	@mainImage Image,
	@thumbImage Image,
	@UserId int
AS
BEGIN

	update [cloudcore].[User]
	set MainImage = @mainImage, ThumbImage = @thumbImage
	where UserId = @UserId

END