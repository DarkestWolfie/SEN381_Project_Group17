USE master
GO

CREATE DATABASE ukupholisa
GO

Use ukupholisa
Go

CREATE TABLE [address]
(
	addressID int NOT NULL IDENTITY,
	addressLine varchar(250),
	city varchar(45),
	province varchar(45),
	postalCode varchar(4),
	Primary Key (addressID)
);

CREATE TABLE [provider]
(
  providerID int NOT NULL IDENTITY,
  providerName varchar(45),
  status varchar(45),
  province varchar(45),
  PRIMARY KEY (providerID)
);

CREATE TABLE [customer] 
(
  customerID varchar(9) NOT NULL UNIQUE,
  custName varchar(45) ,
  custSurname varchar(45) ,
  dob varchar(10) ,
  idNumber varchar(13) ,
  gender varchar(45) ,
  familyID int ,
  familyRole varchar(45) ,
  customerAddressID int FOREIGN KEY REFERENCES [address](addressID),
  PRIMARY KEY (customerID)
);

CREATE TABLE [employee] 
(
  employeeID int NOT NULL IDENTITY,
  empName varchar(45) ,
  email varchar(45) ,
  phoneNumber varchar(10) ,
  role varchar(45) ,
  userName varchar(45) ,
  password varchar(45) ,
  PRIMARY KEY (employeeID)
);

--CREATE TABLE [login] 
--(
--  loginID int NOT NULL IDENTITY,
--  userName varchar(45) ,
--  [password] varchar(45) ,
--  [role] varchar(25) ,
--  employeeID int FOREIGN KEY REFERENCES employee(employeeID),
--  PRIMARY KEY (loginID)
--);

CREATE TABLE [policy] 
(
  policyID varchar(12) NOT NULL UNIQUE,
  policyName varchar(45) ,
  price float ,
  installment float ,
  payout float ,
  PRIMARY KEY (policyID)
);

CREATE TABLE [call_history] 
(
  callID int NOT NULL IDENTITY,
  callCustomerID varchar(9) FOREIGN KEY REFERENCES customer (customerID),
  callEmployeeID int FOREIGN KEY REFERENCES employee (employeeID),
  [start] varchar(10)  ,
  [end] varchar(10) ,
  dateCreated varchar(10) ,
  PRIMARY KEY (callID)
);

CREATE TABLE [customer_account] 
(
  accountID int NOT NULL IDENTITY,
  accountCustomerID varchar(9) FOREIGN KEY REFERENCES customer (customerID),
  amountDue float ,
  installmentDate varchar(10) ,
  PRIMARY KEY (accountID)
);

CREATE TABLE [condition] 
(
  conditionID int NOT NULL IDENTITY,
  conditionName varchar(45) ,
  conitionCode varchar(10),
  conditionPolicyID varchar(12) FOREIGN KEY REFERENCES policy (policyID),
  PRIMARY KEY (conditionID),
);

CREATE TABLE [product] 
(
  productID int NOT NULL IDENTITY,
  policyDiscount float ,
  [availability] varchar(45) ,
  productPolicyID varchar(12) FOREIGN KEY REFERENCES policy (policyID),
  PRIMARY KEY (productID)
);

CREATE TABLE [product_history] 
(
  proHistoryID int NOT NULL IDENTITY,
  [start] varchar(10) ,
  [end] varchar(10) ,
  historyProductID int FOREIGN KEY REFERENCES product (productID),
  PRIMARY KEY (proHistoryID)
);

CREATE TABLE [customer_history] 
(
  cusHistoryID int NOT NULL IDENTITY,
  [start] varchar(10) ,
  [end] varchar(10) ,
  active varchar(45) ,
  historyCustomerID varchar(9) FOREIGN KEY REFERENCES customer (customerID),
  historyProductHistoryID int FOREIGN KEY REFERENCES product_history (proHistoryID),
  PRIMARY KEY (cusHistoryID)
);

CREATE TABLE [treatment] 
(
  treatmentID int NOT NULL IDENTITY,
  treatmentName varchar(45) ,
  [description] varchar(1000) ,
  cost float ,
  treatmentConditionID int FOREIGN KEY REFERENCES condition (conditionID),
  treatmentProviderID int FOREIGN KEY REFERENCES provider (providerID),
  PRIMARY KEY (treatmentID)
);

  CREATE TABLE [application] 
  (
  applicationID int NOT NULL IDENTITY,
  applicationDate varchar(10) ,
  [status] varchar(45) ,
  applicationCustomerID varchar(9) FOREIGN KEY REFERENCES customer (customerID),
  applicationConditionID int FOREIGN KEY REFERENCES condition (conditionID),
  applicationProviderID int FOREIGN KEY REFERENCES provider (providerID),
  PRIMARY KEY (applicationID) 
);

GO

CREATE PROC spGetAdress
AS
BEGIN
	SELECT * FROM [address];
END
GO

CREATE PROC spGetProvider
AS
BEGIN
	SELECT * FROM [provider];
END
GO

CREATE PROC spGetCustomer
AS
BEGIN
	SELECT * FROM [customer];
END
GO

CREATE PROC spGetEmployee
AS
BEGIN
	SELECT * FROM [employee];
END
GO

CREATE PROC spGetPolicy
AS
BEGIN
	SELECT * FROM [policy];
END
GO

CREATE PROC spGetCallHistory
AS
BEGIN
	SELECT * FROM [call_history];
END
GO

CREATE PROC spGetAccount
AS
BEGIN
	SELECT * FROM [customer_account];
END
GO

CREATE PROC spGetCondition
AS
BEGIN
	SELECT * FROM [condition];
END
GO

CREATE PROC spGetProduct
AS
BEGIN
	SELECT * FROM [product];
END
GO

CREATE PROC spGetProductHistory
AS
BEGIN
	SELECT * FROM [product_history];
END
GO

CREATE PROC spGetCustomerHistory
AS
BEGIN
	SELECT * FROM customer_history;
END
GO

CREATE PROC spGetTreatment 
AS
BEGIN
	SELECT * FROM [treatment];
END
GO

CREATE PROC spGetApplication
AS
BEGIN
	SELECT * FROM [application];
END
GO

CREATE PROC spAddAddress
(
	@addressLine varchar(250),
	@city varchar(45),
	@province varchar(45),
	@postalCode varchar(4)
)
AS
BEGIN
	INSERT INTO [address]
	(addressLine, city, province, postalCode)
	VALUES (@addressLine, @city, @province, @postalCode);
END
GO

CREATE PROC spAddProvider
(
	
	@providerName varchar(45),
	@status varchar(45),
	@province varchar(45)
)
AS
BEGIN
	INSERT INTO [provider]
	(providerName, [status], province)
	VALUES (@providerName, @status, @province);
END
GO

CREATE PROC spAddCustomer
(
	 @customerID varchar(9),
	 @custName varchar(45) ,
	 @custSurname varchar(45) ,
	 @dob varchar(10) ,
	 @idNumber varchar(13) ,
	 @gender varchar(45) ,
	 @familyID int ,
	 @familyRole varchar(45),
	 @customerAddressID int
)
AS
BEGIN
	INSERT INTO [customer]
	(customerID, custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
	VALUES (@customerID, @custName, @custSurname, @dob, @idNumber, @gender, @familyID, @familyRole, @customerAddressID);
END
GO

CREATE PROC spAddEmployee
(
	 @empName varchar(45) ,
	 @email varchar(45) ,
	 @phoneNumber varchar(10) ,
	 @role varchar(45) ,
	 @userName varchar(45) ,
	 @password varchar(45)
)
AS
BEGIN
	INSERT INTO [employee]
	(empName, email, phoneNumber, [role], userName, [password])
	VALUES (@empName, @email, @phoneNumber, @role, @userName, @password);
END
GO

CREATE PROC spAddPolicy
(
	@policyID varchar(12),
	@policyName varchar(45) ,
	@price float ,
	@installment float ,
	@payout float 
)
AS
BEGIN
	INSERT INTO [policy]
	(policyID, policyName, price, installment, payout)
	VALUES (@policyID, @policyName, @price, @installment, @payout);
END
GO

CREATE PROC spAddCallHistory
(
	@callCustomerID varchar(9) ,
	@callEmployeeID int ,
	@start varchar(10)  ,
	@end varchar(10) ,
	@dateCreated varchar(10)
)
AS
BEGIN
	INSERT INTO [call_history]
	(callCustomerID, callEmployeeID, [start], [end], dateCreated)
	VALUES (@callCustomerID, @callEmployeeID, @start, @end, @dateCreated);
END
GO

CREATE PROC spAddAccount
(
	@accountCustomerID varchar(9) ,
	@amountDue float ,
	@installmentDate varchar(10) 
)
AS
BEGIN
	INSERT INTO [customer_account]
	(accountCustomerID, amountDue, installmentDate)
	VALUES (@accountCustomerID, @amountDue, @installmentDate);
END
GO

CREATE PROC spAddCondition
(
	@conditionName varchar(45) ,
	@conditionCode varchar(10),
	@conditionPolicyID varchar(12)
)
AS
BEGIN
	INSERT INTO [condition]
	(conditionName, conitionCode, conditionPolicyID)
	VALUES (@conditionName, @conditionCode, @conditionPolicyID);
END
GO

CREATE PROC spAddProduct
(
	@policyDiscount float ,
	@availability varchar(45) ,
	@productPolicyID varchar(12)
)
AS
BEGIN
	INSERT INTO [product]
	(policyDiscount, [availability], productPolicyID)
	VALUES (@policyDiscount, @availability, @productPolicyID);
END
GO

CREATE PROC spAddProductHistory
(
	@start varchar(10) ,
	@end varchar(10) ,
	@historyProductID int
)
AS
BEGIN
	INSERT INTO [product_history]
	([start], [end], historyProductID)
	VALUES (@start, @end, @historyProductID);
END
GO

CREATE PROC spAddCustomerHistory
(
	@start varchar(10) ,
	@end varchar(10) ,
	@active varchar(45) ,
	@historyCustomerID varchar(9) ,
	@historyProductHistoryID int
)
AS
BEGIN
	INSERT INTO [customer_history]
	([start], [end], [active], historyCustomerID, historyProductHistoryID)
	VALUES (@start, @end, @active, @historyCustomerID, @historyProductHistoryID);
END
GO

CREATE PROC spAddTreatment
(
	@treatmentName varchar(45) ,
	@description varchar(45) ,
	@cost float ,
	@treatmentConditionID int ,
	@treatmentProviderID int
)
AS
BEGIN
	INSERT INTO [treatment]
	(treatmentName, [description], cost, treatmentConditionID, treatmentProviderID)
	VALUES (@treatmentName, @description, @cost, @treatmentConditionID, @treatmentProviderID);
END
GO

CREATE PROC spAddApplication
(
	@applicationDate varchar(10) ,
	@status varchar(45) ,
	@applicationCustomerID varchar(9) ,
	@applicationConditionID int,
	@applicationProviderID int
)
AS
BEGIN
	INSERT INTO [application]
	(applicationDate, [status], applicationCustomerID, applicationConditionID, applicationProviderID)
	VALUES (@applicationDate, @status, @applicationCustomerID, @applicationConditionID, @applicationProviderID);
END
GO

CREATE PROC spUpdateAddress
(
	@id int,
	@addressLine varchar(250),
	@city varchar(45),
	@province varchar(45),
	@postalCode varchar(4)
)
AS
BEGIN
	Update [address]
	SET addressLine = @addressLine, city = @city, province = @province, postalCode = @postalCode
	WHERE addressID = @id
END
GO

CREATE PROC spUpdateProvider
(
	@id int,
	@providerName varchar(45),
	@status varchar(45),
	@province varchar(45)
)
AS
BEGIN
	Update [provider]
	SET providerName = @providerName, [status] = @status, province = @province
	WHERE providerID = @id
END
GO

CREATE PROC spUpdateCustomer
(
	 @id varchar(9),
	 @custName varchar(45) ,
	 @custSurname varchar(45) ,
	 @dob varchar(10) ,
	 @idNumber varchar(13) ,
	 @gender varchar(45) ,
	 @familyID int ,
	 @familyRole varchar(45),
	 @customerAddressID int
)
AS
BEGIN
	Update [customer]
	SET custName = @custName, custSurname = @custSurname, dob = @dob, idNumber = @idNumber, gender = @gender, familyID = @familyID, customerAddressID = @customerAddressID
	WHERE customerID = @id
END
GO

CREATE PROC spUpdateEmployee
(
	 @id int,
	 @empName varchar(45) ,
	 @email varchar(45) ,
	 @phoneNumber varchar(10) ,
	 @role varchar(45) ,
	 @userName varchar(45) ,
	 @password varchar(45)
)
AS
BEGIN
	Update [employee]
	SET empName = @empName, email = @email, phoneNumber = @phoneNumber, [role] = @role, userName = @userName, [password] = @password
	WHERE employeeID = @id
END
GO

CREATE PROC spUpdatePolicy
(
	@id varchar(12),
	@policyName varchar(45) ,
	@price float ,
	@installment float ,
	@payout float 
)
AS
BEGIN
	Update [policy]
	SET policyName = @policyName, price = @price, installment = @installment, payout = @payout
	WHERE policyID = @id
END
GO

CREATE PROC spUpdateCallHistory
(
	@id int,
	@callCustomerID varchar(9) ,
	@callEmployeeID int ,
	@start varchar(10)  ,
	@end varchar(10) ,
	@dateCreated varchar(10)
)
AS
BEGIN
	Update [call_history]
	SET callCustomerID = @callCustomerID, callEmployeeID = @callEmployeeID, [start] = @start, [end] = @end, dateCreated = @dateCreated
	WHERE callID = @id
END
GO

CREATE PROC spUpdateAccount
(
	@id int,
	@accountCustomerID varchar(9) ,
	@amountDue float ,
	@installmentDate varchar(10) 
)
AS
BEGIN
	Update [customer_account]
	SET accountCustomerID = @accountCustomerID, amountDue = @amountDue, installmentDate = @installmentDate
	WHERE accountID = @id
END
GO

CREATE PROC spUpdateCondition
(
	@id int,
	@conditionName varchar(45) ,
	@conditionCode varchar(10),
	@conditionPolicyID varchar(12)
)
AS
BEGIN
	Update [condition]
	SET conditionName = @conditionName, conitionCode = @conditionCode, conditionPolicyID = @conditionPolicyID
	WHERE conditionID = @id
END
GO

CREATE PROC spUpdateProduct
(
	@id int,
	@policyDiscount float ,
	@availability varchar(45) ,
	@productPolicyID varchar(12)
)
AS
BEGIN
	Update [product]
	SET policyDiscount = @policyDiscount, [availability] = @availability, productPolicyID = @productPolicyID
	WHERE productID = @id
END
GO

CREATE PROC spUpdateProductHistory
(
	@id int,
	@start varchar(10) ,
	@end varchar(10) ,
	@historyProductID int
)
AS
BEGIN
	Update [product_history]
	SET [start] = @start, [end] = @end, historyProductID = @historyProductID
	WHERE proHistoryID = @id
END
GO

CREATE PROC spUpdateCustomerHistory
(
	@id int,
	@start varchar(10) ,
	@end varchar(10) ,
	@active varchar(45) ,
	@historyCustomerID varchar(9) ,
	@historyProductHistoryID int
)
AS
BEGIN
	Update [customer_history]
	SET [start] = @start, [end] = @end, [active] = @active, historyCustomerID = @historyCustomerID, historyProductHistoryID = @historyProductHistoryID
	WHERE cusHistoryID = @id
END
GO

CREATE PROC spUpdateTreatment
(
	@id int,
	@treatmentName varchar(45) ,
	@description varchar(45) ,
	@cost float ,
	@treatmentConditionID int ,
	@treatmentProviderID int
)
AS
BEGIN
	Update [treatment]
	SET treatmentName = @treatmentName, [description] = @description, cost = @cost, treatmentConditionID = @treatmentConditionID, treatmentProviderID = @treatmentProviderID
	WHERE treatmentID = @id
END
GO

CREATE PROC spUpdateApplication
(
	@id int,
	@applicationDate varchar(10) ,
	@status varchar(45) ,
	@applicationCustomerID varchar(9) ,
	@applicationConditionID int,
	@applicationProviderID int
)
AS
BEGIN
	Update [application]
	SET applicationDate = @applicationDate, [status] = @status, applicationCustomerID = @applicationCustomerID, applicationConditionID = @applicationConditionID, applicationProviderID = @applicationProviderID
	WHERE applicationID = @id
END
GO

CREATE PROC spSearchCustomer
(
	@id varchar(12)
)
AS
BEGIN
	SELECT * FROM customer WHERE customerID = @id;
END
GO

CREATE PROC spSearchProvider
(
	@id int
)
AS
BEGIN
	SELECT * FROM [provider] WHERE providerID = @id;
END
GO

CREATE PROC spSearchEmployee
(
	@id int
)
AS
BEGIN
	SELECT * FROM employee WHERE employeeID = @id;
END
GO

CREATE PROC spSearchCall
(
	@id int
)
AS
BEGIN
	SELECT * FROM call_history WHERE callID = @id;
END
GO

CREATE PROC spSearchAddress
(
	@id int
)
AS
BEGIN
	SELECT * FROM address WHERE addressID = @id;
END
GO

CREATE PROC spSearchAccount
(
	@id int
)
AS
BEGIN
	SELECT * FROM customer_account WHERE accountID = @id;
END
GO

CREATE PROC spSearchApplication
(
	@id int
)
AS
BEGIN
	SELECT * FROM application WHERE applicationID = @id;
END
GO

CREATE PROC spSearchCondition
(
	@id int
)
AS
BEGIN
	SELECT * FROM condition WHERE conditionID = @id;
END
GO

CREATE PROC spSearchCustomerHistory
(
	@id int
)
AS
BEGIN
	SELECT * FROM customer_history WHERE cusHistoryID = @id;
END
GO

CREATE PROC spSearchPolicy
(
	@id varchar(12)
)
AS
BEGIN
	SELECT * FROM policy WHERE policyID = @id;
END
GO

CREATE PROC spSearchProduct
(
	@id int
)
AS
BEGIN
	SELECT * FROM product WHERE productID = @id;
END
GO

CREATE PROC spSearchProductHistory
(
	@id int
)
AS
BEGIN
	SELECT * FROM product_history WHERE proHistoryID = @id;
END
GO

CREATE PROC spSearchTreatment
(
	@id int
)
AS
BEGIN
	SELECT * FROM treatment WHERE treatmentID = @id;
END
GO

CREATE PROC spAddressCount
AS
BEGIN
	SELECT TOP 1 * FROM [address] ORDER BY addressID DESC
END
GO

CREATE PROC spPolicyCount
AS
BEGIN
	SELECT TOP 1 SUBSTRING(policyID, 7, 6) AS id FROM policy ORDER BY id DESC
END
GO

CREATE PROC spCustomerCount
(
	@id varchar(1)
)
AS
BEGIN
	SELECT TOP 1 * FROM customer where customerID LIKE @id + '%' ORDER BY customerID DESC
END
GO

CREATE PROC spLogin
(
	@userName varchar(25),
	@password varchar(25)
)
AS
BEGIN
	SELECT role FROM employee where userName = @userName COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @password COLLATE SQL_Latin1_General_CP1_CS_AS
END
GO

CREATE PROC spDeleteApplication
(
	@id int
)
AS
BEGIN
	DELETE FROM application WHERE applicationID = @id;
END
GO

CREATE PROC spDeleteCondition
(
	@id int
)
AS
BEGIN
	DELETE FROM condition WHERE conditionID = @id;
	DELETE FROM application WHERE applicationConditionID = @id;
	DELETE FROM treatment WHERE treatmentConditionID = @id;
END
GO

CREATE PROC spDeleteCustomer
(
	@id varchar(9)
)
AS
BEGIN
	DECLARE @Aid int;
	SELECT @Aid = customerAddressID FROM customer where customerID = @id;

	DELETE FROM customer WHERE customerID = @id;
	DELETE FROM address WHERE addressID = @Aid;
	DELETE FROM customer_account WHERE accountCustomerID = @id;
	DELETE FROM call_history WHERE callCustomerID = @id;
	DELETE FROM customer_history WHERE historyCustomerID = @id;
	DELETE FROM application WHERE applicationCustomerID = @id;
END
GO

CREATE PROC spDeleteEmployee
(
	@id int
)
AS
BEGIN
	DELETE FROM employee WHERE employeeID = @id;
END
GO

--CREATE PROC spDeletePolicy
--(
--	@id varchar(12) 
--)
--AS
--BEGIN
--	Update [policy]
--	SET policyStstus = 'Deleted'
--	WHERE policyID = @id
--END
--GO

--CREATE PROC spDeleteProduct
--(
--	@id int 
--)
--AS
--BEGIN
--	Update [prodyct]
--	SET productStstus = 'Deleted'
--	WHERE productID = @id
--END
--GO

CREATE PROC spDeleteProvider
(
	@id int
)
AS
BEGIN
	DELETE FROM provider WHERE providerID = @id;
	DELETE FROM treatment WHERE treatmentProviderID = @id;
	DELETE FROM application WHERE applicationProviderID = @id;
END
GO

CREATE PROC spDeleteTreatment
(
	@id int
)
AS
BEGIN
	DELETE FROM treatment WHERE treatmentID = @id;
END
GO

INSERT INTO [address] (addressLine, city, province, postalCode)
VALUES ('25 James Street', 'Brits', 'North West', '0250');
INSERT INTO [address] (addressLine, city, province, postalCode)
VALUES ('34 Bedford Street', 'Pretoria', 'Gauteng', '0001');
INSERT INTO [address] (addressLine, city, province, postalCode)
VALUES ('09 Gert Road', 'Pretoria', 'Gauteng', '0102');
INSERT INTO [address] (addressLine, city, province, postalCode)
VALUES ('13 Peace Street', 'Pretoria', 'Gauteng', '0001');
INSERT INTO [address] (addressLine, city, province, postalCode)
VALUES ('54 Rian AVE', 'Pretoria', 'Gauteng', '0001');

INSERT INTO [provider] (providerName, status, province)
VALUES ('Groen Kloof', 'Aproved', 'North West');
INSERT INTO [provider] (providerName, status, province)
VALUES ('Medi Clinic', 'Aproved', 'Gauteng');
INSERT INTO [provider] (providerName, status, province)
VALUES ('YouHeal Hospital', 'Aproved', 'North West');


INSERT INTO [customer] (customerID, custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
VALUES ('E00000001' ,'Dylan', 'Ellis', '2000-12-02', '0012022823391', 'Male', 1, 'Parent', 1);
INSERT INTO [customer] (customerID, custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
VALUES ('D00000001' ,'Dian', 'de Vos', '2001-11-22', '0111227364812', 'Male', 2, 'Parent', 4);
INSERT INTO [customer] (customerID, custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
VALUES ('S00000001' ,'Luc', 'Szyndralewicz', '2000-01-10', '0001101200434', 'Male', 3, 'Parent', 2);
INSERT INTO [customer] (customerID, custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
VALUES ('C00000001' ,'Francois', 'Cornelius', '2000-05-25', '0005251102665', 'Male', 4, 'Parent', 5);
INSERT INTO [customer] (customerID, custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
VALUES ('J00000001' ,'Carissa', 'Janse', '2002-11-27', '0211271223391', 'Female', 5, 'Parent', 3);

INSERT INTO [employee] (empName, email, phoneNumber, [role], userName, [password])
VALUES ('Martin', 'martin@gamil.com', '0820912012', 'Call agent', 'martin123', '123Martin');
INSERT INTO [employee] (empName, email, phoneNumber, [role], userName, [password])
VALUES ('Aiden', 'aiden@gmail.com', '0982342365', 'Call agent', 'aiden123', '123Aiden');
INSERT INTO [employee] (empName, email, phoneNumber, [role], userName, [password])
VALUES ('Stefan', 'stefan@gamil.com', '0648721320', 'Manager', 'stefan123', '123Stefan');

INSERT INTO [policy] (policyID, policyName, price, installment, payout)
VALUES ('2021DA000001' ,'Full', 120000, 380, 100000);
INSERT INTO [policy] (policyID, policyName, price, installment, payout)
VALUES ('2019ZC000002' ,'Full', 134000, 385, 130000);
INSERT INTO [policy] (policyID, policyName, price, installment, payout)
VALUES ('2021JA000003' ,'Full', 203000, 400, 200000);
INSERT INTO [policy] (policyID, policyName, price, installment, payout)
VALUES ('2021EB000004' ,'Full', 320000, 450, 320000);
INSERT INTO [policy] (policyID, policyName, price, installment, payout)
VALUES ('2017HD000005' ,'Full', 100000, 350, 90000);

INSERT INTO [call_history] (callCustomerID, callEmployeeID, [start], [end], dateCreated)
VALUES ('E00000001', 1, '12:00:00', '12:30:00', '2022-10-14');
INSERT INTO [call_history] (callCustomerID, callEmployeeID, [start], [end], dateCreated)
VALUES ('S00000001', 3, '11:00:00', '11:30:00', '2022-10-17');
INSERT INTO [call_history] (callCustomerID, callEmployeeID, [start], [end], dateCreated)
VALUES ('J00000001', 1, '10:30:00', '11:00:00', '2022-10-16');
INSERT INTO [call_history] (callCustomerID, callEmployeeID, [start], [end], dateCreated)
VALUES ('J00000001', 2, '14:00:00', '14:30:00', '2022-10-17');

INSERT INTO [customer_account] (accountCustomerID, amountDue, installmentDate)
VALUES ('E00000001', 4800, '2022-10-30');
INSERT INTO [customer_account] (accountCustomerID, amountDue, installmentDate)
VALUES ('D00000001', 300, '2022-10-30');
INSERT INTO [customer_account] (accountCustomerID, amountDue, installmentDate)
VALUES ('E00000001', 1200, '2022-10-30');
INSERT INTO [customer_account] (accountCustomerID, amountDue, installmentDate)
VALUES ('S00000001', 500, '2022-10-30');
INSERT INTO [customer_account] (accountCustomerID, amountDue, installmentDate)
VALUES ('C00000001', 830, '2022-10-30');
INSERT INTO [customer_account] (accountCustomerID, amountDue, installmentDate)
VALUES ('J00000001', 2000, '2022-10-30');

INSERT INTO [condition] (conditionName, conitionCode, conditionPolicyID)
VALUES ('Cholestrol', 'COL', '2021DA000001');
INSERT INTO [condition] (conditionName, conitionCode, conditionPolicyID)
VALUES ('Diabetes', 'DIAB', '2019ZC000002');
INSERT INTO [condition] (conditionName, conitionCode, conditionPolicyID)
VALUES ('Acne', 'ACNE', '2021JA000003');

INSERT INTO [product] (policyDiscount, [availability], productPolicyID)
VALUES (0.4, 'Availible', '2021EB000004');
INSERT INTO [product] (policyDiscount, [availability], productPolicyID)
VALUES (0.5, 'Availible', '2021JA000003');
INSERT INTO [product] (policyDiscount, [availability], productPolicyID)
VALUES (0.3, 'Availible', '2019ZC000002');
INSERT INTO [product] (policyDiscount, [availability], productPolicyID)
VALUES (0.2, 'Availible', '2021DA000001');
INSERT INTO [product] (policyDiscount, [availability], productPolicyID)
VALUES (0.25, 'Availible', '2017HD000005');

INSERT INTO [product_history] ([start], [end], historyProductID)
VALUES ('2013-09-24', '2023-08-02', 1);
INSERT INTO [product_history] ([start], [end], historyProductID)
VALUES ('2012-11-29', '2022-10-19', 5);
INSERT INTO [product_history] ([start], [end], historyProductID)
VALUES ('2015-09-24', '2023-01-05', 2);
INSERT INTO [product_history] ([start], [end], historyProductID)
VALUES ('2018-02-15', '2022-11-21', 3);
INSERT INTO [product_history] ([start], [end], historyProductID)
VALUES ('2012-12-04', '2023-06-14', 4);

INSERT INTO [customer_history] ([start], [end], [active], historyCustomerID, historyProductHistoryID)
VALUES ('2012-07-06', '2022-11-29', 'Yes', 'J00000001', 1);
INSERT INTO [customer_history] ([start], [end], [active], historyCustomerID, historyProductHistoryID)
VALUES ('2013-04-22', '2021-10-15', 'Yes', 'D00000001', 2);
INSERT INTO [customer_history] ([start], [end], [active], historyCustomerID, historyProductHistoryID)
VALUES ('2017-07-28', '2023-11-17', 'No', 'S00000001', 3);
INSERT INTO [customer_history] ([start], [end], [active], historyCustomerID, historyProductHistoryID)
VALUES ('2014-10-15', '2022-12-08', 'Yes', 'C00000001', 4);
INSERT INTO [customer_history] ([start], [end], [active], historyCustomerID, historyProductHistoryID)
VALUES ('2018-08-10', '2022-06-14', 'Yes', 'E00000001', 5);

INSERT INTO [treatment]	(treatmentName, [description], cost, treatmentConditionID, treatmentProviderID)
VALUES ('Pill', 'Pill that lowwers Cholestrol levels', 20, 1, 1);
INSERT INTO [treatment]	(treatmentName, [description], cost, treatmentConditionID, treatmentProviderID)
VALUES ('Cream', 'A cream to improve redness', 20, 1, 1);
INSERT INTO [treatment]	(treatmentName, [description], cost, treatmentConditionID, treatmentProviderID)
VALUES ('Injection', 'Injection to balance out blood sugar', 20, 1, 1);

INSERT INTO [application] (applicationDate, [status], applicationCustomerID, applicationConditionID, applicationProviderID)
VALUES ('2022-10-24', 'Aproved', 'E00000001', 1, 3);
INSERT INTO [application] (applicationDate, [status], applicationCustomerID, applicationConditionID, applicationProviderID)
VALUES ('2022-11-02', 'Aproved', 'S00000001', 3, 2);


SELECT * FROM provider;
SELECT * FROM policy;
SELECT * FROM call_history;
SELECT * FROM customer;
SELECT * FROM employee;
SELECT * FROM customer_history;
SELECT * FROM customer_account;
SELECT * FROM product;
SELECT * FROM condition;
SELECT * FROM product_history;
SELECT * FROM treatment;
SELECT * FROM application;
SELECT * FROM address;