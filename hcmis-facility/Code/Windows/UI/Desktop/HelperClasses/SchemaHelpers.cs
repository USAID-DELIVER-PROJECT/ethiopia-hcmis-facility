using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PharmInventory.HelperClasses
{
    class SchemaHelpers
    {
       public static void ExecuteNonQuery(string query)
        {
            string sqlConnectionString = StockoutIndexBuilder.Settings.ConnectionString;
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public static void CreateAMCReportTable()
        {
                                    string query = @"CREATE TABLE [dbo].[AmcReport](
	                                [ID] [int] IDENTITY(1,1) NOT NULL,
	                                [ItemID] [int] NULL,
	                                [StoreID] [int] NULL,
	                                [AmcRange] [int] NULL,
	                                [IssueInAmcRange] [float] NULL,
	                                [DaysOutOfStock] [int] NULL,
	                                [AmcWithDos] [float] NULL,
	                                [AmcWithoutDos] [float] NULL,
	                                [LastIndexedTime] [datetime] NULL,
                                 CONSTRAINT [PK_AmcReport] PRIMARY KEY CLUSTERED 
                                (
	                                [ID] ASC
                                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                                ) ON [PRIMARY]


                                ALTER TABLE [dbo].[AmcReport]  WITH CHECK ADD  CONSTRAINT [FK_AmcReport_Items] FOREIGN KEY([ItemID])
                                REFERENCES [dbo].[Items] ([ID])

                                ALTER TABLE [dbo].[AmcReport] CHECK CONSTRAINT [FK_AmcReport_Items]";
            try
            {
                ExecuteNonQuery(query);
            }
            catch
            {

            }

        }
        public static void CreateStockOutTable()
        {
            string query = @"CREATE TABLE [dbo].[Stockout](
	                        [ID] [int] IDENTITY(1,1) NOT NULL,
	                        [StoreID] [int] NULL,
	                        [ItemID] [int] NOT NULL,
	                        [StartDate] [datetime] NOT NULL,
	                        [EndDate] [datetime] NOT NULL,
                         CONSTRAINT [PK_dbo.Stockout] PRIMARY KEY CLUSTERED 
                        (
	                        [ID] ASC
                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                        ) ON [PRIMARY]


                        ALTER TABLE [dbo].[Stockout]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Stockout_dbo.Items_ItemID] FOREIGN KEY([ItemID])
                        REFERENCES [dbo].[Items] ([ID])
                        ON DELETE CASCADE

                        ALTER TABLE [dbo].[Stockout] CHECK CONSTRAINT [FK_dbo.Stockout_dbo.Items_ItemID]";
            try
            {
                ExecuteNonQuery(query);
            }
            catch
            {

            }

        }
        public static void CreateDisposalDeleteTable()
        {
            string query = @"CREATE TABLE [dbo].[DisposalDelete](
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
	                    [RecID] [int] NULL,
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
                    ALTER TABLE [dbo].[DisposalDelete] ADD  CONSTRAINT [DF_DisposalDelete_Losses]  DEFAULT ((1)) FOR [Losses]";
            try
            {
                ExecuteNonQuery(query);
            }
            catch
            {

            }

        }

        public static void CreateReceiveDocDeletedTable()
        {
            string query = @"CREATE TABLE [dbo].[ReceiveDocDeleted](
	                            [ID] [int] NOT NULL,
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
	                            [StoreID] [int] NULL,
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
                             CONSTRAINT [PK_ReceiveDocDeleted] PRIMARY KEY CLUSTERED 
                            (
	                            [ID] ASC
                            )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                            ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


                            SET ANSI_PADDING OFF


                            ALTER TABLE [dbo].[ReceiveDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveDocDeleted_Items] FOREIGN KEY([ItemID])
                            REFERENCES [dbo].[Items] ([ID])

                            ALTER TABLE [dbo].[ReceiveDocDeleted] CHECK CONSTRAINT [FK_ReceiveDocDeleted_Items]

                            ALTER TABLE [dbo].[ReceiveDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveDocDeleted_Manufactures] FOREIGN KEY([ManufacturerId])
                            REFERENCES [dbo].[Manufacturers] ([ID])

                            ALTER TABLE [dbo].[ReceiveDocDeleted] CHECK CONSTRAINT [FK_ReceiveDocDeleted_Manufactures]

                            ALTER TABLE [dbo].[ReceiveDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveDocDeleted_Supplier] FOREIGN KEY([SupplierID])
                            REFERENCES [dbo].[Supplier] ([ID])


                            ALTER TABLE [dbo].[ReceiveDocDeleted] CHECK CONSTRAINT [FK_ReceiveDocDeleted_Supplier]


                            ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_Out]  DEFAULT ((0)) FOR [Out]


                            ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_IsApproved]  DEFAULT ((0)) FOR [IsApproved]


                            ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_QuantityLeft]  DEFAULT ((0)) FOR [QuantityLeft]


                            ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_NoOfPack]  DEFAULT ((0)) FOR [NoOfPack]


                            ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_QtyPerPack]  DEFAULT ((0)) FOR [QtyPerPack]";
            try
            {
                ExecuteNonQuery(query);
            }
            catch
            {

            }

        }
        public static void CreateIssueDocDeletedTable()
        {
            string query = @"CREATE TABLE [dbo].[IssueDocDeleted](
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
                        )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


                        SET ANSI_PADDING OFF

                        ALTER TABLE [dbo].[IssueDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_IssueDocDeleted_Items] FOREIGN KEY([ItemID])
                        REFERENCES [dbo].[Items] ([ID])

                        ALTER TABLE [dbo].[IssueDocDeleted] CHECK CONSTRAINT [FK_IssueDocDeleted_Items]

                        ALTER TABLE [dbo].[IssueDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_IssueDocDeleted_Order] FOREIGN KEY([OrderID])
                        REFERENCES [dbo].[Order] ([ID])

                        ALTER TABLE [dbo].[IssueDocDeleted] CHECK CONSTRAINT [FK_IssueDocDeleted_Order]

                        ALTER TABLE [dbo].[IssueDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_IssueDocDeleted_ReceivingUnits] FOREIGN KEY([ReceivingUnitID])
                        REFERENCES [dbo].[ReceivingUnits] ([ID])

                        ALTER TABLE [dbo].[IssueDocDeleted] CHECK CONSTRAINT [FK_IssueDocDeleted_ReceivingUnits]


                        ALTER TABLE [dbo].[IssueDocDeleted] ADD  CONSTRAINT [DF_IssueDocDeleted_IsTransfer]  DEFAULT ((0)) FOR [IsTransfer]


                        ALTER TABLE [dbo].[IssueDocDeleted] ADD  CONSTRAINT [DF_IssueDocDeleted_NoOfPack]  DEFAULT ((0)) FOR [NoOfPack]


                        ALTER TABLE [dbo].[IssueDocDeleted] ADD  CONSTRAINT [DF_IssueDocDeleted_QtyPerPack]  DEFAULT ((0)) FOR [QtyPerPack]";
            try
            {
                ExecuteNonQuery(query);
            }
            catch
            {

            }

        }

    }
}
