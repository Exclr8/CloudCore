CREATE VIEW [cloudcore].[vwUserWeeklyTaskCompletedCount]
	AS 

SELECT  UserId, ADate, ActivityName, TaskGUIDCount, Ranking
FROM    (
			SELECT  CCth.UserId, 
                    CAST(Completed AS DATE) ADate, 
                    CCtm.ActivityName, 
                    COUNT(cctm.ActivityName) TaskGUIDCount, 
                    ROW_NUMBER() OVER (PARTITION BY CAST(Completed AS DATE) ORDER BY COUNT(CCtm.ActivityName)DESC) AS Ranking
			FROM    [cloudcore].ActivityHistory CCth
			INNER JOIN [cloudcoremodel].ActivityModel CCtm 
                ON  CCtm.ActivityModelId = CCth.ActivityModelId      
			WHERE   CCth.Completed BETWEEN
									DATEADD(DD, 1 - DATEPART(DW, GETDATE()), GETDATE())
								   AND
                                    GETDATE()
   
		   GROUP BY CCth.UserId, 
                    CAST(Completed AS DATE), 
                    CCtm.ActivityName
		) AS SQ
WHERE Ranking <= 5
