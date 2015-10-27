CREATE PROCEDURE [dbo].[SOHByUnitByProgram]
    @storeid INT ,
    @month INT ,
    @year INT ,
    @days INT
AS 
    BEGIN
        DECLARE @tempdate VARCHAR(20)
	
        DECLARE @amcrange INT
        DECLARE @min INT
        DECLARE @max INT
        DECLARE @eop FLOAT

        SELECT  @amcrange = AMCRange ,
                @eop = EOP ,
                @min = MIN ,
                @max = MAX
        FROM    GeneralInfo 
	
        DECLARE @rangedate DATETIME
        DECLARE @todate DATETIME
        DECLARE @fromdate DATETIME
	
	
        SELECT  @tempdate = CAST(@month AS VARCHAR) + '/'
                + CAST(@days AS VARCHAR) + '/' + CAST(@year AS VARCHAR) 
        SELECT  @todate = CAST(@tempdate AS DATETIME)
        SELECT  @fromdate = CASE WHEN MONTH(@todate) <= 10
                                 THEN CAST('11/1/'
                                      + ( CAST(( @year - 1 ) AS VARCHAR) ) AS DATETIME)
                                 ELSE CAST('11/1/'
                                      + ( CAST(( @year ) AS VARCHAR) ) AS DATETIME)
                            END	
        SELECT  @rangedate = DATEADD(month, 0 - @amcrange, @todate)
				
        SELECT  t.* ,
                [Status] = CASE WHEN t.SOH IS NULL
                                     OR t.SOH = 0 THEN 'Stock Out'
                                WHEN t.SOH < t.EOP THEN 'Below EOP'
                                WHEN t.SOH < ( t.EOP * 1.25 ) THEN 'Near EOP'
                                WHEN t.SOH > t.[Max]
                                     AND t.AMC > 0 THEN 'Over Stocked'
                                ELSE 'Normal'
                           END ,
                ( t.SOH - ( t.Expired ) ) AS Dispatchable
        FROM    ( SELECT    CASE WHEN vw.ID IN ( SELECT DISTINCT
                                                        ItemID
                                                 FROM   ReceiveDoc
                                                 WHERE  StoreID = @storeid
                                                        AND UnitID = iu.ID )
                                 THEN 1
                                 ELSE 0
                            END AS EverReceived ,
                            iu.ID AS UnitID ,
                            ISNULL(rd.Quantity, 0) AS Received ,
                            ISNULL(rd.QuantityLeft, 0) AS QuantityLeft ,
                            ISNULL(id.Quantity, 0) AS Issued ,
                            ISNULL(id2.Quantity, 0) AS IssuedMonth ,
                            ISNULL(loss.Quantity, 0) AS Lost ,
                            ISNULL(adj.Quantity, 0) AS Adjusted ,
                            ISNULL(amc.Quantity, 0) AS AMC ,
                            ISNULL(dos.Quantity, 0) AS DOS ,
                            ( ISNULL(bb.Quantity, 0) + ISNULL(rd.Quantity, 0)
                              + ISNULL(adj.Quantity, 0) - ISNULL(id.Quantity,
                                                              0)
                              - ISNULL(loss.Quantity, 0) ) AS SOH ,
                            ISNULL(amc.Quantity * @min, 0) AS Min ,
                            ISNULL(amc.Quantity * @max, 0) AS Max ,
                            ISNULL(amc.Quantity * @eop, 0) AS EOP ,
                            ISNULL(ed.Quantity, 0) AS Expired ,
                            ISNULL(nEx.Quantity, 0) AS NearExpiry ,
                            vw.ID ,
                            vw.FullItemName ,
                            vw.StockCode ,
                            vw.Unit ,
                            vw.Name AS Type ,
                            vw.TypeID,
                            p.ID AS ProgramID ,
                            p.Name AS ProgramName
                  FROM      vwGetAllItems vw
                            LEFT JOIN ProgramProduct pp ON vw.ID = pp.ItemID
                            LEFT JOIN Programs p ON pp.ProgramID = p.ID
                            LEFT JOIN ItemUnit iu ON vw.ID = iu.ItemID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                SUM(Quantity) Quantity ,
                                                SUM(QuantityLeft) QuantityLeft
                                        FROM    ReceiveDoc
                                        WHERE   StoreID = @storeid
                                                AND ( date BETWEEN @fromdate AND @todate )
                                        GROUP BY ItemID ,
                                                UnitID
                                      ) AS rd ON rd.ItemID = vw.ID
                                                 AND rd.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                SUM(Quantity) Quantity
                                        FROM    IssueDoc
                                        WHERE   StoreID = @storeid
                                                AND ( date BETWEEN @fromdate AND @todate )
                                        GROUP BY ItemID ,
                                                UnitID
                                      ) AS id ON id.ItemID = vw.ID
                                                 AND id.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                SUM(Quantity) Quantity
                                        FROM    IssueDoc
                                        WHERE   StoreID = @storeid
                                                AND ( YEAR(date) = @year
                                                      AND MONTH(date) = @month
                                                    )
                                        GROUP BY ItemID ,
                                                 UnitID
                                      ) AS id2 ON id2.ItemID = vw.ID
                                                  AND id2.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                SUM(PhysicalInventory) Quantity
                                        FROM    YearEnd
                                        WHERE   StoreID = @storeid
                                                AND Year = YEAR(@fromdate)
                                        GROUP BY ItemID ,
                                                UnitID
                                      ) AS bb ON bb.ItemID = vw.ID
                                                 AND bb.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                SUM(QuantityLeft) Quantity
                                        FROM    ReceiveDoc
                                        WHERE   StoreID = @storeid
                                                AND ExpDate < GETDATE()
                                        GROUP BY ItemID ,
                                                 UnitID
                                      ) AS ed ON ed.ItemID = vw.ID
                                                 AND ed.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                rd.UnitID ,
                                                SUM(QuantityLeft) Quantity
                                        FROM    ReceiveDoc rd
                                                JOIN vwGetAllItems v ON rd.ItemID = v.ID
                                        WHERE   StoreID = @storeid
                                                AND ExpDate BETWEEN GETDATE()
                                                            AND
                                                              DATEADD(day,
                                                              v.NearExpiryTrigger,
                                                              GETDATE())
                                        GROUP BY ItemID ,
                                                rd.UnitID
                                      ) AS nEx ON nEx.ItemID = vw.ID
                                                  AND nEx.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitId ,
                                                MAX(AmcWithDos) AS Quantity
                                        FROM    AmcReport ar
                                        WHERE   ar.StoreID = @storeid
                                        GROUP BY ItemID ,
                                                 UnitID
                                      ) AS amc ON amc.ItemID = vw.ID
                                                  AND amc.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                MAX(DaysOutOfStock) AS Quantity
                                        FROM    AmcReport ar
                                        WHERE   ar.StoreID = @storeid
                                        GROUP BY ItemID ,
                                                 UnitID
                                      ) AS dos ON dos.ItemID = vw.ID
                                                  AND dos.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                SUM(Quantity) Quantity
                                        FROM    Disposal
                                        WHERE   StoreID = @storeid
                                                AND ( date BETWEEN @fromdate AND @todate )
                                                AND Losses = 1
                                        GROUP BY ItemID ,
                                                UnitID
                                      ) AS loss ON loss.ItemID = vw.ID
                                                   AND loss.UnitID = iu.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                UnitID ,
                                                SUM(Quantity) Quantity
                                        FROM    Disposal
                                        WHERE   StoreID = @storeid
                                                AND ( date BETWEEN @fromdate AND @todate )
                                                AND Losses = 0
                                        GROUP BY ItemID ,
                                                UnitID
                                      ) AS adj ON adj.ItemID = vw.ID
                                                  AND adj.UnitID = iu.ID
                  WHERE     vw.IsInHospitalList = 1
                            AND vw.ID IN (
                            SELECT  ItemID
                            FROM    vwGetAllItems vw
                                    JOIN ReceiveDoc rd ON vw.ID = rd.ItemID
                                                          AND iu.ID = rd.UnitID )
                ) t
        ORDER BY t.FullItemName
    END
