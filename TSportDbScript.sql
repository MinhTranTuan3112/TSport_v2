if exists (select [name] from sys.databases where [name] = N'TSportDb')

begin
  use master;
  drop database TSportDb;
end

go

create database TSportDb;
go

use TSportDb;

go
create table Account(
   Id int identity(1,1) not null,
   Code nvarchar(255),
   Username nvarchar(255),
   Email nvarchar(255) not null,
   [Password] nvarchar(255) not null,
   FirstName nvarchar(255),
   LastName nvarchar(255),
   Gender nvarchar(10),
   [Address] nvarchar(255),
   Phone nvarchar(50),
   Dob date,
   RefreshToken nvarchar(max),
   RefreshTokenExpiryTime datetime,
   [Role] nvarchar(50) not null,
   [Status] nvarchar(100),

   -- Keys
   primary key (Id)
);

create table [Order](
   Id int identity(1,1) not null,
   Code nvarchar(255),
   OrderDate datetime,
   [Status] nvarchar(100),
   Total decimal(10, 2),
   CreatedDate datetime not null default GETDATE(),
   CreatedAccountId int not null,
   ModifiedDate datetime null,
   ModifiedAccountId int null,

   -- Keys
   primary key (Id),
   foreign key (CreatedAccountId) references dbo.Account(Id),
   foreign key (ModifiedAccountId) references dbo.Account(Id),
);


create table Payment (
  Id int identity(1,1) not null,
  Code nvarchar(255),
  PaymentMethod nvarchar(255),
  PaymentName nvarchar(255),
  [Status] nvarchar(100) not null,
  OrderId int null,
  CreatedDate datetime not null default GETDATE(),
  CreatedAccountId int not null,
  ModifiedDate datetime null,
  ModifiedAccountId int null,

  -- Keys
  primary key(Id),
  foreign key (OrderId) references dbo.[Order](Id),
  foreign key (CreatedAccountId) references dbo.Account(Id),
  foreign key (ModifiedAccountId) references dbo.Account(Id),
);

create table Club(
  Id int identity(1,1) not null,
  Code nvarchar(255),
  [Name] nvarchar(255),
  LogoUrl nvarchar(max),
  [Status] nvarchar(100),
  CreatedDate datetime not null default GETDATE(),
  CreatedAccountId int not null,
  ModifiedDate datetime null,
  ModifiedAccountId int null,

  -- Keys
  primary key (Id),
  foreign key (CreatedAccountId) references dbo.Account(Id),
  foreign key (ModifiedAccountId) references dbo.Account(Id),
);

create table Player(
  Id int identity(1,1) not null,
  Code nvarchar(255),
  [Name] nvarchar(255),
  [Status] nvarchar(100),
  ClubId int not null,
  CreatedDate datetime not null default GETDATE(),
  CreatedAccountId int not null,
  ModifiedDate datetime null,
  ModifiedAccountId int null,


  -- Keys
  primary key (Id),
  foreign key (CreatedAccountId) references dbo.Account(Id),
  foreign key (ModifiedAccountId) references dbo.Account(Id),
  foreign key (ClubId) references dbo.Club(Id)
);

create table Season(
  Id int identity(1,1) not null,
  Code nvarchar(255),
  [Name] nvarchar(255),
  ClubId int null,
  CreatedDate datetime not null default GETDATE(),
  CreatedAccountId int not null,
  ModifiedDate datetime null,
  ModifiedAccountId int null,

  -- Keys
  primary key (Id),
  foreign key (ClubId) references dbo.Club(Id),
  foreign key (CreatedAccountId) references dbo.Account(Id),
  foreign key (ModifiedAccountId) references dbo.Account(Id),
);

create table SeasonPlayer(
  Id int identity(1,1) not null,
  SeasonId int not null,
  PlayerId int not null

  -- Keys
  primary key (Id),
  foreign key (SeasonId) references dbo.Season(Id),
  foreign key (PlayerId) references dbo.Player(Id)
);

create table ShirtEdition (
   Id int identity(1,1) not null,
   Code nvarchar(255),
   Size nvarchar(10),
   HasSignature bit,
   Price decimal(10, 2),
   Color nvarchar(255),
   [Status] nvarchar(100),
   Origin nvarchar(255),
   Material nvarchar(255),
   SeasonId int not null,
   CreatedDate datetime not null default GETDATE(),
   CreatedAccountId int not null,
   ModifiedDate datetime null,
   ModifiedAccountId int null,

   -- Keys
   primary key (Id),
   foreign key (SeasonId) references dbo.Season(Id),	
   foreign key (CreatedAccountId) references dbo.Account(Id),
   foreign key (ModifiedAccountId) references dbo.Account(Id)
);

create table Shirt(
  Id int identity(1,1) not null,
  Code nvarchar(255),
  [Description] nvarchar(255),
  [Status] nvarchar(100),
  ShirtEditionId int null,
  SeasonPlayerId int null,
  CreatedDate datetime not null default GETDATE(),
  CreatedAccountId int not null,
  ModifiedDate datetime null,
  ModifiedAccountId int null,

  -- Keys
  primary key (Id),
  foreign key (CreatedAccountId) references dbo.Account(Id),
  foreign key (ModifiedAccountId) references dbo.Account(Id),
  foreign key (ShirtEditionId) references dbo.ShirtEdition(Id),
  foreign key (SeasonPlayerId) references dbo.SeasonPlayer(Id)
);

create table OrderDetail(
  OrderId int not null,
  ShirtId int not null,
  Code nvarchar(255),
  Subtotal decimal(10,2),
  Quantity int,
  [Status] nvarchar(100),

  -- Keys
  primary key (OrderId, ShirtId),
  foreign key (OrderId) references dbo.[Order](Id),
  foreign key (ShirtId) references dbo.Shirt(Id)
);

---- Insert data into Account table
--INSERT INTO Account (Id, Code, Username, Email, [Password], FirstName, LastName, Gender, [Address], Phone, Dob, [Role], [Status])
--VALUES
--  (1, 'ACC001', 'user1', 'user1@example.com', 'Password123!', 'John', 'Doe', 'Male', '123 Main St, Anytown USA', '555-1234', '1990-01-01', 'Admin', 'Active'),
--  (2, 'ACC002', 'user2', 'user2@example.com', 'Password456!', 'Jane', 'Doe', 'Female', '456 Oak Rd, Anytown USA', '555-5678', '1985-06-15', 'Customer', 'Active'),
--  (3, 'ACC003', 'user3', 'user3@example.com', 'Password789!', 'Bob', 'Smith', 'Male', '789 Elm St, Anytown USA', '555-9012', '1992-11-30', 'Customer', 'Inactive');

---- Insert data into Club table
--INSERT INTO Club (Id, Code, [Name], LogoUrl, [Status], CreatedAccountId)
--VALUES
--  (1, 'CLB001', 'Real Madrid', 'https://upload.wikimedia.org/wikipedia/en/thumb/5/56/Real_Madrid_CF.svg/1200px-Real_Madrid_CF.svg.png', 'Active', 1),
--  (2, 'CLB002', 'Barcelona', 'https://upload.wikimedia.org/wikipedia/vi/thumb/9/91/FC_Barcelona_logo.svg/220px-FC_Barcelona_logo.svg.png', 'Active', 1),
--  (3, 'CLB003', 'Manchester United', 'https://upload.wikimedia.org/wikipedia/vi/a/a1/Man_Utd_FC_.svg', 'Active', 1);

---- Insert data into Player table
--INSERT INTO Player (Id, Code, [Name], [Status], ClubId, CreatedAccountId)
--VALUES
--  (1, 'PLY001', 'Lionel Messi', 'Active', 2, 1),
--  (2, 'PLY002', 'Cristiano Ronaldo', 'Active', 1, 1),
--  (3, 'PLY003', 'Neymar', 'Active', 2, 1),
--  (4, 'PLY004', 'Kylian Mbapp�', 'Active', 2, 1),
--  (5, 'PLY005', 'Robert Lewandowski', 'Active', 2, 1);

---- Insert data into Season table
--INSERT INTO Season (Id, Code, [Name], ClubId, CreatedAccountId)
--VALUES
--  (1, 'SES001', '2022/2023', 1, 1),
--  (2, 'SES002', '2021/2022', 1, 1),
--  (3, 'SES003', '2022/2023', 2, 1),
--  (4, 'SES004', '2021/2022', 2, 1);

---- Insert data into SeasonPlayer table
--INSERT INTO SeasonPlayer (Id, SeasonId, PlayerId)
--VALUES
--  (1, 1, 2),
--  (2, 1, 3),
--  (3, 3, 1),
--  (4, 3, 4),
--  (5, 3, 5);

---- Insert data into ShirtEdition table
--INSERT INTO ShirtEdition (Id, Code, Size, HasSignature, Price, Color, [Status], Origin, Material, SeasonId, CreatedAccountId)
--VALUES
--  (1, 'SE001', 'S', 0, 79.99, 'Red', 'Active', 'Made in China', 'Cotton', 1, 1),
--  (2, 'SE002', 'M', 0, 79.99, 'Red', 'Active', 'Made in China', 'Cotton', 1, 1),
--  (3, 'SE003', 'L', 0, 79.99, 'Red', 'Active', 'Made in China', 'Cotton', 1, 1),
--  (4, 'SE004', 'XL', 0, 79.99, 'Red', 'Active', 'Made in China', 'Cotton', 1, 1),
--  (5, 'SE005', 'S', 1, 99.99, 'Blue', 'Active', 'Made in Italy', 'Cotton', 3, 1),
--  (6, 'SE006', 'M', 1, 99.99, 'Blue', 'Active', 'Made in Italy', 'Cotton', 3, 1),
--  (7, 'SE007', 'L', 1, 99.99, 'Blue', 'Active', 'Made in Italy', 'Cotton', 3, 1),
--  (8, 'SE008', 'XL', 1, 99.99, 'Blue', 'Active', 'Made in Italy', 'Cotton', 3, 1);

---- Insert data into Shirt table
--INSERT INTO Shirt (Id, Code, [Description], [Status], ShirtEditionId, SeasonPlayerId, CreatedAccountId)
--VALUES
--  (1, 'SRT001', 'Real Madrid Home Jersey', 'Active', 1, 1, 1),
--  (2, 'SRT002', 'Real Madrid Home Jersey', 'Active', 2, 1, 1),
--  (3, 'SRT003', 'Real Madrid Home Jersey', 'Active', 3, 1, 1),
--  (4, 'SRT004', 'Real Madrid Home Jersey', 'Active', 4, 1, 1),
--  (5, 'SRT005', 'Barcelona Home Jersey', 'Active', 5, 3, 1),
--  (6, 'SRT006', 'Barcelona Home Jersey', 'Active', 6, 3, 1),
--  (7, 'SRT007', 'Barcelona Home Jersey', 'Active', 7, 3, 1),
--  (8, 'SRT008', 'Barcelona Home Jersey', 'Active', 8, 3, 1);

---- Insert data into Order table
--INSERT INTO [Order] (Id, Code, OrderDate, [Status], Total, CreatedAccountId)
--VALUES
--  (1, 'ORD001', '2023-04-01 10:30:00', 'Processed', 159.98, 2),
--  (2, 'ORD002', '2023-04-15 15:45:00', 'Shipped', 199.98, 2),
--  (3, 'ORD003', '2023-05-01 12:00:00', 'Pending', 99.99, 1);

---- Insert data into Payment table
--INSERT INTO Payment (Id, Code, PaymentMethod, PaymentName, [Status], OrderId, CreatedAccountId)
--VALUES
--  (1, 'PAY001', 'Credit Card', 'Visa ending in 1234', 'Paid', 1, 2),
--  (2, 'PAY002', 'PayPal', 'user2@example.com', 'Paid', 2, 2),
--  (3, 'PAY003', 'Credit Card', 'Mastercard ending in 5678', 'Pending', 3, 1);

---- Insert data into OrderDetail table
--INSERT INTO OrderDetail (OrderId, ShirtId, Code, Subtotal, Quantity, [Status])
--VALUES
--  (1, 1, 'OD001', 79.99, 1, 'Fulfilled'),
--  (1, 2, 'OD002', 79.99, 1, 'Fulfilled'),
--  (2, 5, 'OD003', 99.99, 1, 'Fulfilled'),
--  (2, 6, 'OD004', 99.99, 1, 'Fulfilled'),
--  (3, 7, 'OD005', 99.99, 1, 'Pending');

go