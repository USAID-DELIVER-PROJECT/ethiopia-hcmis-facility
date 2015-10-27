CREATE TABLE [dbo].[IssueDocDeleted](
[ID] [int] NOT NULL,
[ItemID] [int] NULL,
[StoreId] [int] NULL,
[ReceivingUnitID] [int] NULL,
[LocalBatchNo] [varchar](50) NULL,
[Quantity] [bigint] NULL,
[Date] [datetime] NULL,
[IsTransfer] [bit] NULL,
[IssuedBy] [varchar](50) NULL,
[Remark] [text] NULL,
[RefNo] [varchar](50) NULL,
[BatchNo] [varchar](50) NULL,
[IsApproved] [bit] NULL,
[Cost] [float] NULL,
[NoOfPack] [int] NULL,
[QtyPerPack] [int] NULL,
[DURequestedQty] [bigint] NULL,
[DUSOH] [bigint] NULL,
[EurDate] [datetime] NULL,
[OrderID] [int] NULL,
[RecievDocID] [int] NULL,
[RecomendedQty] [bigint] NULL,
CONSTRAINT [PK_IssueDocDeleted] PRIMARY KEY CLUSTERED 
(
[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]