CREATE VIEW [cloudcore].[vwUserMonthlyTaskCompletedCount]
	AS 

SELECT  SQ.UserId, SQ.AMonth, SQ.ActivityName, SQ.TaskGUIDCount, SQ.Ranking
FROM    (
            SELECT  CCth.UserId, 
                    MONTH(Completed) AMonth, 
                    CCtm.ActivityName, 
                    COUNT(cctm.ActivityGuid) [TaskGUIDCount], 
                    ROW_NUMBER() OVER (PARTITION BY Month(Completed) ORDER BY COUNT(cctm.ActivityName) DESC) AS Ranking
            FROM    [cloudcore].ActivityHistory AS CCth
            INNER JOIN [cloudcoremodel].ActivityModel AS CCtm 
                ON  CCtm.ActivityModelId = CCth.ActivityModelId
            WHERE   CCth.Completed BETWEEN cast((CAST(YEAR(GETDATE()) AS VARCHAR(5)) + '-01-01') as datetime) AND GETDATE()
           GROUP BY CCth.UserId, 
                    Month(Completed), 
                    CCtm.ActivityName
        ) AS SQ
WHERE Ranking <=5
