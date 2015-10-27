CREATE TABLE [dbo].[Transfer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BatchNo] [varchar](50) NULL,
	[ItemID] [int] NULL,
	[SupplierID] [int] NULL,
	[Quantity] [bigint] NULL,
	[Date] [datetime] NULL,
	[ExpDate] [datetime] NULL,
	[Out] [bit] NULL,
	[ReceivedStatus] [int] NULL,
	[ReceivedBy] [varchar](50) NULL,
	[Remark] [text] NULL,
	[FromStoreID] [int] NULL,
	[ToStoreID] [int] NULL,
	[LocalBatchNo] [varchar](50) NULL,
	[RefNo] [varchar](50) NULL,
	[Cost] [float] NULL,
	[IsApproved] [bit] NULL,
	[ManufacturerId] [int] NULL,
	[QuantityLeft] [bigint] NULL,
	[NoOfPack] [int] NULL,
	[QtyPerPack] [int] NULL,
	[BoxLevel] [int] NULL,
	[EurDate] [datetime] NULL,
	[SubProgramID] [int] NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]