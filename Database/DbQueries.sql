CREATE DATABASE ChocolandHilsCafeDb;
USE ChocolandHilsCafeDb;


-- https://www.khanacademy.org/math/cc-third-grade-math/imp-measurement-and-data/imp-mass/v/intuition-for-grams#:~:text=.%20...%E2%80%9D-,To%20convert%20grams%20to%20kilograms%2C%20divide%20by%201%2C000.,30%2C000%20grams%20is%2030%20kilograms.

-- Employee management, attendance and payroll related tables:

-- if the employer decided to change/increase or decrease days on specific leave
-- just add new entry to retain the current records and deactivate the old one
CREATE TABLE IF NOT EXISTS LeaveTypes(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY, -- change to INT
    leaveType VARCHAR(50),
    numberOfDays INT,
    isActive BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM LeaveTypes;

SELECT * FROM LeaveTypes WHERE isDeleted=False AND isActive=true;

CREATE TABLE IF NOT EXISTS EmployeeShifts(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    shift VARCHAR(50),
    startTime DATETIME, -- we only need the time (ignore the date)
    endTime DATETIME, -- same with this column
    numberOfHrs DECIMAL(5,2), -- can be 7.5 hrs
    breakTime DATETIME,
    breakTimeHrs DECIMAL(5,2), -- 1 is hr, 0.5 is 30mins
    isActive BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
alter table EmployeeShifts
add column earlyTimeOut DATETIME; -- half day for first 4 or 6 hrs
alter table EmployeeShifts
add column lateTimeIn DATETIME; -- half day for last 4 or 6 hrs

SELECT * FROM EmployeeShifts;

CREATE TABLE IF NOT EXISTS EmployeeShiftDays(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    shiftId BIGINT NOT NULL,
    dayName CHAR(3),
    orderNum INT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (shiftId) REFERENCES EmployeeShifts (id)
)ENGINE=INNODB;

SELECT * FROM EmployeeShiftDays;

CREATE TABLE IF NOT EXISTS Holidays(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    holiday VARCHAR(255),
    dayNum INT,
    monthAbbr CHAR(3),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE Holidays
ADD COLUMN holidayType INT;
ALTER TABLE Holidays
ADD COLUMN monthNum INT;

SELECT * FROM Holidays;

CREATE TABLE IF NOT EXISTS Branches(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	branchName VARCHAR(255),
    tellNo VARCHAR(100),
    address VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM Branches;


CREATE TABLE IF NOT EXISTS NumberOfWorkingDaysInMonth(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	numberOfDays DECIMAL(9,2)
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS EmployeePositions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	title VARCHAR(255),
	-- salaryRate DECIMAL(9,2),
    -- halfMonthRate DECIMAL(9,2),
    dailyRate DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
-- May 6 update:
-- execute below queries to drop salaryRate and HalfMonthRate and add new column 
-- ALTER TABLE EmployeePositions
-- DROP COLUMN salaryRate;
-- ALTER TABLE EmployeePositions
-- DROP COLUMN halfMonthRate;
ALTER TABLE EmployeePositions
ADD COLUMN isSingleEmployee BOOLEAN DEFAULT False;
ALTER TABLE EmployeePositions
ADD COLUMN monthlyRate DECIMAL(9,2);


SELECT * FROM EmployeePositions;


CREATE TABLE IF NOT EXISTS Employees(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8) UNIQUE, -- 20210001, 02, 03 (will always change the first 4 numbers, based on current year
	firstName VARCHAR(100),
    lastName VARCHAR(100),
    middleName VARCHAR(100),
    address VARCHAR(255),
    birthdate DATE,
    mobileNumber VARCHAR(100),
    emailAddress VARCHAR(100),
    branchAssign VARCHAR(255),
    dateHire DATE NOT NULL,
    empNumYear CHAR(4),
    position VARCHAR(50),
    branchId BIGINT,
    positionId BIGINT,
    shiftId BIGINT NOT NULL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (shiftId) REFERENCES EmployeeShifts(id),
    FOREIGN KEY (branchId) REFERENCES Branches(id),
    FOREIGN KEY (positionId) REFERENCES EmployeePositions(id)
)ENGINE=INNODB;
ALTER TABLE Employees 
ADD COLUMN isQuit BOOLEAN DEFAULT False;
ALTER TABLE Employees 
ADD COLUMN quitDate DATE;
ALTER TABLE Employees
ADD COLUMN imageFileName VARCHAR(250);

-- Run this query to add this columns
-- or just drop the whole database to start again, so can set the foreign keys for these ids and ignore below alter queries
ALTER TABLE Employees 
ADD COLUMN branchId BIGINT;
ALTER TABLE Employees 
ADD COLUMN positionId BIGINT;

-- Run these queries to drop these old columns:
ALTER TABLE Employees
DROP COLUMN branchAssign;
ALTER TABLE Employees
DROP COLUMN position;


SELECT * FROM Employees;

-- ALTER TABLE Employees
-- DROP FOREIGN KEY employees_ibfk_1;

-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!! 
-- -- June 2, update DROP this table, we don't need this table, we will use the enum in our code to add new govt. agency, since each agency requires different computation for contribution
-- CREATE TABLE IF NOT EXISTS GovernmentAgencies(
-- 	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
--     govtAgency VARCHAR(255),
--     createdAt DATETIME DEFAULT NOW(),
--     updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
--     deletedAt DATETIME,
--     isDeleted BOOLEAN DEFAULT False
-- )ENGINE=INNODB;
DROP TABLE GovernmentAgencies;

-- -- execute these queries, we don't need these columns
-- ALTER TABLE GovernmentAgencies
-- DROP COLUMN erContribInPercent;
-- ALTER TABLE GovernmentAgencies
-- DROP COLUMN eeContribInPercent;

-- SELECT * FROM GovernmentAgencies;

-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!! -- June 2, update
-- CREATE TABLE IF NOT EXISTS EmployeeGovtIdCards(
-- 	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
--     employeeNumber CHAR(8),
--     govtAgencyId BIGINT NOT NULL,
--     employeeIdNumber VARCHAR(50) UNIQUE,
--     -- employeeContribution DECIMAL(5,2),
--     -- employerContribution DECIMAL(5,2),
--     createdAt DATETIME DEFAULT NOW(),
--     updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
--     deletedAt DATETIME,
--     isDeleted BOOLEAN DEFAULT False,
--     FOREIGN KEY(govtAgencyId) REFERENCES GovernmentAgencies(id)
-- )ENGINE=INNODB;
-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!!
DROP TABLE EmployeeGovtIdCards; -- DROP this table, we need to recreate this
-- create this new table
CREATE TABLE IF NOT EXISTS EmployeeGovtIdCards(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    govtAgencyEnumVal INT,
    employeeIdNumber VARCHAR(50),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM EmployeeGovtIdCards;

-- execute these queries, we don't need these columns
ALTER TABLE EmployeeGovtIdCards
DROP COLUMN employeeContribution;
ALTER TABLE EmployeeGovtIdCards
DROP COLUMN employerContribution;


-- DROP THIS TABLE, WE DON'T NEED THIS ANYMORE <----------------------------------------------------------------
drop table EmployeeSalaryRate;

SELECT * FROM EmployeeSalaryRate;


CREATE TABLE IF NOT EXISTS EmployeeLeaves(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    leaveId BIGINT NOT NULL,
    employeeNumber CHAR(8),
    reason TEXT,
    startDate DATE,
    endDate DATE,
    numberOfDays DECIMAL, -- 1=day, 0.5 = halfday
    remainingDays DECIMAL, -- can leave whole day or halfday
    currentYear INT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (leaveId) REFERENCES LeaveTypes(id)
)ENGINE=INNODB;
ALTER TABLE EmployeeLeaves
ADD COLUMN isPaid BOOLEAN DEFAULT false;
ALTER TABLE EmployeeLeaves
ADD COLUMN payslipId BIGINT DEFAULT 0; -- for easy retrieval of payslip data
ALTER TABLE EmployeeLeaves
ADD COLUMN DurationType INT;
ALTER TABLE EmployeeLeaves
ADD COLUMN DurationType INT;
-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!! -- June 5, update
ALTER TABLE EmployeeLeaves
ADD COLUMN approvalStatus INT DEFAULT 0;
ALTER TABLE EmployeeLeaves
ADD COLUMN employerRemarks VARCHAR(255);

SELECT * FROM EmployeeLeaves;

SELECT * 
FROM EmployeeLeaves AS EL
JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
WHERE EL.isDeleted=false AND EL.employeeNumber='20190001' AND EL.currentYear=2021 AND @EndDate AND EL.approvalStatus<>@Status
ORDER BY EL.id DESC;

CREATE TABLE IF NOT EXISTS WorkforceSchedules(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	workDate DATE,
    isDone BOOLEAN DEFAULT False,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM WorkforceSchedules;

CREATE TABLE IF NOT EXISTS EmployeeAttendance(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    shiftId BIGINT NOT NULL,
	workDate DATE NOT NULL,
    firstTimeIn DATETIME,
    firstTimeOut DATETIME,
    firstHalfHrs DECIMAL,-- in minutes
    firstHalfLateMins DECIMAL, -- put value upon time-in
    firstHalfUnderTimeMins DECIMAL, -- put value upon time-out
    secondTimeIn DATETIME,
    secondTimeOut DATETIME,
    secondHalfHrs DECIMAL, -- in minutes
    secondHalfLateMins DECIMAL,
    secondHalfUnderTimeMins DECIMAL,
    overTimeMins DECIMAL,
    isTimeOutProvided BOOLEAN DEFAULT false,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(shiftId) REFERENCES EmployeeShifts(id)
)ENGINE=INNODB;
ALTER TABLE EmployeeAttendance
ADD COLUMN lateTotalDeduction DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN underTimeTotalDeduction DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN overTimeTotalDeduction DECIMAL(9,2); -- need to rename this
ALTER TABLE EmployeeAttendance
ADD COLUMN totalDailySalary DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN isPaid BOOLEAN DEFAULT false;
ALTER TABLE EmployeeAttendance
ADD COLUMN payslipId BIGINT DEFAULT 0; -- for easy retrieval of payslip data

-- May 17 update
-- holiday is considered as overtime
ALTER TABLE EmployeeAttendance
ADD COLUMN isUserDayOffToday BOOLEAN DEFAULT False;
ALTER TABLE EmployeeAttendance
ADD COLUMN isHolidayToday BOOLEAN DEFAULT False;
ALTER TABLE EmployeeAttendance
ADD COLUMN holidayId LONG;
ALTER TABLE EmployeeAttendance
ADD COLUMN OverTimeHrlyRate DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN overTimeDailySalaryAdjustment DECIMAL(9,2);
ALTER TABLE EmployeeAttendance
ADD COLUMN overTimeType INT;

-- May 16 update
ALTER TABLE EmployeeAttendance
CHANGE overTimeTotalDeduction overTimeTotal DECIMAL(9,2);

SELECT * FROM EmployeeAttendance WHERE employeeNumber='20190001' AND workDate BETWEEN '2021-04-16' AND '2021-04-30';


-- possible enhancement:
-- add employee type that will use to add additional benefits
-- certain employees can have special benefits
CREATE TABLE IF NOT EXISTS EmployeeBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    benefitTitle VARCHAR(255),
    amount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM EmployeeBenefits;

-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!! -- June 5, update
CREATE TABLE IF NOT EXISTS SpecificEmployeeBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    employeeName VARCHAR(50),
    benefitTitle VARCHAR(255),
    amount DECIMAL(9,2),
    isPaid BOOLEAN DEFAULT False,
    paymentDate DATETIME,
    payslipId BIGINT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM SpecificEmployeeBenefits;

SELECT * FROM SpecificEmployeeBenefits WHERE createdAt BETWEEN '2021-06-05' AND '2021-06-05';

-- possible enhancement:
-- add employee type that will use to add conditional/special deduction
-- certain employees can have special deduction
CREATE TABLE IF NOT EXISTS EmployeeDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    deductionTitle VARCHAR(255),
    amount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;


-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!! -- June 5, update
CREATE TABLE IF NOT EXISTS SpecificEmployeeDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
    employeeName VARCHAR(50),
    deductionTitle VARCHAR(255),
    amount DECIMAL(9,2),
    isDeducted BOOLEAN DEFAULT False,
    deductedDate DATETIME,
    payslipId BIGINT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

select * from SpecificEmployeeDeductions;

CREATE TABLE IF NOT EXISTS EmployeeCashAdvanceRequests(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	employeeNumber CHAR(8),
    amount DECIMAL(9,2),
    needOnDate DATETIME,
    employeeRemarks VARCHAR(255),
    approvalStatus INT,
    employerRemarks VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE EmployeeCashAdvanceRequests
ADD COLUMN cashReleaseDate DATE;

SELECT * FROM EmployeeCashAdvanceRequests;


CREATE TABLE IF NOT EXISTS EmployeePayslips(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    employeeNumber CHAR(8),
	startShiftDate DATE,
    endShiftDate DATE,
    payDate DATE,
    -- salaryRate DECIMAL(9,2), -- we need to remove these columns
    -- halfMonthRate DECIMAL(9,2), --
    dailyRate DECIMAL(9,2),
    numOfDays INT,
    late VARCHAR(50),
    lateTotalDeduction DECIMAL(9,2),
    underTime VARCHAR(50),
    underTimeTotalDeduction DECIMAL(9,2),
    overTime VARCHAR(50),
    overTimeTotalRate DECIMAL(9,2),
    netBasicSalary DECIMAL(9,2),
    benefitsTotal DECIMAL(9,2),
    totalIncome DECIMAL(9,2),
    deductionTotal DECIMAL(9,2),
    netTakeHomePay DECIMAL (9,2),
    paydaySequence INT NOT NULL, -- 1 and 2 
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE EmployeePayslips
ADD COLUMN isCancel BOOLEAN DEFAULT False;

-- May 6, update:
-- execute below queries to drop columns
ALTER TABLE EmployeePayslips
DROP COLUMN salaryRate;
ALTER TABLE EmployeePayslips
DROP COLUMN halfMonthRate;
-- May 13 update:
ALTER TABLE EmployeePayslips
DROP COLUMN employerGovtContributionTotal;



SELECT * FROM EmployeePayslips WHERE isDeleted=false AND isCancel=false AND MONTH(paydate) = 5;

SELECT * FROM EmployeePayslips;
SELECT * FROM EmployeeAttendance;
SELECT * FROM EmployeeLeaves;

SELECT * FROM EmployeePayslips WHERE isDeleted=false AND payDate = '2021-03-24';

-- employee benefits inventory per payday/payslip
CREATE TABLE IF NOT EXISTS EmployeePayslipBenefits(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    payslipId BIGINT,
    employeeNumber CHAR(8),
	benefitTitle VARCHAR(255),
    amount DECIMAL(5,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(payslipId) REFERENCES EmployeePayslips(Id)
)ENGINE=INNODB;


-- May 17 updates:
ALTER TABLE EmployeePayslipBenefits
MODIFY COLUMN amount DECIMAL(9,2);

-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!! -- June 5, update
ALTER TABLE EmployeePayslipBenefits
ADD COLUMN displayType INT;
ALTER TABLE EmployeePayslipBenefits
DROP COLUMN multiplier;
ALTER TABLE EmployeePayslipBenefits
ADD COLUMN multiplier VARCHAR(50);


SELECT * FROM IngredientInventory;


select * from EmployeePayslipBenefits;

-- employee deductions inventory per payday/payslip
-- leave and absenses(Calculated from attendance) can be added on this
-- government contributions
CREATE TABLE IF NOT EXISTS EmployeePayslipDeductions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    payslipId BIGINT,
    employeeNumber CHAR(8),
	deductionTitle VARCHAR(255),
    amount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(payslipId) REFERENCES EmployeePayslips(Id)
)ENGINE=INNODB;
ALTER TABLE EmployeePayslipDeductions
ADD COLUMN employerGovtContributionAmount DECIMAL(9,2) DEFAULT 0;

-- May 17 updates:
ALTER TABLE EmployeePayslipDeductions
MODIFY COLUMN amount DECIMAL(9,2);


SELECT * FROM EmployeePayslipDeductions;

CREATE TABLE IF NOT EXISTS EmployeeGovernmentContributions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    payslipId BIGINT,
    employeeNumber CHAR(8),
	agency VARCHAR(255),
    govContributionEnumVal INT,
    employeeContribution DECIMAL(9,2),
    employerContribution DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(payslipId) REFERENCES EmployeePayslips(Id)
)ENGINE=INNODB;

-- -------------------------------------------------------------------------------------- !!!!!!!!!!!!!!!!!! -- June 2, update
ALTER TABLE EmployeeGovernmentContributions
ADD COLUMN IdNumber VARCHAR(50);

SELECT * FROM EmployeeGovernmentContributions;

-- --------------------------------------------------------------------------------------
-- User related tables:
-- --------------------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Roles(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    rolekey VARCHAR(50),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM Roles;


-- you can store employee number as userName
CREATE TABLE IF NOT EXISTS Users(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userName CHAR(20) UNIQUE,
    fullName VARCHAR(50),
	passwordSha512 VARCHAR(255),
    isActive BOOLEAN DEFAULT True,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM Users;

CREATE TABLE IF NOT EXISTS UserActivityLog(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userName CHAR(20),
    activity VARCHAR(255),
    createdAt DATETIME DEFAULT NOW()
)ENGINE=INNODB;

SELECT * FROM Users;


CREATE TABLE IF NOT EXISTS UserRoles(
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    userId BIGINT NOT NULL,
    roleId INT NOT NULL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (userId) REFERENCES Users(id),
    FOREIGN KEY (roleId) REFERENCES Roles(id)
)ENGINE=INNODB;


SELECT * FROM UserRoles;

-- testing data:
INSERT INTO Roles (rolekey) VALUES ("normal"), ("admin");


-- Password: Welcome2021
INSERT INTO Users (userName, fullName, passwordSha512)
VALUES ("admin", "Raniel", "5511F5AC0EDC25929F8CFE01485FFDEF12A83944BFB4708048C79869C22F17FF4F7CBD168146942F61E67756EB60C1E15DD4CC35596207ED626805199A805328");
SELECT * FROM Users;

INSERT INTO UserRoles (userId, roleId)
VALUES (1,2);

-- --------------------------------------------------------------------------------------
-- Inventory and POS related tables:
-- --------------------------------------------------------------------------------------



CREATE TABLE IF NOT EXISTS IngredientCategories(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	category VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS Ingredients(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    categoryId BIGINT NOT NULL,
	ingName VARCHAR(255),
    uom CHAR(3), -- kg(gram), L(ml), pcs(pc)
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(categoryId) REFERENCES IngredientCategories(id)
)ENGINE=INNODB;

SELECT * FROM Ingredients;



CREATE TABLE IF NOT EXISTS IngredientInventory(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	ingredientId BIGINT NOT NULL,
    initialQtyValue DECIMAL, -- in grams, ml, or pcs
    remainingQtyValue DECIMAL,
    unitCost DECIMAL(9,2), -- unit cost based on unit of measurement
    expirationDate DATE,
    isSoldOut BOOLEAN DEFAULT False,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id)
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS IngInventoryTransactions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	ingredientId BIGINT NOT NULL,
    transType INT, -- See StaticData.cs file under EntitiesShared Project
    qtyVal DECIMAL,
    unitCost DECIMAL(9,2),
    expirationDate DATE,
    userId BIGINT NOT NULL,
    remarks VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id),
    FOREIGN KEY(userId) REFERENCES Users(id)
)ENGINE=INNODB;


CREATE TABLE IF NOT EXISTS ProductCategories(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	prodCategory VARCHAR(255),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;


SELECT * FROM ProductCategories;

CREATE TABLE IF NOT EXISTS Products(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    barcodeLbl VARCHAR(250),
    categoryId BIGINT NOT NULL,
	prodName VARCHAR(255),
    pricePerOrder DECIMAL(9,2),
    imageFileName VARCHAR(250),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(categoryId) REFERENCES ProductCategories(id)
)ENGINE=INNODB;

SELECT * FROM Products;

-- Per order
CREATE TABLE IF NOT EXISTS ProductIngredients(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	productId BIGINT NOT NULL,
    ingredientId BIGINT NOT NULL,
    uom INT,
    qtyValue DECIMAL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(productId) REFERENCES Products(id),
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id)
)ENGINE=INNODB;

SELECT * FROM ProductIngredients; 

CREATE TABLE IF NOT EXISTS ComboMeals(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    barcodeLbl VARCHAR(250),
	title VARCHAR(255),
    price DECIMAL(9,2),
    imageFileName VARCHAR(250),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM ComboMeals;


CREATE TABLE IF NOT EXISTS ComboMealProducts(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	comboMealId BIGINT NOT NULL,
    productId BIGINT NOT NULL,
    quantity INT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(comboMealId) REFERENCES ComboMeals(id),
    FOREIGN KEY(productId) REFERENCES Products(id)
)ENGINE=INNODB;

select * from ComboMealProducts;


-- Point of sale tables:


CREATE TABLE IF NOT EXISTS StoreTables(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	numberOfTables INT,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;


SELECT * FROM StoreTables;


CREATE TABLE IF NOT EXISTS SalesTransactions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    transactionType INT, -- Dine-in or Take-out (Enum values)
	ticketNumber VARCHAR(100), -- generate after new transaction created
    customerName VARCHAR(255), -- provided upon initialization
    subTotalAmount DECIMAL(9,2),
    discountAmount DECIMAL(9,2), -- zero upon initialization
    discountIsPercentage BOOLEAN DEFAULT FALSE,
    discountPercent DECIMAL,
    totalAmount DECIMAL(9,2), -- zero upon initialization
    customerCashAmount DECIMAL(9,2), -- zero upon initialization
    customerChangeAmount DECIMAL(9,2), -- zero upon initialization
    customerDueAmount DECIMAL(9,2), -- zero upon initialization
    tableNumber INT, -- provided upon initialization
    transStatus INT, -- OnGoing, Paid or cancelled (Enum values)
    currentUser VARCHAR(255), -- upon initialization
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;
ALTER TABLE SalesTransactions
ADD COLUMN discountIsPercentage BOOLEAN DEFAULT FALSE;
ALTER TABLE SalesTransactions
ADD COLUMN discountPercent DECIMAL;
ALTER TABLE SalesTransactions
ADD COLUMN isCashOut BOOLEAN DEFAULT false;
ALTER TABLE SalesTransactions
ADD COLUMN TakeOutNumber INT;
ALTER TABLE SalesTransactions
ADD COLUMN IsCustomerDone BOOLEAN DEFAULT False;

SELECT * FROM SalesTransactions 
WHERE isDeleted=false AND transStatus=1 AND tableNumber >= 1;

SELECT * FROM SalesTransactions 

CREATE TABLE IF NOT EXISTS SalesTransactionProducts(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    salesTransId BIGINT NOT NULL,
	productId BIGINT NOT NULL,
    productCurrentPrice DECIMAL(9,2),
    qty INT,
    totalAmount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (salesTransId) REFERENCES SalesTransactions(id),
    FOREIGN KEY (productId) REFERENCES Products (id)
)ENGINE=INNODB;

DELETE FROM SalesTransactionProducts WHERE id> 0;

CREATE TABLE IF NOT EXISTS SalesTransactionComboMeals(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    salesTransId BIGINT NOT NULL,
	comboMealId BIGINT NOT NULL,
    comboMealCurrentPrice DECIMAL(9,2),
    qty INT,
    totalAmount DECIMAL(9,2),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY (salesTransId) REFERENCES SalesTransactions(id),
    FOREIGN KEY (comboMealId) REFERENCES ComboMeals (id)
)ENGINE=INNODB;


-- Sale Transaction's Product's Ingredient's Inventory deduction history :D
-- we just need to store the ingredients we used in our product and 
-- where inventory we deduct the required qty value(amount ex. 500ml of ingredient)
-- because in single ingredient, we can have multiple inventory records
CREATE TABLE IF NOT EXISTS SaleTranProdIngInvDeductionsRecords(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	saleTransProductId BIGINT NOT NULL,
    ingredientId BIGINT NOT NULL,
    ingredientInventoryId BIGINT NOT NULL,
    ingredientUOM INT,
    deductionSequence INT DEFAULT 0,
    usedUOM INT,
    deductedQtyValue DECIMAL,
    ingInvCurrentUnitCost DECIMAL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(saleTransProductId) REFERENCES SalesTransactionProducts(id),
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id),
    FOREIGN KEY(ingredientInventoryId) REFERENCES IngredientInventory(id)
)ENGINE=INNODB;
ALTER TABLE SaleTranProdIngInvDeductionsRecords
ADD COLUMN totalCost DECIMAL(9,2);

SELECT * FROM SaleTranProdIngInvDeductionsRecords;

CREATE TABLE IF NOT EXISTS SaleTranComboMealIngInvDeductionsRecords(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	saleTransComboMealId BIGINT NOT NULL,
    productId BIGINT NOT NULL,
    ingredientId BIGINT NOT NULL,
    ingredientInventoryId BIGINT NOT NULL,
    ingredientUOM INT,
    deductionSequence INT DEFAULT 0,
    usedUOM INT,
    deductedQtyValue DECIMAL,
    ingInvCurrentUnitCost DECIMAL,
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False,
    FOREIGN KEY(saleTransComboMealId) REFERENCES SalesTransactionComboMeals(id),
    FOREIGN KEY(productId) REFERENCES Products(id),
    FOREIGN KEY(ingredientId) REFERENCES Ingredients(id),
    FOREIGN KEY(ingredientInventoryId) REFERENCES IngredientInventory(id)
)ENGINE=INNODB;
ALTER TABLE SaleTranComboMealIngInvDeductionsRecords
ADD COLUMN totalCost DECIMAL(9,2);

SELECT * FROM SaleTranComboMealIngInvDeductionsRecords;

CREATE TABLE IF NOT EXISTS CashRegisterCashOutTransactions(
	id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    totalSales DECIMAL(9,2),
    cashOut DECIMAL(9,2),
	remainingCash DECIMAL(9,2),
    currentUser VARCHAR(100),
    createdAt DATETIME DEFAULT NOW(),
    updatedAt DATETIME DEFAULT NOW() ON UPDATE NOW(),
    deletedAt DATETIME,
    isDeleted BOOLEAN DEFAULT False
)ENGINE=INNODB;

SELECT * FROM CashRegisterCashOutTransactions;
SELECT * FROM CashRegisterCashOutTransactions WHERE isDeleted=false ORDER By id DESC LIMIT 1;
