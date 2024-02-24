CREATE TABLE [UserPermission] (
  id BIGINT PRIMARY KEY,
  Role VARCHAR(255)
);

CREATE TABLE [User] (
  id BIGINT PRIMARY KEY,
  Permission_id BIGINT,
  Package_id BIGINT,
  IdentityCard VARCHAR(255),
  Name VARCHAR(255),
  Email VARCHAR(255),
  Username VARCHAR(255),
  Password VARCHAR(255),
  Image VARCHAR(255),
  Phone INT,
  Dob DATE,
  Address VARCHAR(255),
  Gender VARCHAR(255),
  RegisterDay VARCHAR(255),
  Status BIT
);

CREATE TABLE Package (
  id BIGINT PRIMARY KEY,
  PackageName VARCHAR(255),
  Package_Description VARCHAR(255),
  StartDay DATE,
  EndDay DATE,
  Status BIT
);

CREATE TABLE Auction (
  id BIGINT PRIMARY KEY,
  Product_id BIGINT,
  StartDay DATE,
  AuctionDay DATE,
  Auction_Name VARCHAR(255),
  Deposit_Money FLOAT,
  Status BIT
);

CREATE TABLE RoomRegistrations (
  id BIGINT PRIMARY KEY,
  User_id BIGINT,
  Auction_id BIGINT,
  Register_time DATE
);

CREATE TABLE Product (
  id BIGINT PRIMARY KEY,
  ISBN VARCHAR(255),
  User_id BIGINT,
  Product_Name VARCHAR(255),
  Product_Description VARCHAR(255),
  Image VARCHAR(255),
  Product_Price FLOAT,
  Type VARCHAR(255),
  Status BIT
);

CREATE TABLE Cart (
  id BIGINT PRIMARY KEY,
  User_id BIGINT,
  Product_id BIGINT,
  isSelected BIT
);

CREATE TABLE [Order] (
  id BIGINT PRIMARY KEY,
  User_id BIGINT,
  Date DATE,
  Total_Price FLOAT
);

CREATE TABLE OrderItem (
  id BIGINT PRIMARY KEY,
  Order_id BIGINT,
  Product_id BIGINT
);

CREATE TABLE Bill (
  id BIGINT PRIMARY KEY,
  Order_id BIGINT,
  Payment_Method VARCHAR(255),
  Total_Price FLOAT,
  Status BIT
);

CREATE TABLE Bid (
  id BIGINT PRIMARY KEY,
  Auction_id BIGINT,
  User_id BIGINT,
  Bid FLOAT,
  Bid_time DATE
);

ALTER TABLE [User] ADD FOREIGN KEY (Permission_id) REFERENCES UserPermission(id);
ALTER TABLE [User] ADD FOREIGN KEY (Package_id) REFERENCES Package(id);
ALTER TABLE RoomRegistrations ADD FOREIGN KEY (User_id) REFERENCES [User](id);
ALTER TABLE RoomRegistrations ADD FOREIGN KEY (Auction_id) REFERENCES Auction(id);
ALTER TABLE Product ADD FOREIGN KEY (User_id) REFERENCES [User](id);
ALTER TABLE Cart ADD FOREIGN KEY (User_id) REFERENCES [User](id);
ALTER TABLE Cart ADD FOREIGN KEY (Product_id) REFERENCES Product(id);
ALTER TABLE OrderItem ADD FOREIGN KEY (Order_id) REFERENCES [Order](id);
ALTER TABLE OrderItem ADD FOREIGN KEY (Product_id) REFERENCES Product(id);
ALTER TABLE Bill ADD FOREIGN KEY (Order_id) REFERENCES [Order](id);
ALTER TABLE Bid ADD FOREIGN KEY (Auction_id) REFERENCES Auction(id);
ALTER TABLE Bid ADD FOREIGN KEY (User_id) REFERENCES [User](id);
ALTER TABLE Auction ADD FOREIGN KEY (Product_id) REFERENCES Product(id);