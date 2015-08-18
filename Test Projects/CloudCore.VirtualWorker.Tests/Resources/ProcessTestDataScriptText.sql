declare @NumberOfInstancesDesired bigint = 400
declare @ActivityGuidToStartWith uniqueidentifier = '31BA9BF0-6BDB-4850-9A92-F9B82AE1B008'

/*************** No need to modify beyond this line, unless fixing a bug ****************/

declare @KeyValue bigint = 1, @UserId int = 0, @InstanceId bigint

while @KeyValue <= @NumberOfInstancesDesired
begin
	exec cloudcore.ActivityStart @ActivityGuidToStartWith, @KeyValue, @UserId, @InstanceId out
	set @KeyValue = @KeyValue + 1
end
go