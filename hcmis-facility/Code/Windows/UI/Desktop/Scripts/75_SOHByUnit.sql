Create PROCEDURE [dbo].[SOHByUnit] @storeid int, 
                                   @month   int, 
                                   @year    int, 
                                   @days    int 
AS 
  BEGIN 
      DECLARE @tempdate varchar(20) 
      DECLARE @amcrange int 
      DECLARE @min int 
      DECLARE @max int 
      DECLARE @eop float 

      SELECT @amcrange = AMCRange, 
             @eop = EOP, 
             @min = MIN, 
             @max = MAX 
      FROM   GeneralInfo 

      DECLARE @rangedate datetime 
      DECLARE @todate datetime 
      DECLARE @fromdate datetime 

      SELECT @tempdate = cast(@month AS varchar) + '/' 
                         + cast(@days AS varchar) + '/' 
                         + cast(@year AS varchar) 

      SELECT @todate = cast(@tempdate AS datetime) 

      SELECT @fromdate = CASE 
                           WHEN MONTH(@todate) <= 10 THEN cast('11/1/' + ( cast( 
                           ( @year - 1 ) AS varchar) 
                                     ) AS datetime) 
                           ELSE cast('11/1/' + ( cast(( @year ) AS varchar) ) AS 
                                     datetime) 
                         END 

      SELECT @rangedate = dateadd(month, 0 - @amcrange, @todate) 

      SELECT t.*, 
             [Status] = CASE 
                          WHEN t.SOH IS NULL 
                                OR t.SOH = 0 THEN 'Stock Out' 
                          WHEN t.SOH < t.EOP THEN 'Below EOP' 
                          WHEN t.SOH < ( t.EOP * 1.25 ) THEN 'Near EOP' 
                          WHEN t.SOH > t.[Max] 
                               AND t.AMC > 0 THEN 'Over Stocked' 
                          ELSE 'Normal' 
                        END, 
             ( t.SOH - ( t.Expired ) ) AS Dispatchable 
      FROM   (SELECT CASE 
                       WHEN vw.ID IN (SELECT DISTINCT ItemID 
                                      FROM   ReceiveDoc 
                                      WHERE  StoreID = @storeid) THEN 1 
                       ELSE 0 
                     END                            AS EverReceived, 
                     isnull(rd.Quantity, 0)         AS Received,
                     isnull(rd.UnitID, 0)           AS UnitID, 
                     isnull(rd.QuantityLeft, 0)     AS QuantityLeft, 
                     isnull(id.Quantity, 0)         AS Issued, 
                     isnull(id2.Quantity, 0)        AS IssuedMonth, 
                     isnull(loss.Quantity, 0)       AS Lost, 
                     isnull(adj.Quantity, 0)        AS Adjusted, 
                     isnull(amc.Quantity, 0)        AS AMC, 
                     isnull(dos.Quantity, 0)        AS DOS, 
                     ( isnull(bb.Quantity, 0) 
                       + isnull(rd.Quantity, 0) 
                       + isnull(adj.Quantity, 0) - isnull(id.Quantity, 0) - 
                       isnull(loss.Quantity, 0) 
                     )                              AS SOH, 
                     isnull(amc.Quantity * @min, 0) AS Min, 
                     isnull(amc.Quantity * @max, 0) AS Max, 
                     isnull(amc.Quantity * @eop, 0) AS EOP, 
                     isnull(ed.Quantity, 0)         AS Expired, 
                     ISNULL(nEx.Quantity, 0)        AS NearExpiry, 
                     vw.ID, 
                     vw.FullItemName, 
                     vw.StockCode, 
                     vw.Unit, 
                     vw.Name                        AS Type, 
                     vw.TypeID, 
                     p.ID                           AS ProgramID, 
                     p.Name                         AS ProgramName 
              FROM   vwGetAllItems vw 
                     LEFT JOIN ProgramProduct pp 
                            ON vw.ID = pp.ItemID 
                     LEFT JOIN Programs p 
                            ON pp.ProgramID = p.ID 
                     LEFT JOIN (SELECT rd.ItemID, 
                                       rd.UnitID, 
                                       sum(rd.Quantity /ISNULL(NULLIF(QtyPerPack,0),1)) Quantity, 
                                       sum(rd.QuantityLeft / ISNULL(NULLIF(QtyPerPack,0),1)) 
                                       QuantityLeft 
                                FROM   ReceiveDoc rd left join ItemUnit iu on rd.UnitID = iu.ID
                                WHERE  rd.StoreID = @storeid 
                                       AND ( date BETWEEN @fromdate AND @todate 
                                           ) 
                                GROUP  BY rd.ItemID, rd.UnitID) AS rd 
                            ON rd.ItemID = vw.ID 
                     LEFT JOIN (SELECT id.ItemID, 
                                       id.UnitID, 
                                       sum(id.Quantity / ISNULL(NULLIF(QtyPerPack,0),1)) Quantity 
                                FROM   IssueDoc id left join ItemUnit iu on id.UnitID = iu.ID
                                WHERE  id.StoreID = @storeid 
                                       AND ( date BETWEEN @fromdate AND @todate 
                                           ) 
                                GROUP  BY id.ItemID,id.UnitID) AS id 
                            ON id.ItemID = vw.ID 
                     LEFT JOIN (SELECT id.ItemID, 
                                       id.UnitID, 
                                       sum(id.Quantity / ISNULL(NULLIF(QtyPerPack,0),1)) Quantity 
                                FROM   IssueDoc id left join ItemUnit iu on id.UnitID = iu.ID
                                WHERE  id.StoreID = @storeid 
                                       AND ( year(date) = @year 
                                             AND MONTH(date) = @month ) 
                                GROUP  BY id.ItemID, 
                                          id.UnitID) AS id2 
                            ON id2.ItemID = vw.ID 
                     LEFT JOIN (SELECT ye.ItemID, 
                                       ye.UnitID, 
                                       sum(PhysicalInventory / ISNULL(NULLIF(QtyPerPack,0),1)) 
                                       Quantity 
                                FROM   YearEnd ye left join ItemUnit iu on ye.UnitID = iu.ID
                                WHERE  ye.StoreID = @storeid 
                                       AND Year = Year(@fromdate) 
                                GROUP  BY ye.ItemID, 
                                          ye.UnitID) AS bb 
                            ON bb.ItemID = vw.ID 
                     LEFT JOIN (SELECT rd.ItemID, 
                                       rd.UnitID, 
                                       sum(rd.QuantityLeft / ISNULL(NULLIF(QtyPerPack,0),1)) Quantity 
                                FROM   ReceiveDoc rd left join ItemUnit iu on rd.UnitID = iu.ID
                                WHERE  StoreID = @storeid 
                                       AND ExpDate < GETDATE() 
                                GROUP  BY rd.ItemID, 
                                          rd.UnitID) AS ed 
                            ON ed.ItemID = vw.ID 
                     LEFT JOIN (SELECT rd.ItemID, sum(rd.QuantityLeft / ISNULL(NULLIF(QtyPerPack,0),1)) Quantity 
                                FROM   ReceiveDoc rd left join ItemUnit iu on rd.UnitID = iu.ID
                                       JOIN vwGetAllItems v 
                                         ON rd.ItemID = v.ID 
                                WHERE  StoreID = @storeid 
                                       AND ExpDate BETWEEN GETDATE() AND 
                                           DATEADD(day, v.NearExpiryTrigger, 
                                           GETDATE()) 
                                GROUP  BY rd.ItemID) AS nEx 
                            ON nEx.ItemID = vw.ID 
                     LEFT JOIN (SELECT Max(AmcWithDos/ISNULL(NULLIF(QtyPerPack,0),1)) AS Quantity, 
                                       ar.UnitID, 
                                       ar.ItemID 
                                FROM   AmcReport ar left join ItemUnit iu on ar.UnitID = iu.ID
                                WHERE  ar.StoreID = @storeid 
                                GROUP  BY ar.ItemID ,ar.UnitID)AS amc 
                            ON amc.ItemID = vw.ID 
                     LEFT JOIN (SELECT Max(DaysOutOfStock / ISNULL(NULLIF(QtyPerPack,0),1)) AS 
                                       Quantity, 
                                       ar.UnitID, 
                                       ar.ItemID 
                                FROM   AmcReport ar left join ItemUnit iu on ar.UnitID = iu.ID
                                WHERE  ar.StoreID = @storeid 
                                GROUP  BY ar.ItemID, ar.UnitID)AS dos 
                            ON dos.ItemID = vw.ID 
                     LEFT JOIN (SELECT di.ItemID, 
                                       sum(di.Quantity /ISNULL(NULLIF(QtyPerPack,0),1)) Quantity, 
                                       UnitID 
                                FROM   Disposal di left join ItemUnit iu on di.UnitID = iu.ID
                                WHERE  StoreID = @storeid 
                                       AND ( date BETWEEN @fromdate AND @todate 
                                           ) 
                                       AND Losses = 1 
                                GROUP  BY di.ItemID, 
                                          di.UnitID) AS loss 
                            ON loss.ItemID = vw.ID 
                     LEFT JOIN (SELECT di.ItemID, 
                                       sum(di.Quantity /ISNULL(NULLIF(QtyPerPack,0),1)) Quantity, 
                                       UnitID 
                                FROM   Disposal di left join ItemUnit iu on di.UnitID = iu.ID
                                WHERE  StoreID = @storeid 
                                       AND ( date BETWEEN @fromdate AND @todate 
                                           ) 
                                       AND Losses = 0 
                                GROUP  BY di.ItemID, 
                                          di.UnitID) AS adj 
                            ON adj.ItemID = vw.ID 
              WHERE  vw.IsInHospitalList = 1) t 
      ORDER  BY t.FullItemName 
  END 
