
CREATE TABLE [dbo].[DisposalDelete](
	[ID] [int] NOT NULL,
	[ItemID] [int] NULL,
	[StoreId] [int] NULL,
	[ReasonId] [int] NULL,
	[Quantity] [bigint] NULL,
	[Date] [datetime] NULL,
	[ApprovedBy] [varchar](50) NULL,
	[Losses] [bit] NULL,
	[BatchNo] [varchar](50) NULL,
	[Remark] [text] NULL,
	[Cost] [float] NULL,
	[RefNo] [varchar](50) NULL,
	[EurDate] [datetime] NULL,
	[RecID] [int] NULL
	
 CONSTRAINT [PK_DisposalDelete] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


SET ANSI_PADDING OFF

ALTER TABLE [dbo].[DisposalDelete]  WITH CHECK ADD  CONSTRAINT [FK_DisposalDelete_DisposalReasons] FOREIGN KEY([ReasonId])
REFERENCES [dbo].[DisposalReasons] ([ID])

ALTER TABLE [dbo].[DisposalDelete] CHECK CONSTRAINT [FK_DisposalDelete_DisposalReasons]

ALTER TABLE [dbo].[DisposalDelete]  WITH CHECK ADD  CONSTRAINT [FK_DisposalDelete_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])

ALTER TABLE [dbo].[DisposalDelete] CHECK CONSTRAINT [FK_DisposalDelete_Items]

ALTER TABLE [dbo].[DisposalDelete] ADD  CONSTRAINT [DF_DisposalDelete_Losses]  DEFAULT ((1)) FOR [Losses]


