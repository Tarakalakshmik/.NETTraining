use practice
select * from emp
ALTER TABLE emp DROP COLUMN hire_date;
ALTER TABLE emp DROP COLUMN mgr_id;
ALTER TABLE emp DROP COLUMN comm;
drop trigger trgupdateaudit

create   proc sp_getavgsal_empcount (@did int, @avgsal float output)  
as  
begin  
select @avgsal = avg(salary) from emp where Deptno = @did  
return (select count(empno) from emp where Deptno = @did)  
end

declare @avg float
declare @empcount int
execute @empCount = sp_getavgsal_empcount @did = 40, @avgsal = @avg output;

select @avg as AverageSalary, @empCount as EmployeeCount;


sp_help sp_getavgsal_empcount
sp_help custordersorders

select * from emp
