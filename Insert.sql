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