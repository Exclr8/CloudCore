CREATE PROCEDURE [cloudcore].[PeriodDelete]
    @PeriodSeq Int
as
begin
	
	if exists (select null 
                from [cloudcore].CostLedger 
               where PeriodSeq = @PeriodSeq)
		begin
    		  raiserror(N'Unable to delete, there are one or more Cost Ledger items using this financial period.',18, 1) 	

		      return
		end 
		
	delete from [cloudcore].Period 
	      where PeriodSeq = @PeriodSeq
	   
end