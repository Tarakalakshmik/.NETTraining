use assignment
--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions

create or alter procedure payslip @empid int
as begin
declare @Employee_Name varchar(15)
declare @Salary float(2)
declare @HRA float(2)
declare @DA float
declare @PF float
declare @IT float
declare @deductions float
declare @Gross_Salary float
declare @Net_Salary float
select  @salary=  salary from emp where empno=@empid
select  @Employee_Name=ename from emp where empno=@empid
set @HRA=@salary*0.1
set @DA=@salary*0.2
set @Pf=@salary*0.08
set @IT=@salary*0.05
set @deductions=(@PF+@IT)
set @Gross_Salary=(@salary+@hra+@da)
set @net_salary=@Gross_salary-@deductions
print 'Payslip of Employee '+@Employee_Name
print 'HRA is:'+' '+cast(@HRA as varchar(MAX))
print 'DA is:'+' '+cast(@DA as varchar(MAX))
print 'PF is:'+' '+cast(@PF as varchar(MAX))
print 'IT is:'+' '+cast(@IT as varchar(MAX))
print 'Deduction is:'+' '+cast(@deductions as varchar(MAX))
print 'Gross salary is:'+' '+cast(@Gross_salary as varchar(MAX))
print 'Net salary is:'+' '+cast(@Net_Salary as varchar(MAX))
end

execute payslip @empid=7566


--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 
--Holiday table
create table holiday (
    holiday_date date primary key,
    holiday_name varchar(50)
)
insert into holiday values 
('2025-08-15', 'independence day'),('2025-11-26', 'diwali'),('2025-01-26', 'republic day'),('2025-12-25', 'christmas')
insert into holiday values('2025-07-23','SUNDAY')
create or alter trigger data_manipulation
on emp for insert,delete,update
as begin
declare @today_date date
declare @holiday_name varchar(15)
set @today_date=getdate()
select @holiday_name=holiday_name from holiday where holiday_date=@today_date
if @holiday_name is not null
begin
raiserror('due to %s you cannot manipulate data.', 16, 1,@holiday_name)
rollback 
end
end

select * from emp
insert into emp values(7984,'THOR','SA',231,'date',4234,null,20)
delete from emp where empno=7369
update emp set salary = salary + 5000 where empno = 7369
