USE [Team_1]
GO

INSERT INTO [dbo].[Quotes]
           ([AgentId]
           ,[IsSubmitted]
           ,[DeviceType]
           ,[CreationDate]
           ,[SubmissionDate]
           ,[PolicyHolderFName]
           ,[PolicyHolderLName]
           ,[AddressLine1]
           ,[AddressLine2]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[PolicyHolderSsn]
           ,[PolicyHolderDOB]
           ,[LessThan3YearsDriving]
           ,[PreviousCarrier]
           ,[MovingViolationInLast5Years]
           ,[ClaimInLast5Years]
           ,[ForceMultiCarDiscount]
           ,[QuotePrice])
     VALUES
           ('fwoolnough0@aia.com', 1, 'Mobile', GETDATE(), GETDATE(), 'Florie', 'Woolnough','3 Moose Avenue', 'Room 183', 'Chico', 'CA', 95973, '413682505', '1966-11-21', 1, 'Pervasive', 1, 0, 1, 2434.83),
		   ('nmanklow1@creativecommons.org', 1,	'Mobile', 2023-02-13, 2023-08-18, 'Nickolaus', 'Manklow', '50645 Utah Court',null,'Denver',	'CO',	80204,	'897276586','1975-04-17', 0, 'Lizard', 0,0,1,7598.12)
GO


