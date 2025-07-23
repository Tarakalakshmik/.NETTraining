--Northwind
use practice
select * from categories
select * from Employees
select * from customers

create or alter function fn_getcustomer_by_country(@ecountry_name varchar(15))
returns 
@customer_by_job table(Customer_id varchar(20) ,Customer_Name varchar(30),City_name varchar(15),Country_Name varchar(15))
as begin
--bulk insertion
insert into @customer_by_job select Customerid,ContactName,City,Country from customers
where country=@ecountry_name
if @@rowcount=0
begin 
insert into @customer_by_job values(0,'No customer from that country',Null,@ecountry_name)
end
return
end

select * from fn_getcustomer_by_country('UK')
select * from fn_getcustomer_by_country('INDIA')