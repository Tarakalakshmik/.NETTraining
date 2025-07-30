use codechallenge

create table employee_details(Empid int identity(1,1) primary key,
Name varchar(50),Gender char(1),Salary float,Net_Salary float)

create or alter procedure Insertion
@Name nvarchar(100),
@Salary float,
@Gender char(1),
@EmpId int output,
@NetSalary float output
as
begin

set @NetSalary=@Salary*0.9
insert into  Employee_Details(name, gender,salary, net_salary) values(@Name, @Gender, @Salary,@NetSalary)

set @Empid=@@identity
end

declare @empid int
declare @netsalary float
exec insertion
    @name = 'Taraka',
    @salary = 10000,
    @gender = 'F',
    @empid = @empid output,
    @netsalary = @netsalary output
select * from employee_details


create or alter procedure update_salary
 @empid int,
@updated_salary float output
as
begin
update employee_details
set salary = salary + 100,
net_salary = (salary + 100) * 0.9
where empid = @empid;
select @updated_salary = salary
    from employee_details
    where empid = @empid;
end;

declare @updated_salary float;
exec update_salary
    @empid = 1,  
    @updated_salary = @updated_salary output;
select @updated_salary as UpdatedSalary;
select * from employee_details



