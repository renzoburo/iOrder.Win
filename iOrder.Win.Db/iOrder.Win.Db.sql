CREATE TABLE [dbo].[Users]
(
  UserID INT NOT NULL,
  Username VARCHAR(64) NOT NULL,
  Password VARCHAR(64) NOT NULL,
  EmailAddress VARCHAR(512) NOT NULL,
  FullName VARCHAR(512) NOT NULL,
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_Users PRIMARY KEY (UserID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT UQ_Users_Username UNIQUE (Username) WITH (IGNORE_DUP_KEY = OFF)
);

CREATE TABLE [dbo].[Roles]
(
  RoleID INT NOT NULL,
  RoleCode VARCHAR(32) NOT NULL,
  RoleName VARCHAR(64) NOT NULL,
  RoleDescription VARCHAR(512),
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_Roles PRIMARY KEY (RoleID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT UQ_Roles_RoleCode UNIQUE (RoleCode) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Users_Roles_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_Roles_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
);

CREATE TABLE [dbo].[UserRoles]
(
  UserRoleID INT NOT NULL,
  UserID INT NOT NULL,
  RoleID INT NOT NULL,
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_UserRoles PRIMARY KEY (UserRoleID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Users_UserRoles_UserID FOREIGN KEY (UserID) REFERENCES Users(UserID),
  CONSTRAINT FK_Roles_UserRoles_RoleID FOREIGN KEY (RoleID) REFERENCES Rs(RoleID),
  CONSTRAINT FK_Users_UserRoles_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_UserRoles_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
);

CREATE TABLE [dbo].[Suppliers]
(
  SupplierID INT NOT NULL,
  SupplierCode VARCHAR(32) NOT NULL,
  SupplierName VARCHAR(64) NOT NULL,
  SupplierDescription VARCHAR(512),
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_Suppliers PRIMARY KEY (SupplierID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT UQ_Suppliers_SupplierCode UNIQUE (SupplierCode) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Users_Suppliers_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_Suppliers_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
);

CREATE TABLE [dbo].[Products]
(
  ProductID INT NOT NULL,
  ProductCode VARCHAR(32) NOT NULL,
  ProducttName VARCHAR(128) NOT NULL,
  ProductDescription VARCHAR(2048),
  ImageUrl VARCHAR(1024),
  Price NUMERIC NOT NULL,
  SupplierID INT NOT NULL,
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_Products PRIMARY KEY (ProductID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT UQ_Products_ProductCode UNIQUE (ProductCode) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Suppliers_Products_SupplierID FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
  CONSTRAINT FK_Users_Products_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_Products_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
);

CREATE TABLE [dbo].[Orders]
(
  OrderID INT NOT NULL,
  OrderCode VARCHAR(32) NOT NULL,
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_Orders PRIMARY KEY (OrderID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT UQ_Orders_OrderCode UNIQUE (OrderCode) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Users_Orders_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_Orders_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
);

CREATE TABLE [dbo].[OrderDetails]
(
  OrderDetailID INT NOT NULL,
  OrderID INT NOT NULL,
  ProductID INT NOT NULL,
  Quantity INT NOT NULL,
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifedDate DATE NOT NULL,
  CONSTRAINT PK_OrderDetails PRIMARY KEY (OrderDetailID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Orders_OrderDetails_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  CONSTRAINT FK_Products_OrderDetails_ProductID FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
  CONSTRAINT FK_Users_OrderDetails_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_OrderDetails_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID), 
  CONSTRAINT [CK_OrderDetails_Quantity] CHECK (Quantity > 0)
);
