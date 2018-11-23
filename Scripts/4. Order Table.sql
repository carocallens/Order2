use [Order2Db]
go

create table Orders
(
	Order_ID int identity(1,1),
	Customer_ID int not null,
	Order_TotalPrice decimal

	constraint Orders_pk primary key (Order_ID),
	constraint Orders_Customers_fk foreign key (Customer_ID) references Customers(Customer_ID)
)

insert into Orders(Customer_ID)
values(1)


create table ItemGroups(
	ItemGroup_ID int identity(1,1),
	Order_ID int,
	Item_ID int not null,
	Item_Name varchar(50),
	Item_Price decimal,
	Item_Amount int not null,
	ItemGroup_ShippingDate date not null

	constraint ItemGroups_pk primary key (ItemGroup_ID),
	constraint ItemGroups_Orders_fk foreign key (Order_ID) references Orders(Order_ID),
	constraint ItemGroups_Items_fk foreign key (Item_ID) references Items(Item_ID)
)

insert into ItemGroups(Order_ID, Item_ID, Item_Name, Item_Price, Item_Amount, ItemGroup_ShippingDate)
values
			(1,
			1, 
			(select Items.Item_Name From Items Where Items.Item_ID = 1),
			(select Items.Item_Price From Items Where Items.Item_ID = 1), 
			2, 
			GetDate()),
			(1,
			2, 
			(select Items.Item_Name From Items Where Items.Item_ID = 2),
			(select Items.Item_Price From Items Where Items.Item_ID = 2), 
			3, 
			GetDate())


			select *
			from Orders
			where Order_ID = 1
