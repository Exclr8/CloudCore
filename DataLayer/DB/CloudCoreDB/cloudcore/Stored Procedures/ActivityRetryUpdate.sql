
CREATE PROCEDURE [cloudcore].[ActivityRetryUpdate]

 @ActivityId int,
 @MaxRetries int,
 @RetryDelayInSeconds int

AS
BEGIN

	Update AM
	set 
		MaxRetries = @MaxRetries,
		RetryDelayInSeconds = @RetryDelayInSeconds
	from cloudcoremodel.ActivityModel as AM
	inner join cloudcore.Activity as A
		on A.ActivityModelId = AM.ActivityModelId
	where
		A.ActivityId = @ActivityId

END