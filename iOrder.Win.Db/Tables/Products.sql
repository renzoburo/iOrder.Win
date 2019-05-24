CREATE TABLE [dbo].[Products]
(
  ProductID INT NOT NULL IDENTITY(1,1),
  ProductCode VARCHAR(32) NOT NULL,
  ProducttName VARCHAR(128) NOT NULL,
  ProductDescription VARCHAR(2048),
  ImageUrl VARCHAR(1024),
  Price NUMERIC(10,2) NOT NULL,
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
)
