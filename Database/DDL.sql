CREATE TABLE Permission (
    Id int IDENTITY(1,1) NOT NULL,
    Name nvarchar(500) NULL,
    CONSTRAINT PK_Permission PRIMARY KEY CLUSTERED (Id ASC)
) ON PRIMARY
GO

CREATE TABLE AccountType (
    ID int IDENTITY(1,1) NOT NULL,
    TypeName nvarchar(50) NOT NULL,
    PRIMARY KEY CLUSTERED (ID ASC)
) ON PRIMARY
GO

CREATE TABLE AccountTypePermission (
    AccountTypeId int NULL,
    PermissionId int NULL,
    FOREIGN KEY (AccountTypeId) REFERENCES AccountType(ID),
    FOREIGN KEY (PermissionId) REFERENCES Permission(Id)
) ON PRIMARY
GO

CREATE TABLE Account (
    Id int IDENTITY(1,1) NOT NULL,
    UserName varchar(100) NOT NULL,
    DisplayName nvarchar(100) NOT NULL,
    Password varchar(500) NOT NULL,
    TypeID int NOT NULL,
    CONSTRAINT PK_Account PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT UQ_Account_UserName UNIQUE NONCLUSTERED (UserName ASC)
) ON PRIMARY
GO

CREATE TABLE Customer (
    CustomerId int IDENTITY(1,1) NOT NULL,
    CustomerName nvarchar(50) NULL,
    PhoneNumber nvarchar(20) NULL,
    DoB datetime NULL,
    Address nvarchar(500) NULL,
    CONSTRAINT PK_Customer PRIMARY KEY CLUSTERED (CustomerId ASC),
    CONSTRAINT UQ_Customer_PhoneNumber UNIQUE NONCLUSTERED (PhoneNumber ASC)
) ON PRIMARY
GO

CREATE TABLE Staff (
    StaffId int IDENTITY(1,1) NOT NULL,
    SurnameStaff nvarchar(50) NULL,
    NameStaff nvarchar(50) NULL,
    DoB datetime NULL,
    Sex nvarchar(50) NULL,
    Address nvarchar(50) NULL,
    RecruitmentDay datetime NULL,
    ShiftId int NULL,
    Reward decimal(18,0) NULL,
    JobId int NULL,
    PhoneNumber nvarchar(50) NULL,
    AccountID int NULL,
    CONSTRAINT PK_Staff PRIMARY KEY CLUSTERED (StaffId ASC),
    FOREIGN KEY (ShiftId) REFERENCES Shift(ShiftId),
    FOREIGN KEY (AccountID) REFERENCES Account(Id)
) ON PRIMARY
GO

CREATE TABLE Product (
    Id int IDENTITY(1,1) NOT NULL,
    Name nvarchar(500) NULL,
    Price decimal(18,0) NULL,
    Discount decimal(18,0) NULL,
    Category nvarchar(500) NULL,
    Quantity int NULL,
    Size nvarchar(500) NULL,
    Image nvarchar(2000) NULL,
    Description nvarchar(2000) NULL,
    CONSTRAINT PK_Product PRIMARY KEY CLUSTERED (Id ASC)
) ON PRIMARY
GO

CREATE TABLE Bill (
    ID int IDENTITY(1,1) NOT NULL,
    BusinessTime datetime NOT NULL,
    CustomerID int NOT NULL,
    StaffID int NULL,
    Discount decimal(18,0) NOT NULL,
    TotalPrice decimal(18,0) NULL,
    Status int NOT NULL,
    CONSTRAINT PK__Bill__3214EC278FA594A5 PRIMARY KEY CLUSTERED (ID ASC)
) ON PRIMARY
GO

CREATE TABLE BillInfo (
    ID int IDENTITY(1,1) NOT NULL,
    BillID int NOT NULL,
    ProductID int NOT NULL,
    Amount int NOT NULL,
    PRIMARY KEY CLUSTERED (ID ASC),
    FOREIGN KEY (BillID) REFERENCES Bill(ID)
) ON PRIMARY
GO

CREATE TABLE Shift (
    ShiftId int IDENTITY(1,1) NOT NULL,
    StartTime time(7) NULL,
    EndTime time(7) NULL,
    Code nvarchar(50) NULL,
    CONSTRAINT PK_Shift PRIMARY KEY CLUSTERED (ShiftId ASC)
) ON PRIMARY
GO

CREATE TABLE ShiftSchedule (
    ShiftId int NOT NULL,
    CustomerId int NULL,
    WorkDay datetime NULL,
    CONSTRAINT PK_ShiftSchedule PRIMARY KEY CLUSTERED (ShiftId ASC),
    FOREIGN KEY (ShiftId) REFERENCES Shift(ShiftId)
) ON PRIMARY
GO