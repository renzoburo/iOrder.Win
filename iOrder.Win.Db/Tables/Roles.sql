﻿CREATE TABLE [dbo].[Roles]
(
  RoleID INT NOT NULL IDENTITY(1,1),
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
)