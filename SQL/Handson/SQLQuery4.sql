use practice
drop trigger trgNoChanges
create or alter trigger trgNoChanges
on dept
for insert,update,delete
as begin
--select 'Permission denied'
--rollback
end
insert into dept values(9,'abc','india')
delete from dept where deptno=8
select * from dept

--trigger for creating log data
create table auditlog(msg nvarchar(max))
create or alter trigger trgaudit
on emp
for insert
as begin
declare @id int 
select @id=empno from inserted
insert into auditlog 
values('New employee added with employee id'+' '+cast(@id as varchar(5)))
end
select * from emp
insert into emp values(7908,'STARK','PO',3422,null,928109,null,10)
select * from auditlog

alter table auditlog
add auditdate date
--update trigger
create or alter trigger trgupdateaudit
on emp
for update
as begin
declare @id int,@olddept int,@newdept int
declare @oldname varchar(40),@newname varchar(40)
declare @oldsal float,@newsal float
declare @auditdata varchar(max)
select *from deleted
select * from inserted
select * into #temptable from inserted
while(exists(select empno from #temptable))
begin
set @auditdata =' '
select top 1 @id=empno,@newname=ename,@newsal=salary,@newdept=deptno from #temptable
select @oldname=ename,@oldsal=salary,@olddept=deptno from deleted
set @auditdata='Employee with id  ' +cast(@id as varchar(5))+ 'changed'
if (@oldname<>@newname)
set @auditdata=@auditdata +'the name from'+@oldname+'to'+@newname
else
set @auditdata=@auditdata +'No changes'
if(@oldsal<>@newsal)
set @auditdata=@auditdata +'the name from'+cast(@oldsal as varchar(8))+'to'+cast(@newsal as varchar(10))
else
set @auditdata=@auditdata +'No changes'
if (@olddept<>@newdept)
set @auditdata=@auditdata +'the name from'+cast(@olddept as varchar(5))+'to'+cast(@newdept as varchar(5))
else
set @auditdata=@auditdata +'No changes'
insert into auditlog values(@auditdata,getdate())
delete from #temptable where empno=@id
end
end

select * from emp where job='clerk' 
update emp 
set salary=salary+50 where job='analyst'
--delete trigger
create or alter trigger deleteaudit
on emp for delete
as begin
declare @id int
declare @auditdata varchar(max)
select @id=empno from deleted
set @auditdata='Employee with id  ' +cast(@id as varchar(5))+ 'deleted'
insert into auditlog values(@auditdata,getdate())
end 

delete from emp where empno=7900

select * from auditlog
select * from emp
--bulk delete trigger
create or alter trigger trgbulkdelete
on emp
for delete
as begin
declare @id int
declare @auditdata varchar(max)
select * into #temptable from deleted
while(exists(SELECT TOP 1 empno from #temptable))
begin
select top 1 @id = empno from #temptable
set @auditdata ='Employee with id  ' +cast(@id as varchar(5))+ 'deleted'
insert into auditlog values(@auditdata,getdate())
delete from #temptable where empno = @id
end
end

delete from emp where job='clerk'
select * from emp
select * from auditlog


 create or alter view vwempbydept
 as select empno,ename,salary,job,dept.dname from emp join dept on emp.deptno=dept.deptno

 
 select * from vwEmpbyDept

insert into vwEmpbyDept values(300,'Ajay',6000,'24423553','Accounts') --/ purchase

select * from dept

--instead of triggers are used to resolve issues with view updations

sp_helptext vwempbydept






select * from emp
--select * from AuditLog
select * from vwEmpbyDept 
select * from dept
update vwEmpbyDept set dname='Operations'  where empno=7521

--ex write an instead of trigger on the view to ensure updation of the departmentid 
--in the employee table for a given employee, and not in the department table as seen





create or alter trigger trg_ViewIns_Insteadof
on vwempbydept    -- trigger on a view relation
instead of insert
as
 begin
  declare @departmentid int
  --first let us check if the given department in the insert clause is valid ('Accounts')
  set @departmentid = (select deptno from dept d, inserted where inserted.dname = d.Dname)

  --now we will check the data  in the variable @departmentid
  if(@departmentid is null)
    begin
	 raiserror('Invalid Department name.. terminating', 16,1)
	 return
	 end

	 --if the @departmentid is valid
	 insert into emp(empno,ename,salary,job,Deptno)
	 select e.empno,e.ename,e.salary,e.job,@departmentid from emp e  join inserted i on e.empno = i.empno
end


insert into vwEmpbyDept values(250,'Vijay',6000,'salesman','Operations') 

select * from dept
select * from vwEmpbyDept



