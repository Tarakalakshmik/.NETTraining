--misc functions
--is null() gives not nullable values
select isnull('Hello','replace value of null ')as 'is null'
select isnull(null,'replace value of null')as 'isnull'

create table NullFunCheck
(serialno int,name varchar(20),loc varchar(20),age int,pccupation varchar(20))

insert into nullfuncheck values(1,'Taraka','India',21,'software engineer'),
(2,'Sneha','India',21,'Artist'),(3,'Varshini','USA',null,'Writer'),
(4,'Susmitha','UK',null,'Professor')

select * from nullfuncheck

select *,isnull(age,30)as 'New age' from nullfuncheck

update nullfuncheck set age=isnull(age,30) where loc='India'
update nullfuncheck set age=null where serialno =2

insert into nullfuncheck values(5,'Vardhan','Canada',isnull(null,25),'Researcher')

--coalesce
declare @str1 char,@str2 char,@str3 char
select coalesce(@str1,@str2)as 'Coalesce results',
case
when @str1 is not null then @str1
when @str2 is null then 'is a null value'
end as 'Case result'
select coalesce(null,null,null,null,null,10)
select isnull(null,isnull(null,isnull(null,isnull(5,null))))

--rollup
select deptno,sum(salary) as 'Total salary' from employees
group by deptno

select * from employees

select deptno,sum(salary) as 'Total salary' from employees
group by rollup(deptno)

select coalesce(deptno,500),sum(salary) as 'Total salary' from employees
group by rollup(deptno)

--sub totals and grand totals deptwise,gender wise
select coalesce(deptno,500) as department,coalesce(job,'All job') from employees
group by rollup(deptno,job)

--additional functions
create table students(sdtname varchar(25),subject varchar(20),marks int)
insert into students values('tarun','maths',80),
('Tarun','science',70),('Tarun','English',65),
('Nishitha','Maths',68),('Nishitha','Science',85),
('Nishitha','English',90),('Susmitha','Maths',65),
('Susmitha','Science',90),('Susmitha','English',65)

select * from students
--row_number()

select sdtname,subject,marks,row_number() over(order by marks desc) 
as row_numbers from students

--rank()
select sdtname,subject,marks,rank() over(order by marks desc) 
as rank_numbers from students

--dense rank
select sdtname,subject,marks,dense_rank() over(order by marks desc) 
as rank_numbers from students

--seggregation based on particular columns can be used with partition
select sdtname,subject,marks,dense_rank() over(partition by subject order by marks desc) 
as rank_numbers from students

select sdtname,subject,marks,rank() over(partition by subject order by marks desc) 
as rank_numbers from students

select sdtname,subject,marks,rank() over(partition by sdtname order by marks desc) 
as rank_numbers from students