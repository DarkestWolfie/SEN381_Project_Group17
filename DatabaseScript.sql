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
  customerID int NOT NULL IDENTITY,
  custName varchar(45) ,
  custSurname varchar(45) ,
  dob date ,
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

CREATE TABLE [policy] 
(
  policyID int NOT NULL IDENTITY,
  policyName varchar(45) ,
  price float ,
  installment float ,
  payout float ,
  PRIMARY KEY (policyID)
);

CREATE TABLE [call_history] 
(
  callID int NOT NULL IDENTITY,
  callCustomerID int FOREIGN KEY REFERENCES customer (customerID),
  callEmployeeID int FOREIGN KEY REFERENCES employee (employeeID),
  [start] time  ,
  [end] time ,
  dateCreated date ,
  PRIMARY KEY (callID)
);

CREATE TABLE [customer_account] 
(
  accountID int NOT NULL IDENTITY,
  accountCustomerID int FOREIGN KEY REFERENCES customer (customerID),
  amountDue float ,
  installmentDate date ,
  PRIMARY KEY (accountID)
);

CREATE TABLE [condition] 
(
  conditionID int NOT NULL IDENTITY,
  conditionName varchar(45) ,
  conditionPolicyID int FOREIGN KEY REFERENCES policy (policyID),
  PRIMARY KEY (conditionID),
);

CREATE TABLE [product] 
(
  productID int NOT NULL IDENTITY,
  policyDiscount float ,
  [availability] varchar(45) ,
  productPolicyID int FOREIGN KEY REFERENCES policy (policyID),
  PRIMARY KEY (productID)
);

CREATE TABLE [product_history] 
(
  proHistoryID int NOT NULL IDENTITY,
  [start] date ,
  [end] date ,
  historyProductID int FOREIGN KEY REFERENCES product (productID),
  PRIMARY KEY (proHistoryID)
);

CREATE TABLE [customer_history] 
(
  cusHistoryID int NOT NULL IDENTITY,
  [start] date ,
  [end] date ,
  active varchar(45) ,
  historyCustomerID int FOREIGN KEY REFERENCES customer (customerID),
  historyProductHistoryID int FOREIGN KEY REFERENCES product_history (proHistoryID),
  PRIMARY KEY (cusHistoryID)
);

CREATE TABLE [treatment] 
(
  treatmentID int NOT NULL IDENTITY,
  treatmentName varchar(45) ,
  [description] varchar(45) ,
  cost float ,
  treatmentConditionID int FOREIGN KEY REFERENCES condition (conditionID),
  treatmentProviderID int FOREIGN KEY REFERENCES provider (providerID),
  PRIMARY KEY (treatmentID)
);

  CREATE TABLE [application] 
  (
  applicationID int NOT NULL IDENTITY,
  applicationDate date ,
  [status] varchar(45) ,
  applicationCustomerID int FOREIGN KEY REFERENCES customer (customerID),
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
	 @custName varchar(45) ,
	 @custSurname varchar(45) ,
	 @dob date ,
	 @idNumber varchar(13) ,
	 @gender varchar(45) ,
	 @familyID int ,
	 @familyRole varchar(45),
	 @customerAddressID int
)
AS
BEGIN
	INSERT INTO [customer]
	(custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
	VALUES (@custName, @custSurname, @dob, @idNumber, @gender, @familyID, @familyRole, @customerAddressID);
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
	@policyName varchar(45) ,
	@price float ,
	@installment float ,
	@payout float 
)
AS
BEGIN
	INSERT INTO [policy]
	(policyName, price, installment, payout)
	VALUES (@policyName, @price, @installment, @payout);
END
GO

CREATE PROC spAddCallHistory
(
	@callCustomerID int ,
	@callEmployeeID int ,
	@start time  ,
	@end time ,
	@dateCreated date
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
	@accountCustomerID int ,
	@amountDue float ,
	@installmentDate date 
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
	@conditionPolicyID int
)
AS
BEGIN
	INSERT INTO [condition]
	(conditionName, conditionPolicyID)
	VALUES (@conditionName, @conditionPolicyID);
END
GO

CREATE PROC spAddProduct
(
	@policyDiscount float ,
	@availability varchar(45) ,
	@productPolicyID int
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
	@start date ,
	@end date ,
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
	@start date ,
	@end date ,
	@active varchar(45) ,
	@historyCustomerID int ,
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
	@applicationDate date ,
	@status varchar(45) ,
	@applicationCustomerID int ,
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
	 @id int,
	 @custName varchar(45) ,
	 @custSurname varchar(45) ,
	 @dob date ,
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
	@id int,
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
	@callCustomerID int ,
	@callEmployeeID int ,
	@start time  ,
	@end time ,
	@dateCreated date
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
	@accountCustomerID int ,
	@amountDue float ,
	@installmentDate date 
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
	@conditionPolicyID int
)
AS
BEGIN
	Update [condition]
	SET conditionName = @conditionName, conditionPolicyID = @conditionPolicyID
	WHERE conditionID = @id
END
GO

CREATE PROC spUpdateProduct
(
	@id int,
	@policyDiscount float ,
	@availability varchar(45) ,
	@productPolicyID int
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
	@start date ,
	@end date ,
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
	@start date ,
	@end date ,
	@active varchar(45) ,
	@historyCustomerID int ,
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
	@applicationDate date ,
	@status varchar(45) ,
	@applicationCustomerID int ,
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
	@id int
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

USE ukupholisa
GO

INSERT INTO [address] (addressLine, city, province, postalCode)
VALUES ('25 James Street', 'Brits', 'North West', '0250');

INSERT INTO [provider] (providerName, status, province)
VALUES ('Groen Kloof', 'Aproved', 'North West');

INSERT INTO [customer] (custName, custSurname, dob, idNumber, gender, familyID, familyRole, customerAddressID)
VALUES ('Dylan', 'Ellis', '2000-12-02', '0012022823391', 'Male', 1, 'Parent', 1);

INSERT INTO [employee] (empName, email, phoneNumber, [role], userName, [password])
VALUES ('Dian', 'de Vos', '0820912012', 'Call agent', 'Dianing', 'VosDeDian');

INSERT INTO [policy] (policyName, price, installment, payout)
VALUES ('Full', 120000, 380, 100000);

INSERT INTO [call_history] (callCustomerID, callEmployeeID, [start], [end], dateCreated)
VALUES (1, 1, '12:00:00', '12:30:00', '2022-10-14');

INSERT INTO [customer_account] (accountCustomerID, amountDue, installmentDate)
VALUES (1, 4800, '2022-10-30');

INSERT INTO [condition] (conditionName, conditionPolicyID)
VALUES ('Cholestrol', 1);

INSERT INTO [product] (policyDiscount, [availability], productPolicyID)
VALUES (0.3, 'Availible', 1);

INSERT INTO [product_history] ([start], [end], historyProductID)
VALUES ('2013-09-24', '2023-08-02', 1);

INSERT INTO [customer_history] ([start], [end], [active], historyCustomerID, historyProductHistoryID)
VALUES ('2012-07-06', '2022-11-29', 'Yes', 1, 1);

INSERT INTO [treatment]	(treatmentName, [description], cost, treatmentConditionID, treatmentProviderID)
VALUES ('Injection', 'Injection for common cold', 20, 1, 1);

INSERT INTO [application] (applicationDate, [status], applicationCustomerID, applicationConditionID, applicationProviderID)
VALUES ('2022-10-24', 'Aproved', 1, 1, 1);

USE ukupholisa
GO

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