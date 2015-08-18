CREATE PROCEDURE [cloudcore].[UserClearReferenceGuid]
    @UserId int
AS
BEGIN
    UPDATE  cloudcore.[User]
    SET     ReferenceGuid = NULL
    WHERE   UserId = @UserId
END
