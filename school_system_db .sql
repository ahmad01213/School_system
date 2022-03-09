-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 09, 2022 at 11:02 PM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `school_system_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoleClaims`
--

CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoles`
--

CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `AspNetRoles`
--

INSERT INTO `AspNetRoles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('02db9a5f-459a-485c-b99a-6d03a38c5120', 'school', 'SCHOOL', '88abeef1-555a-4163-95a3-d1531693cfc9'),
('7d63224a-cc9f-4c6e-98a6-ca734218b9f4', 'admin', 'ADMIN', '01bb10f6-e81e-40ba-a623-4d5cccacaa11'),
('91d18e9b-adc5-44f1-a580-52f089c9472c', 'teacher', 'TEACHER', 'e0824ad9-cdc7-4096-b68e-28dc3704db8e'),
('f870386f-5f17-434d-a244-04603777aa01', 'student', 'STUDENT', '71c6cb0c-7494-41ef-8013-b8b8733c6af7');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserClaims`
--

CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserLogins`
--

CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserRoles`
--

CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `AspNetUserRoles`
--

INSERT INTO `AspNetUserRoles` (`UserId`, `RoleId`) VALUES
('0b7dad68-94ac-4b01-8135-9da0704db09b', '7d63224a-cc9f-4c6e-98a6-ca734218b9f4'),
('13406cfe-ccc5-478c-beeb-0c2ebfff54d7', 'f870386f-5f17-434d-a244-04603777aa01'),
('2c975b0e-f235-4ab0-915c-0a24aefb142c', '91d18e9b-adc5-44f1-a580-52f089c9472c'),
('345939ba-ec8a-49cd-8c7c-1aeca923bde3', 'f870386f-5f17-434d-a244-04603777aa01'),
('3583ff36-57d4-498b-b2b1-61dddc6a6d74', '91d18e9b-adc5-44f1-a580-52f089c9472c'),
('38d88eaa-ab84-464d-bfd0-a5bad7e1d037', '91d18e9b-adc5-44f1-a580-52f089c9472c'),
('3f7cdf6c-238c-4981-bab7-4f7ab283b854', '7d63224a-cc9f-4c6e-98a6-ca734218b9f4'),
('45dc5c6c-c3ce-4fb8-8579-867b8524ace5', '91d18e9b-adc5-44f1-a580-52f089c9472c'),
('6ebb4257-f772-4bcc-acb5-f625186d39bb', '02db9a5f-459a-485c-b99a-6d03a38c5120'),
('746723bf-c8a4-4fd0-b0c9-2e377c6b218e', '02db9a5f-459a-485c-b99a-6d03a38c5120'),
('8e197906-6e57-466e-b3a7-5164b2516a80', '91d18e9b-adc5-44f1-a580-52f089c9472c'),
('e150baca-609a-4d47-9ccf-f2f6cfeb0754', '91d18e9b-adc5-44f1-a580-52f089c9472c'),
('e25d637a-9dca-413d-82a3-77f567d80ec2', '91d18e9b-adc5-44f1-a580-52f089c9472c'),
('e5808b75-9968-4206-ac64-12e3f59fe91e', 'f870386f-5f17-434d-a244-04603777aa01'),
('ed5502ba-0179-450e-8c95-b71547fd40a0', '02db9a5f-459a-485c-b99a-6d03a38c5120'),
('f86ff698-ed38-4848-918e-70d1aafe396d', '91d18e9b-adc5-44f1-a580-52f089c9472c');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUsers`
--

CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `Role` varchar(255) NOT NULL DEFAULT 'STUDENT',
  `UserName` varchar(256) DEFAULT NULL,
  `Name` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `manager` varchar(255) NOT NULL DEFAULT '-',
  `schoolId` varchar(1000) DEFAULT NULL,
  `attendanceNumber` varchar(255) DEFAULT 'none',
  `jobNumber` varchar(255) DEFAULT 'none',
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `AspNetUsers`
--

INSERT INTO `AspNetUsers` (`Id`, `Role`, `UserName`, `Name`, `phone`, `manager`, `schoolId`, `attendanceNumber`, `jobNumber`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('345939ba-ec8a-49cd-8c7c-1aeca923bde3', 'student', 'mahdi', 'مهدي علي', '543347634', '-', '6ebb4257-f772-4bcc-acb5-f625186d39bb', '546573467', '57456347654', 'MAHDI', 'mahdi@mail.com', 'MAHDI@MAIL.COM', 0, 'AQAAAAEAACcQAAAAEFGicWlxNlvUrcH/htmo6D5SzgPl4+OjxX/xeKlczElO8pBR/mNowqyMci/LR9BSoQ==', 'QNKJZO43ZW3KR62VTR2JMLHURVPUQKAF', '07491219-df67-4e8c-8f4b-4caa7578d722', NULL, 0, 0, NULL, 1, 0),
('3f7cdf6c-238c-4981-bab7-4f7ab283b854', 'admin', 'rethm', 'rethm', '05367367', '-', '-', '-', '-', 'RETHM', 'admin@admin.com', 'ADMIN@ADMIN.COM', 0, 'AQAAAAEAACcQAAAAEFHoIzC+Su5yGpm42yzxv+2y3pab6oeEMCsvp5xkOswhhZKngh7tuNdcx+rHd327bg==', 'HFBRDC4BKESCPG6SCI76FQOJKT7C52IW', 'b26bdbb0-83f0-4c70-82fd-09b1fa0bec66', NULL, 0, 0, NULL, 1, 0),
('6ebb4257-f772-4bcc-acb5-f625186d39bb', 'school', 'salam', 'مدرسة السلام', '578348343', 'محمد عمر', '-', '-', '-', 'SALAM', 'salam@gmail.com', 'SALAM@GMAIL.COM', 0, 'AQAAAAEAACcQAAAAEICQgZJwmNvAyxLaMw4YmVl2NVkrHdVvDW+2UgsWgoI6Szy4ovXX/HL1N7sICn3gFA==', 'OHVPBNGAE45LXZBYE3HGRHPHEJ7ISNPA', '5ddf3d9b-c57b-4486-aaec-a942005b2900', NULL, 0, 0, NULL, 1, 0),
('e150baca-609a-4d47-9ccf-f2f6cfeb0754', 'teacher', 'ali', 'علي محمد', '5653753474', '-', '6ebb4257-f772-4bcc-acb5-f625186d39bb', '5465734543', '56457353454', 'ALI', 'ali@mail.com', 'ALI@MAIL.COM', 0, 'AQAAAAEAACcQAAAAEMkE0WEWaBeaBd8P4iKYaROQ16osacqf7vtvDGVfM2x+0MjqKqIjK8BZHDoAoeX1kg==', 'ZLFXBNQ5ZZ2FLLI36K7JTJRTQSADBWXD', '68ebfb23-b18b-46b2-9b5f-f78faad1f6a9', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserTokens`
--

CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Attendances`
--

CREATE TABLE `Attendances` (
  `Id` int(11) NOT NULL,
  `CardNumber` longtext NOT NULL,
  `RoomId` longtext NOT NULL,
  `Note` longtext NOT NULL,
  `Date` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Classes`
--

CREATE TABLE `Classes` (
  `Id` int(11) NOT NULL,
  `SchoolId` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Rooms`
--

CREATE TABLE `Rooms` (
  `Id` int(11) NOT NULL,
  `RoomId` varchar(255) NOT NULL,
  `Roomip` varchar(255) NOT NULL,
  `SchoolId` varchar(1000) NOT NULL DEFAULT '-',
  `SubjectId` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Rooms`
--

INSERT INTO `Rooms` (`Id`, `RoomId`, `Roomip`, `SchoolId`, `SubjectId`, `CreatedAt`) VALUES
(4, '56573564354', '5745673563454', '463d9e29-5bc3-4506-a4ed-b9ec87bfb9bc', 3, '2022-03-09 12:29:43.404078');

-- --------------------------------------------------------

--
-- Table structure for table `Schools`
--

CREATE TABLE `Schools` (
  `Id` int(11) NOT NULL,
  `City` longtext NOT NULL,
  `Name` longtext NOT NULL,
  `Manager` longtext NOT NULL,
  `Phone` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Subjects`
--

CREATE TABLE `Subjects` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `SchoolId` longtext NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Subjects`
--

INSERT INTO `Subjects` (`Id`, `Name`, `SchoolId`, `CreatedAt`) VALUES
(4, 'عربي', '-', '2022-03-09 14:34:43.148195');

-- --------------------------------------------------------

--
-- Table structure for table `Teatchers`
--

CREATE TABLE `Teatchers` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `Phone` longtext NOT NULL,
  `SchoolId` int(11) NOT NULL,
  `CardNumber` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `TimeTables`
--

CREATE TABLE `TimeTables` (
  `Id` int(11) NOT NULL,
  `TeatcherId` int(11) NOT NULL,
  `InTime` longtext NOT NULL,
  `OutTime` longtext NOT NULL,
  `Dayofweek` longtext NOT NULL,
  `SubjectId` int(11) NOT NULL,
  `RoomId` int(11) NOT NULL,
  `Permittime` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetRoles`
--
ALTER TABLE `AspNetRoles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetUsers`
--
ALTER TABLE `AspNetUsers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `Attendances`
--
ALTER TABLE `Attendances`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Classes`
--
ALTER TABLE `Classes`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Rooms`
--
ALTER TABLE `Rooms`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Schools`
--
ALTER TABLE `Schools`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Subjects`
--
ALTER TABLE `Subjects`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Teatchers`
--
ALTER TABLE `Teatchers`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `TimeTables`
--
ALTER TABLE `TimeTables`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Attendances`
--
ALTER TABLE `Attendances`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Classes`
--
ALTER TABLE `Classes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Rooms`
--
ALTER TABLE `Rooms`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Schools`
--
ALTER TABLE `Schools`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Subjects`
--
ALTER TABLE `Subjects`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Teatchers`
--
ALTER TABLE `Teatchers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `TimeTables`
--
ALTER TABLE `TimeTables`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
