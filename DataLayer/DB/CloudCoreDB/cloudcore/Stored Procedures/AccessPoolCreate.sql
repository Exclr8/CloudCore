CREATE PROCEDURE [cloudcore].[AccessPoolCreate]
	@AccessPoolId		int out,
	@AccessPoolName		varchar (50),
	@ManagerId			int
As
Begin
	Insert into cloudcore.AccessPool(AccessPoolName, 
									 ManagerId)
								
							values (@AccessPoolName, 
									@ManagerId)
								
	Set @AccessPoolId = SCOPE_IDENTITY()
End