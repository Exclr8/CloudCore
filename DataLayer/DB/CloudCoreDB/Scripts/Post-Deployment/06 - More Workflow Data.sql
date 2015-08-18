declare @NumberOfInstancesDesired bigint = 100000
declare @ActivityGuidToStartWith uniqueidentifier = '31BA9BF0-6BDB-4850-9A92-F9B82AE1B008'

declare @KeyValue bigint, @UserId int = 0, @InstanceId bigint,
		@TargetKey bigint

set @KeyValue = isnull((select max(KeyValue) from cloudcore.Worklist), 0) + 1
set @TargetKey = @KeyValue + @NumberOfInstancesDesired - 1

while @KeyValue <= @TargetKey
begin
	exec cloudcore.ActivityStart @ActivityGuidToStartWith, @KeyValue, @UserId, @InstanceId out
	set @KeyValue = @KeyValue + 1
end
go

