SET IDENTITY_INSERT [Fulfillment].[Products] ON
INSERT INTO [Fulfillment].[Products] ([ProductID], [ProductCode], [ProducttName], [ProductDescription], [ImageUrl], [Price]) VALUES (1, N'GOW-001', N'God of War', N'Best game ever created', N'https://media.takealot.com/covers_tsins/54663372/54663372-1-pdpxl.jpg', CAST(899.00 AS Decimal(18, 2)))
INSERT INTO [Fulfillment].[Products] ([ProductID], [ProductCode], [ProducttName], [ProductDescription], [ImageUrl], [Price]) VALUES (2, N'PZ-001', N'Pizza', N'Don''t care for it much', N'C:\Users\chris\Pictures\223510_10150180868303270_6378149_n.jpg', CAST(109.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [Fulfillment].[Products] OFF
