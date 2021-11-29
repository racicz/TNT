alter table OrderDetail
add PreparationId [int] NULL
GO

ALTER TABLE [dbo].OrderDetail  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Preparation] FOREIGN KEY([PreparationId])
REFERENCES [dbo].[Preparation] ([PreparationId])
GO