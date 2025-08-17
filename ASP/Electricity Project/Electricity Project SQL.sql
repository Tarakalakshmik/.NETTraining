--Database ElectricityBillDB
create database ElectricityBillDB
use ElectricityBillDB

--Table Creation
create table electricitybill (
    consumer_number varchar(20) not null primary key,
    consumer_name varchar(50) not null,
    units_consumed int not null check (units_consumed >= 0),
    bill_amount float not null check (bill_amount >= 0)
)

select * from electricitybill
