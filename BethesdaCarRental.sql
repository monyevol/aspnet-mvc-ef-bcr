USE master;
GO

CREATE DATABASE BethesdaCarRental2;
GO
USE BethesdaCarRental2;
GO

CREATE TABLE Cars
(
	CarID              INT IDENTITY(1, 1),
	TagNumber          VARCHAR(10),
	Make               VARCHAR(20),
	Model              VARCHAR(20),
	Passengers         VARCHAR(10),
	Category           VARCHAR(20),
	Condition          VARCHAR(20),
	AvailabilityStatus VARCHAR(20),
	CONSTRAINT PK_Cars PRIMARY KEY(CarID)
);
GO

CREATE TABLE Employees
(
	EmployeeID      INT IDENTITY(1, 1),
	EmployeeNumber  VARCHAR(10),
	FirstName       VARCHAR(20),
	LastName        VARCHAR(20),
	EmploymentTitle VARCHAR(50),
	CONSTRAINT PK_Employees PRIMARY KEY(EmployeeID)
);
GO
DROP TABLE RentalOrders;
GO
CREATE TABLE RentalOrders
(
	RentalOrderID        INT IDENTITY(1, 1),
	EmployeeID           INT,
	DriversLicenseNumber VARCHAR(20),
	FirstName            VARCHAR(20),
	LastName             VARCHAR(20),
	[Address]            VARCHAR(100),
	City                 VARCHAR(40),
	County               VARCHAR(40),
	[State]              VARCHAR(40),
	ZIPCode              VARCHAR(20),
	CarID                INT,
	CarCondition         VARCHAR(20),
	TankLevel            VARCHAR(20),
	MileageStart         VARCHAR(20),
	MileageEnd           VARCHAR(20),
	MileageTotal         VARCHAR(20),
	StartDate            VARCHAR(40),
	EndDate              VARCHAR(40),
	TotalDays            VARCHAR(10),
    RateApplied          VARCHAR(10),
    SubTotal             VARCHAR(10),
    TaxRate              VARCHAR(10),
    TaxAmount            VARCHAR(10),
    OrderTotal           VARCHAR(10),
	PaymentDate          VARCHAR(40),
	OrderStatus          VARCHAR(20),
	CONSTRAINT PK_RentalOrders PRIMARY KEY(RentalOrderID),
	CONSTRAINT FK_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_Cars FOREIGN KEY(CarID) REFERENCES Cars(CarID)
);
GO

/*
INSERT INTO Employees(EmployeeNumber, FirstName, LastName, EmploymentTitle)
VALUES(N'92735', N'Jeffrey',  N'Leucart',   N'General Manager'),
      (N'29268', N'Kathleen', N'Rawley',    N'Technician'),
      (N'73948', N'Allison',  N'Garlow',    N'Accounts Associate'),
      (N'40508', N'David',    N'Stillson',  N'Accounts Manager'),
      (N'24793', N'Michelle', N'Taylor',    N'Accounts Associate'),
      (N'20480', N'Peter',    N'Futterman', N'Accounts Associate'),
      (N'72084', N'Georgia',  N'Rosen',     N'Customer Service Representative'),
      (N'38408', N'Karen',    N'Blackney',  N'Accounts Associate');
GO
INSERT INTO Cars(TagNumber, Make, Model, Passengers, Category, Condition, AvailabilityStatus)
VALUES(N'M297304', N'Jeep',     N'Wrangler Sahara',   4, N'SUV',           N'Excellent',    N'Available'),
      (N'1AD8049', N'Dodge',    N'Charger SXT',       4, N'Standard',      N'Driveable',    N'Available'),
      (N'DFP924',  N'Toyota',   N'Sienna LE FWD',     8, N'Passenger Van', N'Driveable',    N'Available'),
      (N'GTH295',  N'Kia',      N'Rio LX',            4, N'Economy',       N'Excellent',    N'Available'),
      (N'2AL9485', N'Chrysler', N'200',               2, N'Compact',       N'Needs Repair', N'Being Serviced'),
      (N'BND927',  N'Ford',     N'Fiesta SE',         4, N'Economy',       N'Excellent',    N'Available'),
      (N'9KM8206', N'Honda',    N'Accord EX',         4, N'Standard',      N'Good',         N'Unknown'),
      (N'8AE9294', N'Lincoln',  N'MKT 3.5L',          4, N'Full Size',     N'Excellent',    N'Available'),
      (N'M280360', N'Toyota',   N'Rav4 LE',           4, N'SUV',           N'Excellent',    N'Being Serviced'),
      (N'5MD2084', N'Buick',    N'Enclave',           4, N'Mini Van',      N'Driveable',    N'Unknown'),
      (N'2AT9274', N'Ford',     N'Focus SF',          4, N'Compact',       N'Excellent',    N'Available'),
      (N'6AD8274', N'Mazda',    N'CX-9',              7, N'Mini Van',      N'Driveable',    N'Available'),
      (N'4AF9284', N'Ford',     N'F-150 Reg Cap 4X4', 2, N'Pickup Truck',  N'Driveable',    N'Available'),
      (N'ADG279',  N'GMC',      N'Acadia SLE',        5, N'SUV',           N'Excellent',    N'Available'),
      (N'8DN8604', N'Toyota',   N'Camry XSE',         4, N'Standard',      N'Excellent',    N'Available'),
      (N'4DP2731', N'Buick',    N'Lacrosse Avenir',   4, N'Full Size',     N'Other',        N'Being Serviced');
GO
*/