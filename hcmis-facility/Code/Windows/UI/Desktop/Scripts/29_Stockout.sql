CREATE TABLE [dbo].[Stockout](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StoreID] [int] NULL,
	[ItemID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[LastIndexedTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.Stockout] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Stockout]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Stockout_dbo.Items_ItemID] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
ON DELETE CASCADE

ALTER TABLE [dbo].[Stockout] CHECK CONSTRAINT [FK_dbo.Stockout_dbo.Items_ItemID]

