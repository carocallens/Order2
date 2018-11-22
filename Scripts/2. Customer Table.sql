use [Order2Db]
go

create table Customers
(
	Customer_ID int identity(1,1),
	Customer_FirstName varchar(50) not null,
	Customer_LastName varchar(50) not null,
	Customer_Email varchar(100) not null,
	Customer_PhoneNumber varchar(70) not null,
	Customer_StreetName varchar(100) not null,
	Customer_HouseNumber varchar(10) not null,
	Customer_ZIP varchar(10) not null,
	Customer_City varchar(50) not null

	constraint Customers_pk primary key (Customer_ID)
)

insert into Customers(Customer_FirstName, Customer_LastName, Customer_Email, Customer_PhoneNumber, Customer_StreetName, Customer_HouseNumber, Customer_ZIP, Customer_City)
values
('Caroline', 'Callens', 'caroline.callens90@gmail.com','0478536637','Van Kerckhovenstraat', '14/201', '2800', 'Mechelen')