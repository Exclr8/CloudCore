CREATE PROCEDURE [cloudcore].[AccessPoolUpdate]
	@AccessPoolId		int,
	@AccessPoolName		varchar (50),
	@ManagerId			int
As
Begin
	update cloudcore.AccessPool  
	set AccessPoolName	 = @AccessPoolName,
		ManagerId		 = @ManagerId
			where AccessPoolId	 = @AccessPoolId
End