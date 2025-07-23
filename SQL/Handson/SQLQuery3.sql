--Indexers
create table Testtable(TestId int,TestName varchar(max),TestDate date)
insert into TestTable values (4,'JQUERY','2025/07/20'),(6,'ASP.Net','2025/07/20'),(6,'CSHARP','2025/07/23'),
(null,'SQL','2025/07/25'),(1,'API','2025/08/21')
select * from TestTable
delete from TestTable where TestName like 'c%'
create clustered index idxt_tid on Testtable(TestId)
--dropping index from table
drop index TestTable.idxt_tid
--creating unique clustered index
create unique clustered index idx_u on TestTable(testid)

sp_help testtable

--non clustered index
create index idxtestname on testtable(testdate)
create unique nonclustered index idxname on dept(dname)
select * from dept
insert into dept values(11,'hr',70000)--unique non clustered - no duplicates
create nonclustered index idxname on emp(ename)
drop index emp.idxname 
select * from emp
insert into emp values(7370,'SMITH','CLERK',7902,null,800,null,20)
drop index emp.idxsalary
--filtered index
create index idxsalary on emp(salary) where salary>1600
use practice
--views
--single table view
create view vwempdata as select empno,ename,salary from emp
select * from vwempdata
