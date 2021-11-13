select Price, deliveredkg, ((case when price is null then 0 else price end) * DeliveredKg )
	from OrderDetail inner join
		 FishType on OrderDetail.FishTypeId = FishType.FishTypeId


update OrderDetail 
set amountpaid = ((case when price is null then 0 else price end) * DeliveredKg )
from FishType 
where  OrderDetail.FishTypeId = FishType.FishTypeId
GO
