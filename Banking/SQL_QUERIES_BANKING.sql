CREATE DATABASE BankingDB;
USE BankingDb;

SELECT * FROM fn_AdminLogin('wrongemail@example.com', 'wrongpassword');
select * from Customer
select * from Accounts
CREATE TABLE RegisterAccount
(
	Service_Reference_Number int primary key identity(10000,1),
	Title varchar(3),
	First_Name varchar(20) not null,
	Middle_Name varchar(20),
	Last_Name varchar(20) not null,
	Father_Name varchar(15) not null,
	Mobile_Number bigint not null,
	Email_Id varchar(30) not null,
	Aadhar varchar(12) not null,
	Gender varchar(6) not null,
	Date_Of_Birth date not null,
	Residential_Address varchar(100) not null,
	Permanent_Address varchar(100) not null,
	Occupation_Type varchar(50) not null,
	Source_Of_Income varchar(50) not null,
	Gross_Annual_Income float default 0,
	Opt_Debit_Card bit default 0,
	Opt_Net_Banking bit default 0
);

CREATE TABLE Customer
(
	Customer_Id int primary key identity(10000,1),
	Title varchar(3),
	First_Name varchar(20) not null,
	Middle_Name varchar(20),
	Last_Name varchar(20) not null,
	Father_Name varchar(15) not null,
	Mobile_Number bigint not null,
	Email_Id varchar(30) not null,
	Gender varchar(6) not null,
	Aadhar int,
	created_at date default getdate(),
	Date_Of_Birth date not null,
	Residential_Address varchar(100) not null,
	Permanent_Address varchar(100) not null,
	Occupation_Type varchar(50) not null,
	Source_Of_Income varchar(50) not null,
	Gross_Annual_Income float,
);
--Change in aadhar datatype
ALTER TABLE Customer
ALTER COLUMN Aadhar varchar(12);

CREATE TABLE Accounts
(
	Customer_Id int references Customer(Customer_Id),
	Account_Number int primary key identity(10000,1),
	created_at date default getdate(),
	Balance float default 1000,
);

CREATE TABLE Internet_Banking_Details
(
	Account_Number int references Accounts(Account_Number),
	email varchar(20) primary key,
	login_password varchar(50) not null,
	transaction_password varchar(50) not null
);
ALTER TABLE Internet_Banking_Details DROP CONSTRAINT PK__Internet__AB6E6165AC5A32BA;
select * from Internet_Banking_Details
alter table Internet_Banking_Details alter column email varchar(30) 
ALTER TABLE Internet_Banking_Details
ALTER COLUMN email VARCHAR(30) NOT NULL;


ALTER TABLE Internet_Banking_Details ADD CONSTRAINT  PK__Internet__AB6E6165AC5A32BA PRIMARY KEY  (email);


CREATE TABLE Debit_Card_Details
(
	Account_Number int references Accounts(Account_Number),
	Debit_Card_Number bigint primary key identity(4000000000000000, 1),
	Expiry_Date date not null
);

select * from Accounts
CREATE TABLE Transaction_Details
(
	Transaction_Id int primary key identity(10000,1),
	From_Account int,
	To_Account int,
	Transaction_Mode varchar(10),
	Transaction_Type varchar(6),
	Amount int check(Amount > 0),
	Transaction_Date datetime default getdate(),
	Remarks varchar(50),
);

-- 1 transaction from today
INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (101, 202, 'Online', 'Credit', 5000, GETDATE(), 'Today transaction');

-- 2 transactions from 7 days ago
INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (103, 204, 'UPI', 'Debit', 1500, DATEADD(DAY, -7, GETDATE()), 'Week old transaction 1');

INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (105, 206, 'NEFT', 'Credit', 2500, DATEADD(DAY, -7, GETDATE()), 'Week old transaction 2');

-- 2 transactions from last month
INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (107, 208, 'IMPS', 'Debit', 3000, DATEADD(MONTH, -1, GETDATE()), 'Last month transaction 1');

INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (109, 210, 'Online', 'Credit', 4000, DATEADD(MONTH, -1, GETDATE()), 'Last month transaction 2');
INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (10000, 10001, 'Online', 'Credit', 4000, DATEADD(MONTH, -1, GETDATE()), 'Last month transaction 2');
INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (10001, 10000, 'Online', 'Credit', 4000, DATEADD(MONTH, -1, GETDATE()), 'Last month transaction 2');
INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (10010, 10000, 'Online', 'Credit', 4000, DATEADD(MONTH, -1, GETDATE()), 'Last month transaction 2');
-- 1 transaction from 5 months ago
INSERT INTO Transaction_Details (From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks)
VALUES (111, 212, 'UPI', 'Debit', 3500, DATEADD(MONTH, -5, GETDATE()), '5 months old transaction');
CREATE TABLE Admin_Table
(
	id int primary key identity(1,1),
	Name varchar(30) not null,
	Email_Id varchar(30) unique,
	password varchar(50) not null
);


INSERT INTO Admin_Table (Name, Email_Id, password)
VALUES ('Bank Admin', 'banking@gmail.com', 'Infiniteadmin@123');

INSERT INTO Admin_Table (Name, Email_Id, password)
VALUES ('Bank Admin', 'admin', 'admin123');

create table Payees
(
Payee_Id int identity(1,1) primary key,
From_Account int references Accounts(Account_Number),
To_Account int references Accounts(Account_Number),
Beneficiary_Name varchar(50) not null,
created_at date default getdate(),
Nickname varchar(20)
);


select * from Internet_Banking_Details
--stored procedures
create or alter procedure Sp_Register_Account @Title varchar(3),
	@First_Name varchar(20),
	@Middle_Name varchar(20),
	@Last_Name varchar(20),
	@Father_Name varchar(15),
	@Mobile_Number bigint,
	@Email_Id varchar(30),
	@Aadhar varchar(12),
	@Gender varchar(6),
	@Date_Of_Birth date,
	@Residential_Address varchar(50),
	@Permanent_Address varchar(50),
	@Occupation_Type varchar(50),
	@Source_Of_Income varchar(50),
	@Gross_Annual_Income float,
	@Opt_Debit_Card bit,
	@Opt_Net_Banking bit
as
begin
	if((select Service_Reference_Number from RegisterAccount where aadhar = @Aadhar) is not null)
	begin
		raiserror('Already Registered!!! Pending Approval', 15, 1);
	end
	begin try
		insert into RegisterAccount values(@Title, @First_Name, @Middle_Name, @Last_Name, @Father_Name, @Mobile_Number,
		@Email_Id, @Aadhar, @Gender, @Date_Of_Birth, @Residential_Address, @Permanent_Address, @Occupation_Type, @Source_Of_Income,
		@Gross_Annual_Income, @Opt_Debit_Card, @Opt_Net_Banking);
		return select Service_Reference_Number from RegisterAccount where Aadhar = @Aadhar;
	end try
	begin catch
		raiserror('Unable to register account', 15, 1);
	end catch
end
delete from RegisterAccount where Service_Reference_Number=10008

exec Sp_Register_Account 'Mr', 'Hema Sai', '', 'Bonda', 'Sanjeev', 9390939012, 'bhs@gmail.com', '999977778888', 'Male', '2003-05-08', 'Visakhapatnam', 'Visakhapatnam', 'Private', 'Job', 450000, 1, 1
exec Sp_Register_Account 'Mr', 'Hema Sai', '', 'Bonda', 'Sanjeev', 9390939018, 'klgv2005@gmail.com', '999977778889', 'Male', '2003-05-08', 'Visakhapatnam', 'Visakhapatnam', 'Private', 'Job', 450000, 1, 1
exec Sp_Register_Account 'Mrs', 'Taraka Lakshmi', '', 'Killada', 'Sanjeev', 8390939090, 'snehavayuleti@gmail.com', '899977778890', 'Male', '2003-05-08', 'Visakhapatnam', 'Visakhapatnam', 'Private', 'Job', 450000, 1, 1
exec Sp_Register_Account 'Mrs', 'Susmitha', '', 'Raparthi', 'Sanjeev', 8390939000, 'varshini9133@gmail.com', '899977978890', 'Male', '2003-05-08', 'Visakhapatnam', 'Visakhapatnam', 'Private', 'Job', 450000, 1, 1
exec Sp_Register_Account 'Ms', 'Sneha', '', 'Vayuleti', 'Taraka', 8390949000, 'vayuletisneha@gmail.com', '899977988890', 'Female', '2003-05-08', 'Visakhapatnam', 'Visakhapatnam', 'Private', 'Job', 450000, 1, 1
exec Sp_Register_Account 'Ms', 'Sneha', '', 'Taraka', 'Trickubujji', 8390949099, 'trickibujji@gmail.com', '899907988890', 'Female', '2003-05-08', 'Visakhapatnam', 'Visakhapatnam', 'Private', 'Job', 450000, 1, 1
exec Sp_Register_Account 'Ms', 'Sneha', '', 'Taraka', 'Trickubujji', 8390945899, 'polinaiduk1973@gmail.com', '899907988190', 'Female', '2003-05-08', 'Visakhapatnam', 'Visakhapatnam', 'Private', 'Job', 450000, 1, 1
select * from RegisterAccount
select * from RegisterAccount
create table ChatSupport
(
Id int identity(1,1) primary key,
From_Email varchar(30),
To_Email varchar(30),
Subject varchar(50),
Message varchar(200)
);
alter table ChatSupport add Status bit;
CREATE TABLE SupportMessages (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserEmail VARCHAR(100) NOT NULL,
    Subject VARCHAR(200) NOT NULL,
    Message TEXT NOT NULL,
    SentAt DATETIME NOT NULL DEFAULT GETDATE(),
    AdminReply TEXT NULL,
    RepliedAt DATETIME NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'Pending'
);
select * from SupportMessages
select * from registerAccount
select * from Transaction_Details
select * from customer

create or alter procedure Sp_RaiseSupportRequests
	@From_Email varchar(30), @To_Email varchar(30), @Subject varchar(50), @Message varchar(200)
as
begin
	begin try
		insert into ChatSupport values (@From_Email, @To_Email, @Subject, @Message,1);
		return select Id from ChatSupport where From_Email = @From_Email and To_Email = @To_Email and Subject = @Subject and Message = @Message;
	end try
	begin catch
		raiserror('Could not raise support request', 15, 1);
	end catch
end
CREATE OR ALTER PROCEDURE Sp_RaiseSupportMessage
    @UserEmail VARCHAR(100),
    @Subject VARCHAR(200),
    @Message TEXT
AS
BEGIN
    BEGIN TRY
        INSERT INTO SupportMessages (UserEmail, Subject, Message, SentAt, Status)
        VALUES (@UserEmail, @Subject, @Message, GETDATE(), 'Pending');

        -- Return the newly inserted Id
        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END TRY
    BEGIN CATCH
        RAISERROR('Could not raise support message', 15, 1);
    END CATCH
END
 select * from RegisterAccount
 select * from customer   
 delete from Customer where Customer_Id =10009
 delete from Accounts where Customer_Id=10009
 select * from Internet_Banking_Details
 exec Sp_CreateAccount 10012,2
create or alter procedure Sp_CreateAccount @Service_Reference_Number int, @id int
as
begin
	declare @Title varchar(3),
	@First_Name varchar(20),
	@Middle_Name varchar(20),
	@Last_Name varchar(20),
	@Father_Name varchar(15),
	@Mobile_Number bigint,
	@Email_Id varchar(30),
	@Aadhar varchar(12),
	@Gender varchar(6),
	@Date_Of_Birth date,
	@Residential_Address varchar(50),
	@Permanent_Address varchar(50),
	@Occupation_Type varchar(50),
	@Source_Of_Income varchar(50),
	@Gross_Annual_Income float,
	@Opt_Debit_Card bit,
	@Opt_Net_Banking bit,
	@Customer_Id int;

	if((select Email_Id from admin_table where id = @id) is null)
	begin
		raiserror('Permission Denied', 15, 1);
	end

	select @Title = title, @First_Name = First_Name, @Middle_Name = Middle_Name, @Last_Name = Last_Name, @Father_Name = Father_Name,
	@Mobile_Number = Mobile_Number, @Email_Id = Email_Id, @Aadhar = Aadhar, @Gender = Gender, @Date_Of_Birth = Date_Of_Birth,
	@Residential_Address = Residential_Address, @Permanent_Address = Permanent_Address, @Occupation_Type = Occupation_Type,
	@Source_Of_Income = Source_Of_Income, @Gross_Annual_Income = Gross_Annual_Income, @Opt_Debit_Card = Opt_Debit_Card, @Opt_Net_Banking = Opt_Net_Banking  from RegisterAccount;

	begin try
		select @Customer_Id = customer_id from customer where Aadhar = @Aadhar;
		if(@Customer_id is null)
		begin
			insert into Customer(Title, First_Name, Middle_Name, Last_Name, Father_Name, Mobile_Number, Email_Id, Aadhar, Gender, Date_Of_Birth, Residential_Address, Permanent_Address, Occupation_Type, Source_Of_Income, Gross_Annual_Income)
			values (@Title, @First_Name, @Middle_Name, @Last_Name, @Father_Name, @Mobile_Number,
				@Email_Id, @Aadhar, @Gender, @Date_Of_Birth, @Residential_Address, @Permanent_Address, @Occupation_Type, @Source_Of_Income, @Gross_Annual_Income);
			select @Customer_Id = customer_id from customer where Aadhar = @Aadhar;
		end

		insert into accounts (Customer_Id, Balance) values (@customer_id, 1000);
		delete from RegisterAccount where Service_Reference_Number = @Service_Reference_Number;

		declare @Account_Number int;
		select @Account_Number = Account_Number from accounts where customer_id = @Customer_Id and balance = 1000;
		
		if(@Opt_Net_Banking = 1)
		begin
			exec Sp_CreateInternetBanking @Account_Number, '', '';
		end
		else
		begin
			if(@Opt_Debit_Card = 1)
			begin
				exec Sp_CreateDebitCard @Account_number;
			end
		end
	end try
	BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    RAISERROR(@ErrorMessage, 16, 1);
END CATCH
end
select * from customer
select * from Accounts
select * from Internet_Banking_Details

exec Sp_CreateInternetBanking 10012,'',''
create or alter procedure Sp_CreateInternetBanking 	@Account_Number int, @login_password varchar(50), @transaction_password varchar(50)
as
begin
	if((select Account_Number from Accounts where Account_Number = @Account_Number) is null)
	begin
		raiserror('Could not find account', 15, 1);
	end
	if(@login_password = '' or @transaction_password = '')
	begin
		set @login_password = @Account_Number;
		set @transaction_password = @Account_Number;
	end

	begin try
		declare @email varchar(50);
		select @email = Email_Id from customer where customer_id = (select customer_id from accounts where Account_Number = @Account_Number)
		insert into Internet_Banking_Details values (@Account_Number, @email, @login_password, @transaction_password);
		declare @expire_date date;
		set @expire_date = DATEADD(year, 5, getdate());
		insert into Debit_Card_Details values (@Account_Number, @expire_date);
	end try
	BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    RAISERROR(@ErrorMessage, 16, 1);
END CATCH

end

create or alter procedure Sp_CreateDebitCard @Account_Number int
as
begin
	if((select Account_Number from Accounts where Account_Number = @Account_Number) is null)
	begin
		raiserror('Could not find account', 15, 1);
	end
	begin try
		declare @expire_date date;
		set @expire_date = DATEADD(year, 5, getdate());
		insert into Debit_Card_Details values (@Account_Number, @expire_date);
	end try
	begin catch
		raiserror('Could not create debit card', 15, 1);
	end catch
end


create or alter procedure Sp_AddTransaction @From_Account int,
	@To_Account int,
	@Transaction_Mode varchar(10),
	@Transaction_Type varchar(6),
	@Amount int,
	@Transaction_Date datetime,
	@Remarks varchar(50)
as
begin
	if((select Account_Number from Accounts where Account_Number = @To_Account) is null)
	begin
		raiserror('Could not find the account to be credited', 15, 1);
	end
	declare @available_balance int;
	select @available_balance = Balance from Accounts where account_number = @From_Account;
	if(@available_balance < @Amount)
	begin
		raiserror('Insufficient Funds', 15, 1);
	end
	if(@Remarks is null or @Remarks = '')
	begin
		set @Remarks = 'Amount ₹ ' + @Amount + 'sent to account: ' + @To_Account;
	end
	begin try
		update Accounts set Balance = Balance - @Amount where Account_Number = @From_Account;
		insert into Transaction_Details (from_account, to_account, transaction_mode, transaction_type, amount, remarks) values(@From_Account, @To_Account, @Transaction_Mode, @Transaction_Type, @Amount, @Remarks);
		update Accounts set Balance = Balance + @Amount where Account_Number = @To_Account;
		return select Transaction_Id from Transaction_Details where from_account = @From_Account and to_account = @To_Account and transaction_mode = @Transaction_Mode and Transaction_Date = GETDATE() and Transaction_Type = @Transaction_Type and Remarks = @Remarks;
	end try
	begin catch
		raiserror('Transaction Failed', 15, 1);
	end catch
end

create or alter procedure Sp_ChangeLoginPassword 
	@account_number int,
	@old_password varchar(50),
	@new_password varchar(50)
as
begin
	if((select email from Internet_Banking_Details where Account_Number = @account_number and login_password = @old_password) is not null)
	begin
		if(@old_password = @new_password)
		begin
			raiserror('New password cant be same as old password', 15, 1);
		end
		update Internet_Banking_Details set login_password = @new_password where Account_Number = @account_number
	end
	else
	begin 
		raiserror('Invalid Credentials',16,1)
	end
end

create or alter procedure Sp_ChangeTransactionPassword 
	@account_number int,
	@old_password varchar(50),
	@new_password varchar(50)
as
begin
	if((select email from Internet_Banking_Details where Account_Number = @account_number and transaction_password = @old_password) is not null)
	begin
		if(@old_password = @new_password)
		begin
			raiserror('New password cant be same as old password', 15, 1);
		end
		update Internet_Banking_Details set transaction_password = @new_password where Account_Number = @account_number
	end
	else
	begin 
		raiserror('Invalid Credentials',16,1)
	end
end

create or alter function fn_GetStatement(@Account_number int,
	@from_date datetime,
	@to_date datetime)
returns @statement table(Transaction_Id int, From_Account int, To_Account int, Transaction_Mode varchar(50), Transaction_Type varchar(6), Amount int, Transaction_Date datetime, Remarks varchar(50))
as
begin
	if((select Account_number from Accounts where Account_Number = @Account_number) is null)
	begin
		insert into @statement values( -1, -1, -1, 'Unable to Find account', '', 0, null, null);
		return;
	end
	if(@from_date is null or @from_date = '')
	begin
		set @from_date = '1900-01-01';
	end
	if(@to_date is null or @to_date = '')
	begin
		set @to_date = GETDATE();
	end
	insert into @statement select Transaction_Id, From_Account, To_Account, Transaction_Mode, Transaction_Type, Amount, Transaction_Date, Remarks from Transaction_Details 
		where From_Account = @Account_number or To_Account = @Account_number and Transaction_Date between @from_date and @to_date
			order by Transaction_Date desc
	return;
end

create or alter procedure Sp_AddPayee
	@beneficiary_name varchar(50),
	@from_account int,
	@to_account int,
	@nickname varchar(20)
as
begin
	if((select Account_Number from Accounts where Account_Number = @to_account) is null)
	begin
		raiserror('Could not find payee account', 15, 1);
	end
	begin try
	insert into Payees (Beneficiary_Name, From_Account, To_Account, Nickname) values (@beneficiary_name, @from_account, @to_account, @nickname);
	end try
	begin catch
		raiserror('Could not add payee', 15, 1);
	end catch
end
 
create or alter function fn_GetPayee(@Payee_Id int)
returns @PayeeDetails table(Payee_Id int, Beneficiary_Name varchar(50), Account_Number int, Nickname varchar(20))
as
begin
	if((select From_Account from Payees where Payee_Id = @Payee_Id) is null)
	begin
		insert into @PayeeDetails values (-1, 'Could not find payee', null, null);
		return;
	end
	insert into @PayeeDetails select Payee_Id, Beneficiary_Name, To_Account, Nickname from Payees where Payee_Id = @Payee_Id;
	return;
end


create or alter function fn_AdminLogin (@email varchar(30), @password varchar(50))
returns @Details table(id int)
as
begin
	declare @id int;
	select @id = id from Admin_Table where Email_Id = @email and password = @password;
	if(@id is null)
	begin
		set @id = -1;
	end
		insert into @Details values (@id);
	return;
end

CREATE TABLE RejectedAccounts
(
	Service_Reference_Number int primary key,
	Email_Id varchar(30) not null,
	remarks varchar(100),
	rejected_at date default getdate(),
);

select * from RejectedAccounts
create or alter procedure Sp_RejectAccount @Service_Reference_Number int, @id int, @Remarks varchar(100)
as
begin
	declare @Email_Id varchar(30);
	select @Email_id = email_id from RegisterAccount where Service_Reference_Number = @Service_Reference_Number;
	if(@Email_Id is null)
	begin
		raiserror('Could not find your registration', 15, 1);
	end
	begin try
		insert into RejectedAccounts (service_reference_number, email_id, remarks) values (@Service_Reference_Number, @Email_Id, @Remarks);
		delete from RegisterAccount where Service_Reference_Number = @Service_Reference_Number;
	end try
	begin catch
		raiserror('Error occured while rejecting...', 15, 1);
	end catch
end

