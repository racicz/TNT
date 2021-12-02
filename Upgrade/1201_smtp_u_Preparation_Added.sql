USE [TNT]
GO
/****** Object:  StoredProcedure [dbo].[Order_Report]    Script Date: 12/2/2021 1:03:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[Order_Report] 
(
	@no int,
	@date varchar(10),
	@time varchar(10)
)
AS
BEGIN
	declare @sql varchar(max)

	SET NOCOUNT ON;
	
	set @sql = 'Select ft.Description [FishType], case when pr.Description is null then '''' else pr.Description end [Preparation],  AmountDue, AmountPaid, OrderNumber, OrderKg, PricePerKg, 
					DeliveredKg, Convert(date,DeliveryDate) as DeliveryDate, FORMAT(convert(datetime,DeliveryTime),''HH:mm'') as DeliveryTime, 
					Name, ph.phone
							from [Order] ord inner join
								 OrderDetail od on ord.OrderId = od.OrderId inner join
								 FishType ft on od.fishtypeid = ft.fishtypeid inner join
								 Person p on ord.subjectid = p.subjectid left join 
								 OrderDetailPreparation odp on od.OrderDetailId = odp.OrderDetailId left join
								 Preparation pr on odp.PreparationId = pr.PreparationId left join
								 (select SubjectId, ContactValue [Phone]
										from Contact
									where  subjectcontacttypeid = 2) as ph on p.SubjectId = ph.SubjectId
							where od.Deleted = 0 '

	if len(@date) > 0
		set @sql = @sql + ' and Convert(date,DeliveryDate) = ' + '''' + @date + ''''

	if len(@time) > 0
		set @sql = @sql + ' and Convert(time,DeliveryTime) = ' + '''' + @time + ''''

	if @no > 0
		set @sql = @sql + ' and OrderNumber = ' + Convert(varchar,@no)

 set @sql = @sql + ' Order By ft.Description'
 exec(@sql);
END
GO

Update [dbo].[Preparation]
set Description = 'Pržena'
where PreparationId = 1
GO

Update [dbo].[Preparation]
set Description = 'Sveža'
where PreparationId = 4
GO

Update [dbo].[Preparation]
set Description = 'Očišćena'
where PreparationId = 5
GO