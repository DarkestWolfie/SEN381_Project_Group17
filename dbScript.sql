CREATE DATABASE `ukupholisa`;

USE `ukupholisa`;

CREATE TABLE `address` (
  `addressID` int NOT NULL AUTO_INCREMENT,
  `addressLine` varchar(250) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  `postalCode` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`addressID`),
  UNIQUE KEY `addressID_UNIQUE` (`addressID`)
);

CREATE TABLE `provider` (
  `providerID` int NOT NULL AUTO_INCREMENT,
  `providerName` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `province` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`providerID`),
  UNIQUE KEY `providerID_UNIQUE` (`providerID`)
);

CREATE TABLE `customer` (
  `customerID` int NOT NULL AUTO_INCREMENT,
  `custName` varchar(45) DEFAULT NULL,
  `custSurname` varchar(45) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `idNumber` varchar(13) DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `familyID` int DEFAULT NULL,
  `familyRole` varchar(45) DEFAULT NULL,
  `customerAddressID` int DEFAULT NULL,
  PRIMARY KEY (`customerID`),
  UNIQUE KEY `customerID_UNIQUE` (`customerID`),
  KEY `addressID_idx` (`customerAddressID`),
  CONSTRAINT `customerAddressID` FOREIGN KEY (`customerAddressID`) REFERENCES `address` (`addressID`)
);

CREATE TABLE `employee` (
  `employeeID` int NOT NULL AUTO_INCREMENT,
  `empName` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `phoneNumber` varchar(10) DEFAULT NULL,
  `role` varchar(45) DEFAULT NULL,
  `userName` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`employeeID`),
  UNIQUE KEY `employeeID_UNIQUE` (`employeeID`)
);

CREATE TABLE `policy` (
  `policyID` int NOT NULL AUTO_INCREMENT,
  `policyName` varchar(45) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `installment` double DEFAULT NULL,
  `payout` double DEFAULT NULL,
  PRIMARY KEY (`policyID`),
  UNIQUE KEY `policyID_UNIQUE` (`policyID`)
);

CREATE TABLE `call_history` (
  `callID` int NOT NULL AUTO_INCREMENT,
  `callCustomerID` int DEFAULT NULL,
  `callEmployeeID` int DEFAULT NULL,
  `start` time DEFAULT NULL,
  `end` time DEFAULT NULL,
  `dateCreated` date DEFAULT NULL,
  PRIMARY KEY (`callID`),
  UNIQUE KEY `callID_UNIQUE` (`callID`),
  KEY `customerID_idx` (`callCustomerID`),
  KEY `employeeID_idx` (`callEmployeeID`),
  CONSTRAINT `callCustomerID` FOREIGN KEY (`callCustomerID`) REFERENCES `customer` (`customerID`),
  CONSTRAINT `callEmployeeID` FOREIGN KEY (`callEmployeeID`) REFERENCES `employee` (`employeeID`)
);

CREATE TABLE `customer_account` (
  `accountID` int NOT NULL AUTO_INCREMENT,
  `accountCustomerID` int DEFAULT NULL,
  `amountDue` double DEFAULT NULL,
  `installmentDate` date DEFAULT NULL,
  PRIMARY KEY (`accountID`),
  UNIQUE KEY `accountID_UNIQUE` (`accountID`),
  KEY `customerID_idx` (`accountCustomerID`),
  CONSTRAINT `accountCustomerID` FOREIGN KEY (`accountCustomerID`) REFERENCES `customer` (`customerID`)
);

CREATE TABLE `condition` (
  `conditionID` int NOT NULL AUTO_INCREMENT,
  `conditionName` varchar(45) DEFAULT NULL,
  `conditionPolicyID` int DEFAULT NULL,
  PRIMARY KEY (`conditionID`),
  UNIQUE KEY `conditionID_UNIQUE` (`conditionID`),
  KEY `policyID_idx` (`conditionPolicyID`),
  CONSTRAINT `conditionPolicyID` FOREIGN KEY (`conditionPolicyID`) REFERENCES `policy` (`policyID`)
);

CREATE TABLE `product` (
  `productID` int NOT NULL AUTO_INCREMENT,
  `policyDiscount` double DEFAULT NULL,
  `availability` varchar(45) DEFAULT NULL,
  `productPolicyID` int DEFAULT NULL,
  PRIMARY KEY (`productID`),
  UNIQUE KEY `productID_UNIQUE` (`productID`),
  KEY `policy_ID_idx` (`productPolicyID`),
  CONSTRAINT `productPolicyID` FOREIGN KEY (`productPolicyID`) REFERENCES `policy` (`policyID`)
);

CREATE TABLE `product_history` (
  `proHistoryID` int NOT NULL AUTO_INCREMENT,
  `start` date DEFAULT NULL,
  `end` date DEFAULT NULL,
  `historyProductID` int DEFAULT NULL,
  PRIMARY KEY (`proHistoryID`),
  UNIQUE KEY `proHistoryID_UNIQUE` (`proHistoryID`),
  KEY `productID_idx` (`historyProductID`),
  CONSTRAINT `historyProductID` FOREIGN KEY (`historyProductID`) REFERENCES `product` (`productID`)
);

CREATE TABLE `customer_history` (
  `cusHistoryID` int NOT NULL AUTO_INCREMENT,
  `start` date DEFAULT NULL,
  `end` date DEFAULT NULL,
  `active` varchar(45) DEFAULT NULL,
  `historyCustomerID` int DEFAULT NULL,
  `historyProductHistoryID` int DEFAULT NULL,
  PRIMARY KEY (`cusHistoryID`),
  UNIQUE KEY `cusHistoryID_UNIQUE` (`cusHistoryID`),
  KEY `proHistoryID_idx` (`historyProductHistoryID`),
  KEY `historyCustomerID_idx` (`historyCustomerID`),
  CONSTRAINT `historyCustomerID` FOREIGN KEY (`historyCustomerID`) REFERENCES `customer` (`customerID`),
  CONSTRAINT `historyProductHistoryID` FOREIGN KEY (`historyProductHistoryID`) REFERENCES `product_history` (`proHistoryID`)
);

CREATE TABLE `treatment` (
  `treatmentID` int NOT NULL AUTO_INCREMENT,
  `treatmentName` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `cost` double DEFAULT NULL,
  `treatmentConditionID` int DEFAULT NULL,
  `treatmentProviderID` int DEFAULT NULL,
  PRIMARY KEY (`treatmentID`),
  UNIQUE KEY `treatmentID_UNIQUE` (`treatmentID`),
  KEY `conditionID_idx` (`treatmentConditionID`),
  KEY `providerID_idx` (`treatmentProviderID`),
  CONSTRAINT `treatmentConditionID` FOREIGN KEY (`treatmentConditionID`) REFERENCES `condition` (`conditionID`),
  CONSTRAINT `treatmentProviderID` FOREIGN KEY (`treatmentProviderID`) REFERENCES `provider` (`providerID`)
);

  CREATE TABLE `application` (
  `applicationID` int NOT NULL AUTO_INCREMENT,
  `applicationDate` date DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `applicationCustomerID` int DEFAULT NULL,
  `applicationConditionID` int DEFAULT NULL,
  `applicationProviderID` int DEFAULT NULL,
  PRIMARY KEY (`applicationID`),
  UNIQUE KEY `applicationID_UNIQUE` (`applicationID`),
  KEY `customerID_idx` (`applicationCustomerID`),
  KEY `conditionID_idx` (`applicationConditionID`),
  KEY `providerID_idx` (`applicationProviderID`),
  CONSTRAINT `applicationConditionID` FOREIGN KEY (`applicationConditionID`) REFERENCES `condition` (`conditionID`),
  CONSTRAINT `applicationCustomerID` FOREIGN KEY (`applicationCustomerID`) REFERENCES `customer` (`customerID`),
  CONSTRAINT `applicationProviderID` FOREIGN KEY (`applicationProviderID`) REFERENCES `provider` (`providerID`)
);