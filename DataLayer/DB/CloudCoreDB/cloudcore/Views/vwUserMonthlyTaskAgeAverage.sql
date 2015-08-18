CREATE VIEW [cloudcore].[vwUserMonthlyTaskAgeAverage]
	AS
SELECT  SQ.AverageAge, SQ.UserId, SQ.ActivityName, SQ.AMonth, SQ.AYear, SQ.Ranking
FROM    (	      	       
	        SELECT  AVG(DATEDIFF(SS, th.Opened, th.Completed)) AverageAge, 
                    th.UserId, 
                    tm.ActivityName, 
                    MONTH(th.Assigned) AMonth, 
                    YEAR(th.Assigned) AYear, 
                    ROW_NUMBER() OVER (PARTITION BY  MONTH(th.Assigned) ORDER BY AVG(DATEDIFF(SS, th.Opened, th.Completed)) ASC) AS Ranking
            FROM    [cloudcore].ActivityHistory AS th 
            INNER JOIN [cloudcoremodel].ActivityModel AS tm
                ON  th.ActivityModelId = tm.ActivityModelId
            WHERE   th.Completed between CAST(CAST(YEAR(GETDATE()) AS VARCHAR(5)) + '-01-01' AS DATETIME) AND GETDATE()
           GROUP BY tm.ActivityName, 
                    MONTH(th.Assigned), 
                    YEAR(th.Assigned),
                    th.UserId
        ) AS SQ
WHERE   SQ.Ranking <= 5
