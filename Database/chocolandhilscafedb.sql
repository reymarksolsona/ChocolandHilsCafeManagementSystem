-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 02, 2023 at 08:06 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `chocolandhilscafedb`
--

-- --------------------------------------------------------

--
-- Table structure for table `branches`
--

CREATE TABLE `branches` (
  `id` bigint(20) NOT NULL,
  `branchName` varchar(255) DEFAULT NULL,
  `tellNo` varchar(100) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `branches`
--

INSERT INTO `branches` (`id`, `branchName`, `tellNo`, `address`, `createdAt`, `updatedAt`, `deletedAt`, `isDeleted`) VALUES
(1, 'Nabunturan', 'asdfghjklzxc', 'Nabunturan, Davao de Oro', '2023-08-10 18:35:47', '2023-08-10 18:35:47', '0001-01-01 00:00:00', 0);

-- --------------------------------------------------------

--
-- Table structure for table `cashregistercashouttransactions`
--

CREATE TABLE `cashregistercashouttransactions` (
  `id` bigint(20) NOT NULL,
  `totalSales` decimal(9,2) DEFAULT NULL,
  `cashOut` decimal(9,2) DEFAULT NULL,
  `remainingCash` decimal(9,2) DEFAULT NULL,
  `currentUser` varchar(100) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `combomealproducts`
--

CREATE TABLE `combomealproducts` (
  `id` bigint(20) NOT NULL,
  `comboMealId` bigint(20) NOT NULL,
  `productId` bigint(20) NOT NULL,
  `quantity` int(11) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `combomeals`
--

CREATE TABLE `combomeals` (
  `id` bigint(20) NOT NULL,
  `barcodeLbl` varchar(250) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `price` decimal(9,2) DEFAULT NULL,
  `imageFileName` varchar(250) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeeattendance`
--

CREATE TABLE `employeeattendance` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `shiftId` bigint(20) NOT NULL,
  `workDate` date NOT NULL,
  `firstTimeIn` datetime DEFAULT NULL,
  `firstTimeOut` datetime DEFAULT NULL,
  `firstHalfHrs` decimal(10,0) DEFAULT NULL,
  `firstHalfLateMins` decimal(10,0) DEFAULT NULL,
  `firstHalfUnderTimeMins` decimal(10,0) DEFAULT NULL,
  `secondTimeIn` datetime DEFAULT NULL,
  `secondTimeOut` datetime DEFAULT NULL,
  `secondHalfHrs` decimal(10,0) DEFAULT NULL,
  `secondHalfLateMins` decimal(10,0) DEFAULT NULL,
  `secondHalfUnderTimeMins` decimal(10,0) DEFAULT NULL,
  `overTimeMins` decimal(10,0) DEFAULT NULL,
  `isTimeOutProvided` tinyint(1) DEFAULT 0,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `lateTotalDeduction` decimal(9,2) DEFAULT NULL,
  `underTimeTotalDeduction` decimal(9,2) DEFAULT NULL,
  `overTimeTotal` decimal(9,2) DEFAULT NULL,
  `totalDailySalary` decimal(9,2) DEFAULT NULL,
  `isPaid` tinyint(1) DEFAULT 0,
  `payslipId` bigint(20) DEFAULT 0,
  `isUserDayOffToday` tinyint(1) DEFAULT 0,
  `isHolidayToday` tinyint(1) DEFAULT 0,
  `holidayId` mediumtext DEFAULT NULL,
  `OverTimeHrlyRate` decimal(9,2) DEFAULT NULL,
  `overTimeDailySalaryAdjustment` decimal(9,2) DEFAULT NULL,
  `overTimeType` int(11) DEFAULT NULL,
  `overTimeTotalDeduction` decimal(9,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeebenefits`
--

CREATE TABLE `employeebenefits` (
  `id` bigint(20) NOT NULL,
  `benefitTitle` varchar(255) DEFAULT NULL,
  `amount` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeecashadvancerequests`
--

CREATE TABLE `employeecashadvancerequests` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `amount` decimal(9,2) DEFAULT NULL,
  `needOnDate` datetime DEFAULT NULL,
  `employeeRemarks` varchar(255) DEFAULT NULL,
  `approvalStatus` int(11) DEFAULT NULL,
  `employerRemarks` varchar(255) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `cashReleaseDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeedeductions`
--

CREATE TABLE `employeedeductions` (
  `id` bigint(20) NOT NULL,
  `deductionTitle` varchar(255) DEFAULT NULL,
  `amount` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeegovernmentcontributions`
--

CREATE TABLE `employeegovernmentcontributions` (
  `id` bigint(20) NOT NULL,
  `payslipId` bigint(20) DEFAULT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `agency` varchar(255) DEFAULT NULL,
  `govContributionEnumVal` int(11) DEFAULT NULL,
  `employeeContribution` decimal(9,2) DEFAULT NULL,
  `employerContribution` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeegovtidcards`
--

CREATE TABLE `employeegovtidcards` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `govtAgencyEnumVal` int(11) DEFAULT NULL,
  `employeeIdNumber` varchar(50) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employeegovtidcards`
--

INSERT INTO `employeegovtidcards` (`id`, `employeeNumber`, `govtAgencyEnumVal`, `employeeIdNumber`, `createdAt`, `updatedAt`, `deletedAt`, `isDeleted`) VALUES
(1, '20230001', 0, '12345678911', '2023-08-10 18:43:06', '2023-08-10 18:43:06', '2023-09-25 11:55:53', 1),
(2, '20230001', 1, '12345678911122', '2023-08-10 18:44:08', '2023-08-10 18:44:08', '2023-09-25 11:55:50', 1),
(3, '20230001', 2, '8uhujkjkjkj', '2023-08-10 18:45:01', '2023-08-10 18:45:01', '2023-09-25 11:55:45', 1),
(4, '20230001', 0, '23123', '2023-09-25 03:54:16', '2023-09-25 03:54:16', '0001-01-01 00:00:00', 0),
(5, '20230001', 1, '321312', '2023-09-25 03:54:24', '2023-09-25 03:54:24', '0001-01-01 00:00:00', 0),
(6, '20230001', 2, '87654', '2023-09-25 03:54:32', '2023-09-25 03:54:32', '0001-01-01 00:00:00', 0);

-- --------------------------------------------------------

--
-- Table structure for table `employeeleaves`
--

CREATE TABLE `employeeleaves` (
  `id` bigint(20) NOT NULL,
  `leaveId` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `reason` text DEFAULT NULL,
  `startDate` date DEFAULT NULL,
  `endDate` date DEFAULT NULL,
  `numberOfDays` decimal(10,0) DEFAULT NULL,
  `remainingDays` decimal(10,0) DEFAULT NULL,
  `currentYear` int(11) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `isPaid` tinyint(1) DEFAULT 0,
  `payslipId` bigint(20) DEFAULT 0,
  `DurationType` int(11) DEFAULT NULL,
  `approvalStatus` int(11) DEFAULT 0,
  `employerRemarks` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeepayslipbenefits`
--

CREATE TABLE `employeepayslipbenefits` (
  `id` bigint(20) NOT NULL,
  `payslipId` bigint(20) DEFAULT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `benefitTitle` varchar(255) DEFAULT NULL,
  `amount` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `displayType` int(11) DEFAULT NULL,
  `multiplier` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeepayslipdeductions`
--

CREATE TABLE `employeepayslipdeductions` (
  `id` bigint(20) NOT NULL,
  `payslipId` bigint(20) DEFAULT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `deductionTitle` varchar(255) DEFAULT NULL,
  `amount` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `employerGovtContributionAmount` decimal(9,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeepayslips`
--

CREATE TABLE `employeepayslips` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `startShiftDate` date DEFAULT NULL,
  `endShiftDate` date DEFAULT NULL,
  `payDate` date DEFAULT NULL,
  `dailyRate` decimal(9,2) DEFAULT NULL,
  `numOfDays` int(11) DEFAULT NULL,
  `late` varchar(50) DEFAULT NULL,
  `lateTotalDeduction` decimal(9,2) DEFAULT NULL,
  `underTime` varchar(50) DEFAULT NULL,
  `underTimeTotalDeduction` decimal(9,2) DEFAULT NULL,
  `overTime` varchar(50) DEFAULT NULL,
  `overTimeTotalRate` decimal(9,2) DEFAULT NULL,
  `netBasicSalary` decimal(9,2) DEFAULT NULL,
  `benefitsTotal` decimal(9,2) DEFAULT NULL,
  `totalIncome` decimal(9,2) DEFAULT NULL,
  `deductionTotal` decimal(9,2) DEFAULT NULL,
  `netTakeHomePay` decimal(9,2) DEFAULT NULL,
  `paydaySequence` int(11) NOT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `isCancel` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeepositions`
--

CREATE TABLE `employeepositions` (
  `id` bigint(20) NOT NULL,
  `title` varchar(255) DEFAULT NULL,
  `dailyRate` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `isSingleEmployee` tinyint(1) DEFAULT 0,
  `monthlyRate` decimal(9,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employeepositions`
--

INSERT INTO `employeepositions` (`id`, `title`, `dailyRate`, `createdAt`, `updatedAt`, `deletedAt`, `isDeleted`, `isSingleEmployee`, `monthlyRate`) VALUES
(1, 'Cashier', 476.19, '2023-08-10 18:38:12', '2023-08-10 18:38:12', '2023-08-11 02:38:37', 1, 1, 10000.00);

-- --------------------------------------------------------

--
-- Table structure for table `employeepositionshift`
--

CREATE TABLE `employeepositionshift` (
  `id` int(11) NOT NULL,
  `employeeId` bigint(11) NOT NULL,
  `positionId` bigint(11) NOT NULL,
  `shiftId` bigint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `firstName` varchar(100) DEFAULT NULL,
  `lastName` varchar(100) DEFAULT NULL,
  `middleName` varchar(100) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `mobileNumber` varchar(100) DEFAULT NULL,
  `emailAddress` varchar(100) DEFAULT NULL,
  `dateHire` date NOT NULL,
  `empNumYear` char(4) DEFAULT NULL,
  `branchId` bigint(20) DEFAULT NULL,
  `employeepositionshiftId` bigint(20) NOT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `isQuit` tinyint(1) DEFAULT 0,
  `quitDate` date DEFAULT NULL,
  `imageFileName` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeeshiftdays`
--

CREATE TABLE `employeeshiftdays` (
  `id` bigint(20) NOT NULL,
  `shiftId` bigint(20) NOT NULL,
  `dayName` char(3) DEFAULT NULL,
  `orderNum` int(11) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `employeeshifts`
--

CREATE TABLE `employeeshifts` (
  `id` bigint(20) NOT NULL,
  `shift` varchar(50) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  `numberOfHrs` decimal(5,2) DEFAULT NULL,
  `breakTime` datetime DEFAULT NULL,
  `breakTimeHrs` decimal(5,2) DEFAULT NULL,
  `isActive` tinyint(1) DEFAULT 1,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `earlyTimeOut` datetime DEFAULT NULL,
  `lateTimeIn` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `holidays`
--

CREATE TABLE `holidays` (
  `id` bigint(20) NOT NULL,
  `holiday` varchar(255) DEFAULT NULL,
  `dayNum` int(11) DEFAULT NULL,
  `monthAbbr` char(3) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `holidayType` int(11) DEFAULT NULL,
  `monthNum` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `holidays`
--

INSERT INTO `holidays` (`id`, `holiday`, `dayNum`, `monthAbbr`, `createdAt`, `updatedAt`, `deletedAt`, `isDeleted`, `holidayType`, `monthNum`) VALUES
(1, 'Christmas', 25, 'Dec', '2023-08-10 18:47:54', '2023-08-10 18:47:54', '0001-01-01 00:00:00', 0, 1, 12);

-- --------------------------------------------------------

--
-- Table structure for table `inginventorytransactions`
--

CREATE TABLE `inginventorytransactions` (
  `id` bigint(20) NOT NULL,
  `ingredientId` bigint(20) NOT NULL,
  `transType` int(11) DEFAULT NULL,
  `qtyVal` decimal(10,0) DEFAULT NULL,
  `unitCost` decimal(9,2) DEFAULT NULL,
  `expirationDate` date DEFAULT NULL,
  `userId` bigint(20) NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ingredientcategories`
--

CREATE TABLE `ingredientcategories` (
  `id` bigint(20) NOT NULL,
  `category` varchar(255) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ingredientinventory`
--

CREATE TABLE `ingredientinventory` (
  `id` bigint(20) NOT NULL,
  `ingredientId` bigint(20) NOT NULL,
  `initialQtyValue` decimal(10,0) DEFAULT NULL,
  `remainingQtyValue` decimal(10,0) DEFAULT NULL,
  `unitCost` decimal(9,2) DEFAULT NULL,
  `expirationDate` date DEFAULT NULL,
  `isSoldOut` tinyint(1) DEFAULT 0,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ingredients`
--

CREATE TABLE `ingredients` (
  `id` bigint(20) NOT NULL,
  `categoryId` bigint(20) NOT NULL,
  `ingName` varchar(255) DEFAULT NULL,
  `uom` char(3) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `leavetypes`
--

CREATE TABLE `leavetypes` (
  `id` bigint(20) NOT NULL,
  `leaveType` varchar(50) DEFAULT NULL,
  `numberOfDays` int(11) DEFAULT NULL,
  `isActive` tinyint(1) DEFAULT 1,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `numberofworkingdaysinmonth`
--

CREATE TABLE `numberofworkingdaysinmonth` (
  `id` int(11) NOT NULL,
  `numberOfDays` decimal(9,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `numberofworkingdaysinmonth`
--

INSERT INTO `numberofworkingdaysinmonth` (`id`, `numberOfDays`) VALUES
(1, 21.00);

-- --------------------------------------------------------

--
-- Table structure for table `productcategories`
--

CREATE TABLE `productcategories` (
  `id` bigint(20) NOT NULL,
  `prodCategory` varchar(255) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `productingredients`
--

CREATE TABLE `productingredients` (
  `id` bigint(20) NOT NULL,
  `productId` bigint(20) NOT NULL,
  `ingredientId` bigint(20) NOT NULL,
  `uom` int(11) DEFAULT NULL,
  `qtyValue` decimal(10,0) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` bigint(20) NOT NULL,
  `barcodeLbl` varchar(250) DEFAULT NULL,
  `categoryId` bigint(20) NOT NULL,
  `prodName` varchar(255) DEFAULT NULL,
  `pricePerOrder` decimal(9,2) DEFAULT NULL,
  `imageFileName` varchar(250) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(11) NOT NULL,
  `rolekey` varchar(50) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `rolekey`, `createdAt`, `updatedAt`, `deletedAt`, `isDeleted`) VALUES
(1, 'normal', '2023-09-25 10:51:40', '2023-09-25 10:51:40', NULL, 0),
(2, 'admin', '2023-09-25 10:51:40', '2023-09-25 10:51:40', NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `salestransactioncombomeals`
--

CREATE TABLE `salestransactioncombomeals` (
  `id` bigint(20) NOT NULL,
  `salesTransId` bigint(20) NOT NULL,
  `comboMealId` bigint(20) NOT NULL,
  `comboMealCurrentPrice` decimal(9,2) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `totalAmount` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `salestransactionproducts`
--

CREATE TABLE `salestransactionproducts` (
  `id` bigint(20) NOT NULL,
  `salesTransId` bigint(20) NOT NULL,
  `productId` bigint(20) NOT NULL,
  `productCurrentPrice` decimal(9,2) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `totalAmount` decimal(9,2) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `salestransactions`
--

CREATE TABLE `salestransactions` (
  `id` bigint(20) NOT NULL,
  `transactionType` int(11) DEFAULT NULL,
  `ticketNumber` varchar(100) DEFAULT NULL,
  `customerName` varchar(255) DEFAULT NULL,
  `subTotalAmount` decimal(9,2) DEFAULT NULL,
  `discountAmount` decimal(9,2) DEFAULT NULL,
  `discountIsPercentage` tinyint(1) DEFAULT 0,
  `discountPercent` decimal(10,0) DEFAULT NULL,
  `totalAmount` decimal(9,2) DEFAULT NULL,
  `customerCashAmount` decimal(9,2) DEFAULT NULL,
  `customerChangeAmount` decimal(9,2) DEFAULT NULL,
  `customerDueAmount` decimal(9,2) DEFAULT NULL,
  `tableNumber` int(11) DEFAULT NULL,
  `transStatus` int(11) DEFAULT NULL,
  `currentUser` varchar(255) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `IsCustomerDone` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `saletrancombomealinginvdeductionsrecords`
--

CREATE TABLE `saletrancombomealinginvdeductionsrecords` (
  `id` bigint(20) NOT NULL,
  `saleTransComboMealId` bigint(20) NOT NULL,
  `productId` bigint(20) NOT NULL,
  `ingredientId` bigint(20) NOT NULL,
  `ingredientInventoryId` bigint(20) NOT NULL,
  `ingredientUOM` int(11) DEFAULT NULL,
  `deductionSequence` int(11) DEFAULT 0,
  `usedUOM` int(11) DEFAULT NULL,
  `deductedQtyValue` decimal(10,0) DEFAULT NULL,
  `ingInvCurrentUnitCost` decimal(10,0) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `totalCost` decimal(9,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `saletranprodinginvdeductionsrecords`
--

CREATE TABLE `saletranprodinginvdeductionsrecords` (
  `id` bigint(20) NOT NULL,
  `saleTransProductId` bigint(20) NOT NULL,
  `ingredientId` bigint(20) NOT NULL,
  `ingredientInventoryId` bigint(20) NOT NULL,
  `ingredientUOM` int(11) DEFAULT NULL,
  `deductionSequence` int(11) DEFAULT 0,
  `usedUOM` int(11) DEFAULT NULL,
  `deductedQtyValue` decimal(10,0) DEFAULT NULL,
  `ingInvCurrentUnitCost` decimal(10,0) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0,
  `totalCost` decimal(9,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `specificemployeebenefits`
--

CREATE TABLE `specificemployeebenefits` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `employeeName` varchar(50) DEFAULT NULL,
  `benefitTitle` varchar(255) DEFAULT NULL,
  `amount` decimal(9,2) DEFAULT NULL,
  `isPaid` tinyint(1) DEFAULT 0,
  `paymentDate` datetime DEFAULT NULL,
  `payslipId` bigint(20) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `specificemployeedeductions`
--

CREATE TABLE `specificemployeedeductions` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `employeeName` varchar(50) DEFAULT NULL,
  `deductionTitle` varchar(255) DEFAULT NULL,
  `amount` decimal(9,2) DEFAULT NULL,
  `isDeducted` tinyint(1) DEFAULT 0,
  `deductedDate` datetime DEFAULT NULL,
  `payslipId` bigint(20) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `storetables`
--

CREATE TABLE `storetables` (
  `id` bigint(20) NOT NULL,
  `numberOfTables` int(11) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `useractivitylog`
--

CREATE TABLE `useractivitylog` (
  `id` bigint(20) NOT NULL,
  `userName` char(20) DEFAULT NULL,
  `activity` varchar(255) DEFAULT NULL,
  `createdAt` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `userroles`
--

CREATE TABLE `userroles` (
  `id` int(11) NOT NULL,
  `userId` bigint(20) NOT NULL,
  `roleId` int(11) NOT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `userroles`
--

INSERT INTO `userroles` (`id`, `userId`, `roleId`, `createdAt`, `updatedAt`, `deletedAt`, `isDeleted`) VALUES
(1, 1, 2, '2023-09-25 10:51:40', '2023-09-25 11:25:56', NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) NOT NULL,
  `userName` char(20) DEFAULT NULL,
  `fullName` varchar(50) DEFAULT NULL,
  `passwordSha512` varchar(255) DEFAULT NULL,
  `isActive` tinyint(1) DEFAULT 1,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `userName`, `fullName`, `passwordSha512`, `isActive`, `createdAt`, `updatedAt`, `deletedAt`, `isDeleted`) VALUES
(1, 'admin', 'Raniel', 'c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec', 1, '2023-09-25 10:51:40', '2023-09-25 11:00:10', NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `workforceschedules`
--

CREATE TABLE `workforceschedules` (
  `id` bigint(20) NOT NULL,
  `employeeNumber` char(8) DEFAULT NULL,
  `workDate` date DEFAULT NULL,
  `isDone` tinyint(1) DEFAULT 0,
  `createdAt` datetime DEFAULT current_timestamp(),
  `updatedAt` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `branches`
--
ALTER TABLE `branches`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `cashregistercashouttransactions`
--
ALTER TABLE `cashregistercashouttransactions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `combomealproducts`
--
ALTER TABLE `combomealproducts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `comboMealId` (`comboMealId`),
  ADD KEY `productId` (`productId`);

--
-- Indexes for table `combomeals`
--
ALTER TABLE `combomeals`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeeattendance`
--
ALTER TABLE `employeeattendance`
  ADD PRIMARY KEY (`id`),
  ADD KEY `shiftId` (`shiftId`);

--
-- Indexes for table `employeebenefits`
--
ALTER TABLE `employeebenefits`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeecashadvancerequests`
--
ALTER TABLE `employeecashadvancerequests`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeedeductions`
--
ALTER TABLE `employeedeductions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeegovernmentcontributions`
--
ALTER TABLE `employeegovernmentcontributions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `payslipId` (`payslipId`);

--
-- Indexes for table `employeegovtidcards`
--
ALTER TABLE `employeegovtidcards`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeeleaves`
--
ALTER TABLE `employeeleaves`
  ADD PRIMARY KEY (`id`),
  ADD KEY `leaveId` (`leaveId`);

--
-- Indexes for table `employeepayslipbenefits`
--
ALTER TABLE `employeepayslipbenefits`
  ADD PRIMARY KEY (`id`),
  ADD KEY `payslipId` (`payslipId`);

--
-- Indexes for table `employeepayslipdeductions`
--
ALTER TABLE `employeepayslipdeductions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `payslipId` (`payslipId`);

--
-- Indexes for table `employeepayslips`
--
ALTER TABLE `employeepayslips`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeepositions`
--
ALTER TABLE `employeepositions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeepositionshift`
--
ALTER TABLE `employeepositionshift`
  ADD PRIMARY KEY (`id`),
  ADD KEY `shiftId` (`shiftId`),
  ADD KEY `positionId` (`positionId`),
  ADD KEY `positionshiftId` (`employeeId`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `employeeNumber` (`employeeNumber`),
  ADD KEY `branchId` (`branchId`),
  ADD KEY `employeepositionshiftId` (`employeepositionshiftId`);

--
-- Indexes for table `employeeshiftdays`
--
ALTER TABLE `employeeshiftdays`
  ADD PRIMARY KEY (`id`),
  ADD KEY `shiftId` (`shiftId`);

--
-- Indexes for table `employeeshifts`
--
ALTER TABLE `employeeshifts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `holidays`
--
ALTER TABLE `holidays`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `inginventorytransactions`
--
ALTER TABLE `inginventorytransactions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ingredientId` (`ingredientId`),
  ADD KEY `userId` (`userId`);

--
-- Indexes for table `ingredientcategories`
--
ALTER TABLE `ingredientcategories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `ingredientinventory`
--
ALTER TABLE `ingredientinventory`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ingredientId` (`ingredientId`);

--
-- Indexes for table `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`id`),
  ADD KEY `categoryId` (`categoryId`);

--
-- Indexes for table `leavetypes`
--
ALTER TABLE `leavetypes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `numberofworkingdaysinmonth`
--
ALTER TABLE `numberofworkingdaysinmonth`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productcategories`
--
ALTER TABLE `productcategories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productingredients`
--
ALTER TABLE `productingredients`
  ADD PRIMARY KEY (`id`),
  ADD KEY `productId` (`productId`),
  ADD KEY `ingredientId` (`ingredientId`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `categoryId` (`categoryId`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `salestransactioncombomeals`
--
ALTER TABLE `salestransactioncombomeals`
  ADD PRIMARY KEY (`id`),
  ADD KEY `salesTransId` (`salesTransId`),
  ADD KEY `comboMealId` (`comboMealId`);

--
-- Indexes for table `salestransactionproducts`
--
ALTER TABLE `salestransactionproducts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `salesTransId` (`salesTransId`),
  ADD KEY `productId` (`productId`);

--
-- Indexes for table `salestransactions`
--
ALTER TABLE `salestransactions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `saletrancombomealinginvdeductionsrecords`
--
ALTER TABLE `saletrancombomealinginvdeductionsrecords`
  ADD PRIMARY KEY (`id`),
  ADD KEY `saleTransComboMealId` (`saleTransComboMealId`),
  ADD KEY `productId` (`productId`),
  ADD KEY `ingredientId` (`ingredientId`),
  ADD KEY `ingredientInventoryId` (`ingredientInventoryId`);

--
-- Indexes for table `saletranprodinginvdeductionsrecords`
--
ALTER TABLE `saletranprodinginvdeductionsrecords`
  ADD PRIMARY KEY (`id`),
  ADD KEY `saleTransProductId` (`saleTransProductId`),
  ADD KEY `ingredientId` (`ingredientId`),
  ADD KEY `ingredientInventoryId` (`ingredientInventoryId`);

--
-- Indexes for table `specificemployeebenefits`
--
ALTER TABLE `specificemployeebenefits`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specificemployeedeductions`
--
ALTER TABLE `specificemployeedeductions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `storetables`
--
ALTER TABLE `storetables`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `useractivitylog`
--
ALTER TABLE `useractivitylog`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `userroles`
--
ALTER TABLE `userroles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userId` (`userId`),
  ADD KEY `roleId` (`roleId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `userName` (`userName`);

--
-- Indexes for table `workforceschedules`
--
ALTER TABLE `workforceschedules`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `branches`
--
ALTER TABLE `branches`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `cashregistercashouttransactions`
--
ALTER TABLE `cashregistercashouttransactions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `combomealproducts`
--
ALTER TABLE `combomealproducts`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `combomeals`
--
ALTER TABLE `combomeals`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeeattendance`
--
ALTER TABLE `employeeattendance`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `employeebenefits`
--
ALTER TABLE `employeebenefits`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeecashadvancerequests`
--
ALTER TABLE `employeecashadvancerequests`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeedeductions`
--
ALTER TABLE `employeedeductions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeegovernmentcontributions`
--
ALTER TABLE `employeegovernmentcontributions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeegovtidcards`
--
ALTER TABLE `employeegovtidcards`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `employeeleaves`
--
ALTER TABLE `employeeleaves`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeepayslipbenefits`
--
ALTER TABLE `employeepayslipbenefits`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `employeepayslipdeductions`
--
ALTER TABLE `employeepayslipdeductions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeepayslips`
--
ALTER TABLE `employeepayslips`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `employeepositions`
--
ALTER TABLE `employeepositions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `employeepositionshift`
--
ALTER TABLE `employeepositionshift`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `employeeshiftdays`
--
ALTER TABLE `employeeshiftdays`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `employeeshifts`
--
ALTER TABLE `employeeshifts`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `holidays`
--
ALTER TABLE `holidays`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `inginventorytransactions`
--
ALTER TABLE `inginventorytransactions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ingredientcategories`
--
ALTER TABLE `ingredientcategories`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ingredientinventory`
--
ALTER TABLE `ingredientinventory`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `leavetypes`
--
ALTER TABLE `leavetypes`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `numberofworkingdaysinmonth`
--
ALTER TABLE `numberofworkingdaysinmonth`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `productcategories`
--
ALTER TABLE `productcategories`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `productingredients`
--
ALTER TABLE `productingredients`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `salestransactioncombomeals`
--
ALTER TABLE `salestransactioncombomeals`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `salestransactionproducts`
--
ALTER TABLE `salestransactionproducts`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `salestransactions`
--
ALTER TABLE `salestransactions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `saletrancombomealinginvdeductionsrecords`
--
ALTER TABLE `saletrancombomealinginvdeductionsrecords`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `saletranprodinginvdeductionsrecords`
--
ALTER TABLE `saletranprodinginvdeductionsrecords`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `specificemployeebenefits`
--
ALTER TABLE `specificemployeebenefits`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `specificemployeedeductions`
--
ALTER TABLE `specificemployeedeductions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `storetables`
--
ALTER TABLE `storetables`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `useractivitylog`
--
ALTER TABLE `useractivitylog`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `userroles`
--
ALTER TABLE `userroles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `workforceschedules`
--
ALTER TABLE `workforceschedules`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `combomealproducts`
--
ALTER TABLE `combomealproducts`
  ADD CONSTRAINT `combomealproducts_ibfk_1` FOREIGN KEY (`comboMealId`) REFERENCES `combomeals` (`id`),
  ADD CONSTRAINT `combomealproducts_ibfk_2` FOREIGN KEY (`productId`) REFERENCES `products` (`id`);

--
-- Constraints for table `employeeattendance`
--
ALTER TABLE `employeeattendance`
  ADD CONSTRAINT `employeeattendance_ibfk_1` FOREIGN KEY (`shiftId`) REFERENCES `employeeshifts` (`id`);

--
-- Constraints for table `employeegovernmentcontributions`
--
ALTER TABLE `employeegovernmentcontributions`
  ADD CONSTRAINT `employeegovernmentcontributions_ibfk_1` FOREIGN KEY (`payslipId`) REFERENCES `employeepayslips` (`id`);

--
-- Constraints for table `employeeleaves`
--
ALTER TABLE `employeeleaves`
  ADD CONSTRAINT `employeeleaves_ibfk_1` FOREIGN KEY (`leaveId`) REFERENCES `leavetypes` (`id`);

--
-- Constraints for table `employeepayslipbenefits`
--
ALTER TABLE `employeepayslipbenefits`
  ADD CONSTRAINT `employeepayslipbenefits_ibfk_1` FOREIGN KEY (`payslipId`) REFERENCES `employeepayslips` (`id`);

--
-- Constraints for table `employeepayslipdeductions`
--
ALTER TABLE `employeepayslipdeductions`
  ADD CONSTRAINT `employeepayslipdeductions_ibfk_1` FOREIGN KEY (`payslipId`) REFERENCES `employeepayslips` (`id`);

--
-- Constraints for table `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `employees_ibfk_2` FOREIGN KEY (`branchId`) REFERENCES `branches` (`id`);

--
-- Constraints for table `employeeshiftdays`
--
ALTER TABLE `employeeshiftdays`
  ADD CONSTRAINT `employeeshiftdays_ibfk_1` FOREIGN KEY (`shiftId`) REFERENCES `employeeshifts` (`id`);

--
-- Constraints for table `inginventorytransactions`
--
ALTER TABLE `inginventorytransactions`
  ADD CONSTRAINT `inginventorytransactions_ibfk_1` FOREIGN KEY (`ingredientId`) REFERENCES `ingredients` (`id`),
  ADD CONSTRAINT `inginventorytransactions_ibfk_2` FOREIGN KEY (`userId`) REFERENCES `users` (`id`);

--
-- Constraints for table `ingredientinventory`
--
ALTER TABLE `ingredientinventory`
  ADD CONSTRAINT `ingredientinventory_ibfk_1` FOREIGN KEY (`ingredientId`) REFERENCES `ingredients` (`id`);

--
-- Constraints for table `ingredients`
--
ALTER TABLE `ingredients`
  ADD CONSTRAINT `ingredients_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `ingredientcategories` (`id`);

--
-- Constraints for table `productingredients`
--
ALTER TABLE `productingredients`
  ADD CONSTRAINT `productingredients_ibfk_1` FOREIGN KEY (`productId`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `productingredients_ibfk_2` FOREIGN KEY (`ingredientId`) REFERENCES `ingredients` (`id`);

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `productcategories` (`id`);

--
-- Constraints for table `salestransactioncombomeals`
--
ALTER TABLE `salestransactioncombomeals`
  ADD CONSTRAINT `salestransactioncombomeals_ibfk_1` FOREIGN KEY (`salesTransId`) REFERENCES `salestransactions` (`id`),
  ADD CONSTRAINT `salestransactioncombomeals_ibfk_2` FOREIGN KEY (`comboMealId`) REFERENCES `combomeals` (`id`);

--
-- Constraints for table `salestransactionproducts`
--
ALTER TABLE `salestransactionproducts`
  ADD CONSTRAINT `salestransactionproducts_ibfk_1` FOREIGN KEY (`salesTransId`) REFERENCES `salestransactions` (`id`),
  ADD CONSTRAINT `salestransactionproducts_ibfk_2` FOREIGN KEY (`productId`) REFERENCES `products` (`id`);

--
-- Constraints for table `saletrancombomealinginvdeductionsrecords`
--
ALTER TABLE `saletrancombomealinginvdeductionsrecords`
  ADD CONSTRAINT `saletrancombomealinginvdeductionsrecords_ibfk_1` FOREIGN KEY (`saleTransComboMealId`) REFERENCES `salestransactioncombomeals` (`id`),
  ADD CONSTRAINT `saletrancombomealinginvdeductionsrecords_ibfk_2` FOREIGN KEY (`productId`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `saletrancombomealinginvdeductionsrecords_ibfk_3` FOREIGN KEY (`ingredientId`) REFERENCES `ingredients` (`id`),
  ADD CONSTRAINT `saletrancombomealinginvdeductionsrecords_ibfk_4` FOREIGN KEY (`ingredientInventoryId`) REFERENCES `ingredientinventory` (`id`);

--
-- Constraints for table `saletranprodinginvdeductionsrecords`
--
ALTER TABLE `saletranprodinginvdeductionsrecords`
  ADD CONSTRAINT `saletranprodinginvdeductionsrecords_ibfk_1` FOREIGN KEY (`saleTransProductId`) REFERENCES `salestransactionproducts` (`id`),
  ADD CONSTRAINT `saletranprodinginvdeductionsrecords_ibfk_2` FOREIGN KEY (`ingredientId`) REFERENCES `ingredients` (`id`),
  ADD CONSTRAINT `saletranprodinginvdeductionsrecords_ibfk_3` FOREIGN KEY (`ingredientInventoryId`) REFERENCES `ingredientinventory` (`id`);

--
-- Constraints for table `userroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `userroles_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `userroles_ibfk_2` FOREIGN KEY (`roleId`) REFERENCES `roles` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
