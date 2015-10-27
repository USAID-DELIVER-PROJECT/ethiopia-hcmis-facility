DELETE  FROM dbo.ProgramProduct
WHERE   ID NOT IN ( SELECT  MAX(ID)
                    FROM    dbo.ProgramProduct
                    GROUP BY ItemID ,
                            ProgramID)