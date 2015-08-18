CREATE FUNCTION [cloudcore].[SystemValue_GetValueData]
(
    @CategoryName varchar(50),
    @ValueName varchar(50)
)
returns varchar(max)
AS
BEGIN
    declare @ValueData varchar(max)

       set @ValueData = (   
                            select  ValueData
                            from    [cloudcore].SystemValue sv
                            inner join [cloudcore].SystemValueCategory svc 
                                on  sv.CategoryId = svc.CategoryId
                            where   sv.ValueName = @ValueName
                                    and svc.CategoryName = @CategoryName
                        )

    return @ValueData
END