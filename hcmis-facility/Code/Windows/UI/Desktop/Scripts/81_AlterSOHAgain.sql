ALTER PROCEDURE [dbo].[SOHByUnit] @storeid int, 
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
                           WHEN MONTH(@todate) <= 10 THEN cast('11/1/' + ( cast((@year - 1 ) AS varchar)) AS datetime) 
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
      FROM   (SELECT CASE WHEN vw.ID IN (SELECT DISTINCT ItemID 
                                      FROM   ReceiveDoc 
                                      WHERE  StoreID = @storeid
									  and UnitID =rd.UnitID) THEN 1 ELSE 0 END    
									                AS EverReceived, 
                     isnull(rd.Quantity, 0)         AS Received,
                     iu.ID                          AS UnitID, 
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
					 LEFT JOIN ItemUnit iu 
                            ON vw.ID = iu.ItemID  
							
			         --Receive Doc Join

                     LEFT JOIN (SELECT rd.ItemID, rd.UnitID,
                                       sum(rd.Quantity) Quantity, 
                                       sum(rd.QuantityLeft) QuantityLeft 
                                FROM   ReceiveDoc rd left join ItemUnit iu on rd.UnitID =iu.ID
                                WHERE  rd.StoreID = @storeid and ( rd.date BETWEEN @fromdate AND @todate) 
                                GROUP  BY rd.ItemID,rd.UnitID) AS rd
						     ON rd.ItemID = vw.ID and rd.UnitID=iu.ID

					  --Issue Doc Join

                     LEFT JOIN (SELECT id.ItemID, id.UnitID,
                                       sum(id.Quantity) Quantity 
                                FROM   IssueDoc id left join ReceiveDoc rd on id.RecievDocID =rd.ID
                                WHERE  id.StoreID = @storeid and ( id.date BETWEEN @fromdate AND @todate) 
                                GROUP  BY id.ItemID,id.UnitID) AS id 
							ON id.ItemID = vw.ID and id.UnitID=rd.UnitID

					  --Issue doc near expiry join

                     LEFT JOIN (SELECT id.ItemID, id.UnitID,
					            sum(id.Quantity) Quantity 
                                FROM   IssueDoc id left join ReceiveDoc rd on id.RecievDocID =rd.ID 
                                WHERE  id.StoreID = @storeid and (year(id.date) = @year and MONTH(id.date) = @month ) 
                                GROUP  BY id.ItemID,id.UnitID) AS id2 
                             ON id2.ItemID = vw.ID and id2.UnitID=rd.UnitID

					   --Year end join

                     LEFT JOIN (SELECT ye.ItemID, ye.UnitID,
                                       sum(PhysicalInventory) Quantity 
                                FROM   YearEnd ye left join ItemUnit iu on ye.UnitID = iu.ID
                                WHERE  ye.StoreID = @storeid and Year = Year(@fromdate) 
                                GROUP  BY ye.ItemID,ye.UnitID) AS bb 
                             ON bb.ItemID = vw.ID and bb.UnitID=iu.ID

                       --Receive Doc expiry

                     LEFT JOIN (SELECT rd.ItemID, rd.UnitID,
                                       sum(rd.QuantityLeft) Quantity 
                                FROM   ReceiveDoc rd left join ItemUnit iu on rd.UnitID = iu.ID 
                                WHERE  StoreID = @storeid and ExpDate < GETDATE() 
                                GROUP  BY rd.ItemID,rd.UnitID) AS ed 
                             ON ed.ItemID = vw.ID and rd.UnitID =iu.ID

					  --Issue doc near expiry

                     LEFT JOIN (SELECT rd.ItemID,  rd.UnitID,sum(rd.QuantityLeft) Quantity 
                                FROM   ReceiveDoc rd left join ItemUnit iu on rd.UnitID = iu.ID
                                       JOIN vwGetAllItems v 
                                         ON rd.ItemID = v.ID 
                                WHERE  StoreID = @storeid and ExpDate BETWEEN GETDATE() and DATEADD(day, v.NearExpiryTrigger,GETDATE()) 
                                GROUP  BY rd.ItemID,rd.UnitID) AS nEx 
                            ON nEx.ItemID = vw.ID and nEx.UnitID =rd.UnitID

					  --Amc Table Join

                     LEFT JOIN (SELECT Max(AmcWithDos) AS Quantity, ar.ItemID ,ar.UnitID
                                FROM   AmcReport ar left join ItemUnit iu on ar.UnitID = iu.ID
                                WHERE  ar.StoreID = @storeid 
                                GROUP  BY ar.ItemID ,ar.UnitID) AS amc 
                            ON amc.ItemID = vw.ID and amc.UnitID=iu.ID

					  --DOS Join From AMC

                     LEFT JOIN (SELECT Max(DaysOutOfStock) AS Quantity, ar.UnitID,ar.ItemID 
                                FROM   AmcReport ar left join ItemUnit iu on ar.UnitID = iu.ID
                                WHERE  ar.StoreID = @storeid 
                                GROUP  BY ar.ItemID, ar.UnitID)AS dos 
                            ON dos.ItemID = vw.ID and dos.UnitID=iu.ID

					 --Disposal /Loss

                     LEFT JOIN (SELECT di.ItemID, 
                                       sum(di.Quantity) Quantity, 
                                       rd.UnitID 
                                FROM   Disposal di left join ReceiveDoc rd on di.RecID =rd.ID and di.UnitID = rd.UnitID
                                WHERE  di.StoreID = @storeid and ( di.date BETWEEN @fromdate and @todate) and Losses = 1 
                                GROUP  BY di.ItemID,rd.UnitID) AS loss 
                            ON loss.ItemID = vw.ID and loss.UnitID=iu.ID

				    --Disposal / Adjustment

			       LEFT JOIN (SELECT di.ItemID, sum(di.Quantity) Quantity, rd.UnitID 
                                FROM   Disposal di left join ReceiveDoc rd on di.RecID =rd.ID and di.UnitID = rd.UnitID
                                WHERE  di.StoreID = @storeid and ( di.date BETWEEN @fromdate and @todate) and Losses = 0 
                                GROUP  BY di.ItemID, rd.UnitID) AS adj 
                            ON adj.ItemID = vw.ID and adj.UnitID=iu.ID

              WHERE  vw.IsInHospitalList = 1 and vw.ID =rd.ItemID) t 
			        ORDER  BY t.FullItemName 
  END 
