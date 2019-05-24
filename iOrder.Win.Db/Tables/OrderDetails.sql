CREATE TABLE [dbo].[OrderDetails]
(
  OrderDetailID INT NOT NULL IDENTITY(1,1),
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
)
