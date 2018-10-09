/*
Created		13/03/2018
Modified	13/03/2018
Project		Cay Canh NT
Model		SHOP
Company		Thuy's Company
Author		Pham Vo Ngoc Thuy
Version		1.0.1
Database	MS SQL 2012
*/
create database CAYCANHNT
go
use CAYCANHNT
go

Create table [USERS]
(
	[ID_USERS] int not null identity primary key,
	[USERNAME] Varchar(30) NULL,
	[PASSWORD] Varchar(20) NULL,
	[NAME] Nvarchar(50) NULL,
	[ADDRESS] Nvarchar(50) NULL,
	[EMAIL] Varchar(50) NULL,
	[PHONE] Varchar(12) NULL,
	[PERMISSION] Integer NULL,
	[META] Varchar(50) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer NULL
) 
go

Create table [PRODUCTS]
(
	[ID_PRO] int not null identity primary key,
	[NAME_PRO] Nvarchar(50) NULL,
	[NUMS] Integer NULL,
	[PRICE] Decimal(18,0) NULL,
	[DETAIL] Ntext NULL,
	[IMG1] Varchar(255) NULL,
	[IMG2] Varchar(255) NULL,
	[IMG3] Varchar(255) NULL,
	[META] Varchar(255) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer NULL,
	[ID_CAT] int
) 
go

Create table [CATOLOGY]
(
	[ID_CAT] int not null identity primary key,
	[NAME_CAT] Nvarchar(50) NULL,
	[META] Varchar(255) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer NULL
) 
go

Create table [MENU]
(
	[ID_MENU] int not null identity primary key,
	[TITLE] Nvarchar(50) NULL,
	[DATEBEGIN] Smalldatetime NULL,
	[META] Varchar(255) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer  NULL
) 
go

Create table [SLIDER]
(
	[ID_SLIDE] int not null identity primary key,
	[TITLE] Nvarchar(50) NULL,
	[IMG] Varchar(255) NULL,
	[DATEBEGIN] Smalldatetime NULL,
	[META] Varchar(255) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer NULL
) 
go

Create table [CART]
(
	[ID_CART] int not null identity primary key,
	[DATEBEGIN] Smalldatetime NULL,
	[META] Varchar(255) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer NULL,
	[ID_USERS] int
) 
go

Create table [BLOG]
(
	[ID_BLOG] int not null identity primary key,
	[TITLE] Nvarchar(50) NULL,
	[IMG] Varchar(255) NULL,
	[DETAIL] Ntext NULL,
	[DATEBEGIN] Smalldatetime NULL,
	[META] Varchar(255) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer NULL,
	[ID_USERS] int
) 
go

Create table [CART_DETAIL]
(
	[ID_CD] int not null identity primary key,
	[SOLD_NUM] Integer NULL,
	[META] Varchar(255) NULL,
	[ORDER] Integer NULL,
	[LINK] Nvarchar(255) NULL,
	[HIDE] Integer NULL,
	[ID_CART] int,
	[ID_PRO] int
) 
go


Alter table [BLOG] add  foreign key([ID_USERS]) references [USERS] ([ID_USERS])  on update no action on delete no action 
go
Alter table [CART] add  foreign key([ID_USERS]) references [USERS] ([ID_USERS])  on update no action on delete no action 
go
Alter table [CART_DETAIL] add  foreign key([ID_PRO]) references [PRODUCTS] ([ID_PRO])  on update no action on delete no action 
go
Alter table [PRODUCTS] add  foreign key([ID_CAT]) references [CATOLOGY] ([ID_CAT])  on update no action on delete no action 
go
Alter table [CART_DETAIL] add  foreign key([ID_CART]) references [CART] ([ID_CART])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


