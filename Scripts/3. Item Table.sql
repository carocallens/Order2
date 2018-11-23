use [Order2Db]
go

create table Items
(
	Item_ID int identity(1,1),
	Item_Name varchar(100) not null,
	Item_Description varchar (140),
	Item_Price money not null,
	Item_Amount int not null

	constraint Items_pk primary key (Item_ID)
)

insert into Items(Item_Name, Item_Description, Item_Price, Item_Amount)
values 
('PS4', 'GameConsole', 200, 50),
('Nintendo Switch', 'Portable GameConsole', 150, 49)