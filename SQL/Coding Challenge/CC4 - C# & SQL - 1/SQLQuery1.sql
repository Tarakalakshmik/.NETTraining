--Query 1
--Write a query to fetch the details of the books written by author whose name ends with er.

create database codechallenge
create table books(id bigint primary key,title varchar(50) not null,author varchar(50) not null,isbn bigint unique not null,published_date datetime not null)
insert into  books values(1,'My First SQL book','Mary Parker',981480329127,'2012-02-22 12:08:17'),(2,'My Second SQL book','John Mayer',857300923713,'1972-07-03 09:22:45'),(3,'My Third SQL book','Cary Flint',523120967812,'2015-10-18 14:05:44')
select * from books
select * from books where author like '%er'


--Query 2
--Display the Title ,Author and ReviewerName for all the books from the above table
create table reviews(id int primary key,book_id bigint foreign key(book_id) references  books(id),reviewer_name varchar(50) not null,content varchar(30)not null,rating int ,published_date datetime not null)
insert into reviews values(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11'),(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12'),(3,2,'Alice Walker','Another review',1,'2017-10-22 23:47:10')
select * from reviews
select
    b.title,
    b.author,
    r.reviewer_name
from  books b join
    reviews r on b.id = r.book_id;
 
 --Query 3
-- Display the reviewer name who reviewed more than one book.
select reviewer_name from reviews group by reviewer_name having count(reviewer_name)>1


--Query 4
--Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
create table customer(id int primary key,name varchar(15) not null,age int not null,address varchar(30) not null,salary float not null)
insert into customer values(1,'Ramesh',32,'Ahmedabad',2000.00),(2,'Khilan',25,'Delhi',1500.00),(3,'kaushik',23,'kota',2000.00),(4,'chaitali',25,'mumbai',6500.00),(5,'hardik',27,'bhopal',8500.00),(6,'komal',22,'mp',4500.00),(7,'muffy',24,'indore',10000.00)
select * from customer
select name from customer where address like '%o%'

--Query 5
--Write a query to display the Date,Total no of customer placed order on same Date
create table orders(oid int primary key,date DATETIME not null,customer_id int not null,foreign key(customer_id) references customer(id) ,amount float not null)
insert into orders values(102,'2009-10-08 00:00:00',3,3000),(100,'2009-10-08 00:00:00',3,1500),(101,'2009-11-20 00:00:00',2,1560),(103,'2008-05-20 00:00:00',4,2060)
select * from orders
select date,count(date) as [No of orders] from orders group by date order by date


--Query 6
--Display the Names of the Employee in lower case, whose salary is null

create table employee(id int primary key,name varchar(15) not null,age int not null,address varchar(30) not null,salary float)
insert into employee (id,name,age,address,salary) values(1,'Ramesh',32,'Ahmedabad',2000.00),(2,'Khilan',25,'Delhi',1500.00),(3,'kaushik',23,'kota',2000.00),(4,'chaitali',25,'mumbai',6500.00),(5,'hardik',27,'bhopal',8500.00),(6,'Komal',22,'mp',null),(7,'Muffy',24,'indore',null)
select * from employee
select lower(name) from employee where salary is null

--Query 7
--Write a sql server query to display the Gender,Total no of male and female from the above relation
create table StudentDetails (id int,Registration int primary key,Name varchar(50), Age int,Qualification varchar(50),MobileNo varchar(15) unique, Mail_id varchar(50) unique,location varchar(50),Gender char(1))
insert into  StudentDetails values
(1,2, 'Sai', 22, 'B.E', '9952836777', 'sai@gmail.com', 'chennai', 'M'),
(2, 3,'Kumar', 20, 'BSC', '7890126648', 'kumar@gmail.com', 'madhurai', 'M'),
(3, 4,'Selvi', 22, 'B.TECH', '8904567342', 'Selvi@gmail.com', 'selam', 'F'),
(4, 5,'Nisha', 25, 'M.E', '7834672310', 'nisha@gmail.com', 'Theni', 'F'),
(5, 6,'Sai Sarn', 21, 'B.A', '7890345678', 'saran@gmail.com', 'madhurai', 'F'),
(6, 7,'Tom', 23, 'BCA', '890123675', 'tom@gmail.com', 'Pune', 'M');
select gender,count(gender) as [Total] from  StudentDetails group by gender

