use codechallenge

--1. Write a query to display your birthday( day of week)
select datename(weekday,'2003-12-20') as BirthdayWeekday;


--2.	Write a query to display your age in days
select datediff(day,'2003-12-20',getdate()) as [Age in days]



-- 3.	Write a query to display all employees information those who joined before 5 years in the current month
--select * from emp
update emp set hire_date='2003-JUL-20' where empno=7566
update emp set hire_date='2019-JUL-30' where empno=7369
select * from emp where datediff(year,hire_date ,getdate())>5 and month(hire_date)=month(getdate())


--4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
--	a. First insert 3 rows 
--	b. Update the second row sal with 15% increment  
--        c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.

create table employee (empno int,ename varchar(15),sal float,doj date)
--normal insertion
insert into employee values(0,'Taraka',900000,'2023-11-10')
 --Transaction
Begin transaction T1
insert into employee values(1,'Sneha',9002890,'2023-02-15'),(2,'Kala',4090000,'2023-02-15'),(3,'Vardhan',100000,'2025-09-23')
--updation
update employee set sal=sal+sal*15/100 where empno=2
--delete
delete from employee where empno=1
commit
select * from employee

--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
--	a.     For Deptno 10 employees 15% of sal as bonus.
--	b.     For Deptno 20 employees  20% of sal as bonus
--	c      For Others employees 5%of sal as bonus

 create or alter function fn_bonu(@deptno int, @salary int)
returns int
as begin
declare @bonus int
 if @deptno = 10 
 begin set @bonus = @salary*0.15
 end
else if @deptno =20
begin
set @bonus = @salary*0.20
end
else
begin
set @bonus =@salary*0.05
end
    return @bonus
end
 
select empno 'Employee Id', ename 'Employee Name', deptno 'Department No', Salary, dbo.fn_bonus(deptno, salary) 'Bonus' from emp
 
 
 --6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
 create or alter proc sp_sal_update 
as begin 
update 
emp set salary = salary + 500 
where deptno = 
(select deptno from dept where dname = 'SALES') and salary < 1500
end
 exec sp_sal_update
select * from emp where deptno = (select deptno from dept where dname = 'SALES' )
 
 
 
 
 
 
 





create table dept(
deptno int primary key,
dname varchar(30),
loc varchar(30)
)

create table emp(
empno int primary key,
ename varchar(30) not null,
job varchar(30) not null,
mgr_id int,
hire_date varchar(30),
salary int,
comm int,
deptno int references dept(deptno)
)

insert into dept values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO' ),
(40,'OPERATIONS','BOSTON')

insert into emp values (7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10)





