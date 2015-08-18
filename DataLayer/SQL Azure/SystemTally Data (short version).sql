with base (nm) as (select 0 union all select 1 union all select 2 union all select 3 union all select 4 union all select 5 union all select 6 union all select 7 union all select 8 union all select 9),
     base_1 (nm) as (SELECT b1.nm + b2.nm*10 + b3.nm*100 + b4.nm*1000 + b5.nm*10000 + b6.nm*100000 from base b1, base b2, base b3, base b4, base b5, base b6)
insert into [cloudcore].SystemTally (TallyId, ZeroBased)     
select nm+1, nm from base_1