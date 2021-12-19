DBCC CHECKIDENT ('[Preparation]', RESEED, 5);
GO

insert into Preparation
values('Dimljena & Pržena')
GO

insert into Preparation
values('Pečena na roštilju')
GO

SELECT *
  FROM [TNT].[dbo].[Preparation]


