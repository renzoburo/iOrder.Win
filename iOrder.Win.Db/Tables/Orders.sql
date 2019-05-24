CREATE TABLE [dbo].[Orders]
(
  OrderID INT NOT NULL IDENTITY(1,1),
  OrderCode VARCHAR(32) NOT NULL,
  CreatedBy INT NOT NULL,
  CreateDate DATE NOT NULL,
  ModifiedBy INT NOT NULL,
  ModifiedDate DATE NOT NULL,
  CONSTRAINT PK_Orders PRIMARY KEY (OrderID) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT UQ_Orders_OrderCode UNIQUE (OrderCode) WITH (IGNORE_DUP_KEY = OFF),
  CONSTRAINT FK_Users_Orders_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Users(UserID),
  CONSTRAINT FK_Users_Orders_ModifiedBy FOREIGN KEY (ModifiedBy) REFERENCES Users(UserID)
)
