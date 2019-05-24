CREATE TABLE [dbo].[Suppliers]
(
  SupplierID INT NOT NULL IDENTITY(1,1),
  SupplierCode INT NOT NULL,
  SupplierName VARCHAR(64) NOT NULL,
  SupplierDescription VARCHAR(512),
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_Supliers PRIMARY KEY (SupplierID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT UQ_Suppliers_SupplierCode UNIQUE (SupplierCode) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Users_Suppliers_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_Suppliers_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
)
