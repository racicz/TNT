alter table subject
alter column TownId int null
GO

alter table OrderDetail
alter column DeliveredKg decimal(12,3) not null
GO

alter table OrderDetail
alter column OrderKg decimal(12,3) not null
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_save_order] 
(
	@Id int,
	@OrderNo int,
	@OrderDate varchar(10),
	@OrderTime varchar(10),
	@DeliveryDate varchar(10),
	@DeliveryTime varchar(10),
	@SubjectId int,
	@HomePhone varchar(50),
	@CellPhone varchar(50),
	@Email varchar(50),
	@Name varchar(50),
	@TownName varchar(50),
	@Details tp_details READONLY,
	@msg varchar(8000) out
)
AS
BEGIN
	
	declare @townId int = 0,
			@OrderId int, @FishTypeId int, @FishName varchar(50), @StatusId int,
			@OrderKg decimal(12,3),@DeliveredKg decimal(12,3),
			@Notes varchar(max),@AmountDue decimal(12,2),@AmountPaid decimal(12,2), 
			@Preparations varchar(10), @Status varchar(1), @cnt int,
			@przena int, @dimljena int, @pohovana int
		    
	SET NOCOUNT ON;
	
begin try
	begin tran	

	if len(@TownName) > 0
		begin
			set @townId = 0;

			select @townId = TownId
				from Town
			where TownName = rtrim(@TownName);

			if @townId = 0
				begin
					insert into Town
						values(@TownName);

					set @townId = @@IDENTITY;
				end;
		end;

	if len(@Name) > 0 and @SubjectId = 0
		begin
			
			if @townId > 0
				begin
					select @SubjectId = subject.SubjectId
						from Person inner join
							 subject on person.subjectid = subject.subjectid 
					where Name = rtrim(@Name) and townid = @townId;
				end
			else
				begin
					select @SubjectId = subject.SubjectId
						from Person inner join
							 subject on person.subjectid = subject.subjectid 
					where Name = rtrim(@Name);
				end

			if @SubjectId = 0
				begin
					insert into Subject
						values(case when @townId = 0 then null else @townId end, 'P');

					set @SubjectId = @@IDENTITY;
				end;

			insert into person
				values(@SubjectId, @Name);
		end;

	

		
		if @Id = 0
			begin
				select @Id = orderid
					from [Order]
				where OrderNumber = @OrderNo;
				
				if @Id = 0
					begin 
						insert into [Order]
								values(@SubjectId,@OrderNo, @OrderDate, @OrderTime, @DeliveryDate, @DeliveryTime);

						set @Id = @@identity;

						update AutoNumber
							set NextOrderNumber = NextOrderNumber + 1;
					end;
				else
					begin
						if not exists (select *
											from [Order]
										where OrderNumber = @OrderNo and DeliveryDate = @DeliveryDate and DeliveryTime = @DeliveryTime)
							begin
								insert into [Order]
									values(@SubjectId,@OrderNo, @OrderDate, @OrderTime, @DeliveryDate, @DeliveryTime);

								set @Id = @@identity;
							end;
					end;
			end;
		else
			begin
				update [Order]
					set SubjectId = @SubjectId,
						OrderNumber = @OrderNo,
						OrderDate = @OrderDate,
						OrderTime = @OrderTime,
						DeliveryDate = @DeliveryDate,
						DeliveryTime = @DeliveryTime
				where orderid = @Id;
			end;

		if len(isnull(@HomePhone,'')) > 0
			begin
				if exists (select * from Contact
							where SubjectId = @SubjectId and SubjectContactTypeId = 1)
					begin
						update Contact
							set ContactValue = @HomePhone
						where subjectid = @SubjectId and SubjectContactTypeId = 1;
					end;
				else
					begin
						insert into Contact
							values(@SubjectId, 1, @HomePhone);
					end;
			end;

		if len(isnull(@CellPhone,'')) > 0
			begin
				if exists (select * from Contact
							where SubjectId = @SubjectId and SubjectContactTypeId = 2)
					begin
						update Contact
							set ContactValue = @CellPhone
						where subjectid = @SubjectId and SubjectContactTypeId = 2;
					end;
				else
					begin
						insert into Contact
							values(@SubjectId, 2, @CellPhone);
					end;
			end;

		if len(isnull(@Email,'')) > 0
			begin
				if exists (select * from Contact
							where SubjectId = @SubjectId and SubjectContactTypeId = 3)
					begin
						update Contact
							set ContactValue = @Email
						where subjectid = @SubjectId and SubjectContactTypeId = 3;
					end;
				else
					begin
						insert into Contact
							values(@SubjectId, 3, @Email);
					end;
			end;


		declare curorder cursor for
			select OrderDetailId,FishTypeId, FishName, StatusId,OrderKg,DeliveredKg,
					Notes,AmountDue,AmountPaid,Preparations, Status
				from @Details;
			
		open curorder;
		
		fetch next from curorder
			into @OrderId,@FishTypeId, @FishName, @StatusId,
					@OrderKg,@DeliveredKg,
					@Notes,@AmountDue,@AmountPaid,@Preparations, @Status;

		while @@fetch_status = 0
			begin
				set @przena = 0;
				set @dimljena = 0;
				set @pohovana = 0;

				if len(isnull(@Preparations,'')) > 0
					begin
						set @cnt = 1;

						select  @przena = dbo.split(@Preparations,',',@cnt);
							set @cnt = @cnt + 1;
						select  @dimljena = dbo.split(@Preparations,',',@cnt);
							set @cnt = @cnt + 1;
						select  @pohovana = dbo.split(@Preparations,',',@cnt);
							set @cnt = @cnt + 1;
					end;

				if @FishTypeId = 0
					begin
						if len(@FishName) > 0
						begin
							select @FishTypeId = FishTypeId
								from FishType
							where Description = rtrim(@FishName);

							if @FishTypeId = 0
								begin
									insert into FishType
										values(@FishName, 0, 0);

									set @FishTypeId = @@IDENTITY;
								end;
						end;
					end;

				

				if @OrderId = 0
					begin
						insert into OrderDetail
							values(@Id, @FishTypeId, @StatusId, @OrderKg,
									@DeliveredKg,@Notes,@AmountDue,@AmountPaid, getdate(), 0);

						set @OrderId = @@IDENTITY;
					end;
				else
					begin
						if @Status = 'D'
							begin
								update OrderDetail
									set Deleted = 1
								where OrderDetailId = @OrderId;
							end;
						else
							begin
								update OrderDetail
									set FishTypeId = @FishTypeId,
										StatusId = @StatusId,
										OrderKg = @OrderKg,
										DeliveredKg = @DeliveredKg,
										Notes = @Notes,
										AmountDue = @AmountDue,
										AmountPaid = @AmountPaid
								where OrderDetailId = @OrderId;
							end;
					end;

					delete from OrderDetailPreparation
						where OrderDetailId = @OrderId;

					if @przena > 0
						insert into OrderDetailPreparation
							values(@przena, @OrderId);

					if @dimljena > 0
						insert into OrderDetailPreparation
							values(@dimljena, @OrderId);

					if @pohovana > 0
						insert into OrderDetailPreparation
							values(@pohovana, @OrderId);

					fetch next from curorder
						into @OrderId,@FishTypeId, @FishName, @StatusId,
								@OrderKg,@DeliveredKg,
								@Notes,@AmountDue,@AmountPaid,@Preparations, @Status;
				end;


			close curorder;
			deallocate curorder;

	commit tran;
	return @Id;
end try
	begin catch
		set @msg = 
				N'Error: [' + convert(varchar,error_number()) + '] Procedure: [' + error_procedure() + 
						'] Line: [' + convert(varchar,error_line()) + '] Message: [' + error_message() + ']';
		rollback tran;
		return -99;
	end catch;
END

/****** Object:  StoredProcedure [dbo].[Order_Report]    Script Date: 11/30/2016 1:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Order_Report] 
(
	@no int,
	@date varchar(10),
	@time varchar(10)
)
AS
BEGIN
	declare @sql varchar(max)

	SET NOCOUNT ON;
	
	set @sql = 'Select ft.Description [FishType], AmountDue, AmountPaid, OrderNumber, OrderKg, DeliveredKg, Convert(date,DeliveryDate) as DeliveryDate, FORMAT(convert(datetime,DeliveryTime),''HH:mm'') as DeliveryTime, Name, ph.phone 
				from [Order] ord inner join
					 OrderDetail od on ord.OrderId = od.OrderId inner join
					 FishType ft on od.fishtypeid = ft.fishtypeid inner join
					 Person p on ord.subjectid = p.subjectid left join
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

 exec(@sql);
END

GO
