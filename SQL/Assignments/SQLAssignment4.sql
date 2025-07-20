use assignment
--1.	Write a T-SQL Program to find the factorial of a given number.
 
create or alter proc fact @int int
as
begin
    declare @res int = 1, @counter int = @int
 
    while @counter >= 1
    begin
        set @res = @res * @counter
        set @counter = @counter - 1
    end
 
    print 'Factorial of ' + cast(@int as varchar) + ' is ' + cast(@res as varchar)
end
 
exec fact @int = 10
 
 
--2  Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number.
 
create or alter proc mul_table @num int, @upto int
as
begin
	declare @count int = 1
	while @count <= @upto
	begin 
		print cast(@num as varchar) + ' x ' + cast(@count as varchar) + ' = ' + cast(@num * @count as varchar)
		set @count = @count + 1
	end
end
 
exec mul_table @num = 10, @upto = 10
 
 
--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly
 
create table Student (
    Std_id int primary key,
    sname varchar(50)
)
 
insert into Student (std_id, Sname) values
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj')
 
 
create table marks (
    mark_id int primary key,
    std_id int,
    Score int,
    foreign key (Std_id) references Student(Std_id)
)
 
insert into Marks (mark_id, Std_id, Score) values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13)
 
select * from Student select * from Marks
 
create function Status (@marks int)
returns nvarchar(10)
as
begin
	declare @status varchar(10)
	if @marks >= 50
		set @status = 'Pass'
	else
		set @status = 'Fail'
	return @status
end
 
select 
s.std_id, s.sname, m.score, dbo.Status(m.score) as 'Status of the student'
from Student s
join Marks m on s.std_id = m.std_id