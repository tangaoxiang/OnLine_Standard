IF EXISTS ( SELECT  1
            FROM    sys.objects
            WHERE   name = 'P_DeleteDscirption'
                    AND type = 'p' ) 
    BEGIN
        DROP PROCEDURE P_DeleteDscirption
    END
GO
CREATE PROCEDURE P_DeleteDscirption
AS 
    BEGIN
    
        IF OBJECT_ID('tempdb..#temp') IS NOT NULL 
            DROP TABLE #temp
            
        DECLARE @index INT ,
            @rowCount INT ,
            @tableID INT ,
            @colID INT ,
            @Sql NVARCHAR(4000) ,
            @colName NVARCHAR(200) ,
            @tableName NVARCHAR(200) 
        -------------缓存临时数据    
        SELECT  t.name AS TableName ,
                c.name AS ColumnName ,
                c.object_id AS TableID ,
                c.column_id AS ColID
        INTO    #temp
        FROM    sys.columns AS c
                LEFT JOIN sys.objects AS t ON c.object_id = t.object_id
        WHERE   t.type = 'u'
        
        -------------获取循环阀值
        SELECT  @index = 0 ,
                @rowCount = COUNT(1)
        FROM    (SELECT DISTINCT
                        TableName
                 FROM   #temp
                ) AS t
        
        WHILE (@index < @rowCount) 
            BEGIN
                SELECT  @Sql = N'' ,
                        @index = @index + 1
                -------------取出表名和表的object_id      
                SELECT  @tableName = t.TableName ,
                        @tableID = T.TableID
                FROM    (SELECT DISTINCT
                                TableName ,TableID,
                                DENSE_RANK() OVER (ORDER BY TableName) AS [rowIndex]
                         FROM   #temp
                        ) AS t
                WHERE   t.rowIndex = @index 
                -------------判断表是否有说明
                IF EXISTS ( SELECT  * FROM    sys.extended_properties WHERE   major_id = @tableID AND minor_id = 0 AND name = N'MS_Description' ) 
                    BEGIN
                        SET @Sql = @Sql
                            + 'EXEC sys.sp_dropextendedproperty @name = N''MS_Description'' ,@level0type = N''SCHEMA'', @level0name = N''dbo'' , @level1type = N''TABLE'' ,@level1name = '
                            + 'N''' + @tableName + '''' + ';' + CHAR(13)
              
                        EXECUTE sys.sp_executesql @Sql
                        PRINT @Sql
                    END
            END
 
        -------------获取循环阀值
        SELECT  @index = 0 ,
                @rowCount = COUNT(1)
        FROM    #temp
 
 
        WHILE (@index < @rowCount) 
            BEGIN
                SELECT  @Sql = N'' ,
                        @index = @index + 1
                
                -------------取出表明列名，object_id,column_id
                SELECT  @tableID = t.TableID ,
                        @colID = t.ColID ,
                        @tableName = t.TableName ,
                        @colName = t.ColumnName
                FROM    (SELECT DISTINCT TableName , ColumnName , colID, TableID,
                                ROW_NUMBER() OVER (ORDER BY TableName, ColumnName) AS [rowIndex]
                         FROM   #temp
                        ) AS t
                WHERE   t.rowIndex = @index
                -------------判断列是否存在说明
                IF EXISTS ( SELECT  * FROM sys.extended_properties WHERE major_id = @tableID AND minor_id = @colID AND name = N'MS_Description' ) 
                    BEGIN
                        SET @Sql = @Sql
                            + 'EXEC sys.sp_dropextendedproperty @name = N''MS_Description'',@level0type = N''SCHEMA'', @level0name = N''dbo'' , @level1type = N''TABLE'' ,@level1name = '
                            + N'''' + @tableName + ''''
                            + ',@level2type = N''COLUMN'''
                            + ',@level2name =''' + N'' + @colName + ''';'
                            + CHAR(13)
                        
                        PRINT @Sql
                        EXECUTE sys.sp_executesql @Sql
                    END
            END
        -------------清除临时表
        IF OBJECT_ID('tempdb..#temp') IS NOT NULL 
            DROP TABLE #temp
    END
    
    exec P_DeleteDscirption;
    
    
    