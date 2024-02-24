CREATE TABLE [UserPermission] (
  [id] bigint PRIMARY KEY,
  [Role] nvarchar(255)
)
GO

CREATE TABLE [User] (
  [id] bigint PRIMARY KEY,
  [Permission_id] bigint,
  [Package_id] bigint,
  [IdentityCard] nvarchar(255),
  [Name] nvarchar(255),
  [Email] nvarchar(255),
  [Username] nvarchar(255),
  [Password] nvarchar(255),
  [Image] nvarchar(255),
  [Phone] integer,
  [Dob] date,
  [Address] nvarchar(255),
  [Gender] nvarchar(255),
  [RegisterDay] nvarchar(255),
  [Status] bit
)
GO

CREATE TABLE [Package] (
  [id] bigint PRIMARY KEY,
  [PackageName] nvarchar(255),
  [Package_Description] nvarchar(255),
  [StartDay] date,
  [EndDay] date,
  [Status] bit
)
GO

CREATE TABLE [Auction] (
  [id] bigint PRIMARY KEY,
  [Product_id] bigint,
  [StartDay] date,
  [AuctionDay] date,
  [Auction_Name] nvarchar(255),
  [Deposit_Money] double,
  [Status] bit
)
GO

CREATE TABLE [RoomRegistrations] (
  [id] bigint PRIMARY KEY,
  [User_id] bigint,
  [Auction_id] bigint,
  [Register_time] date
)
GO

CREATE TABLE [Product] (
  [id] bigint PRIMARY KEY,
  [ISBN] nvarchar(255),
  [User_id] bigint,
  [Product_Name] nvarchar(255),
  [Product_Description] nvarchar(255),
  [Image] nvarchar(255),
  [Product_Price] double,
  [Type] nvarchar(255),
  [Status] bit
)
GO

CREATE TABLE [Cart] (
  [id] bigint PRIMARY KEY,
  [User_id] bigint,
  [Product_id] bigint,
  [isSelected] bit
)
GO

CREATE TABLE [Order] (
  [id] bigint PRIMARY KEY,
  [User_id] bigint,
  [Date] date,
  [Total_Price] double
)
GO

CREATE TABLE [OrderItem] (
  [id] bigint PRIMARY KEY,
  [Order_id] bigint,
  [Product_id] bigint
)
GO

CREATE TABLE [Bill] (
  [id] bigint PRIMARY KEY,
  [Order_id] bigint,
  [Payment_Method] nvarchar(255),
  [Total_Price] double,
  [Status] bit
)
GO

CREATE TABLE [Bid] (
  [id] bigint PRIMARY KEY,
  [Auction_id] bigint,
  [User_id] bigint,
  [Bid] double,
  [Bid_time] date
)
GO

ALTER TABLE [Bid] ADD FOREIGN KEY ([Auction_id]) REFERENCES [Auction] ([id])
GO

ALTER TABLE [Bid] ADD FOREIGN KEY ([User_id]) REFERENCES [User] ([id])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([Permission_id]) REFERENCES [UserPermission] ([id])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([Package_id]) REFERENCES [Package] ([id])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([id]) REFERENCES [RoomRegistrations] ([User_id])
GO

ALTER TABLE [Auction] ADD FOREIGN KEY ([id]) REFERENCES [RoomRegistrations] ([Auction_id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([User_id]) REFERENCES [User] ([id])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([id]) REFERENCES [Cart] ([User_id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([id]) REFERENCES [Cart] ([Product_id])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([Order_id]) REFERENCES [Order] ([id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([id]) REFERENCES [Auction] ([Product_id])
GO

ALTER TABLE [Cart] ADD FOREIGN KEY ([Product_id]) REFERENCES [OrderItem] ([Product_id])
GO

ALTER TABLE [Order] ADD FOREIGN KEY ([id]) REFERENCES [Bill] ([Order_id])
GO
