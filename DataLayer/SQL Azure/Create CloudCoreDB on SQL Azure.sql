-- this script is run bit by bit on SQL Azure to create the InvinysDB (but no DB schema structure or content)

-- run this on CloudCoreDB (if it exists)
DROP USER diauser;

DROP USER ccsystem;

-- run this on master
DROP LOGIN diauser;

DROP LOGIN ccsystem;

CREATE LOGIN ccsystem WITH PASSWORD='f0n3_aSd'


-- for test purposes only! do not use on live production system:
-- CREATE LOGIN diauser WITH PASSWORD='diapass'

drop database CloudCoreDB
create database CloudCoreDB

-- run this on CloudCoreDB

create user ccsystem for login ccsystem
sp_addrolemember 'db_owner','ccsystem'

-- for test purposes only! do not use on live production system:
-- create user diauser for login diauser
-- sp_addrolemember 'db_owner','diauser'