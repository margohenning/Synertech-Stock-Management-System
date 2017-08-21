SET NOCOUNT ON
--USE DAF
--GO

declare @nl varchar(40) = '
'

select distinct isc.COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH, t.name tname, t.object_id,t.create_date
INTO #tmp
from information_schema.columns isc
inner join sys.tables t
on TABLE_NAME = t.name
inner join sys.columns c
on t.object_id = c.object_id


--delete all primary key columns
delete tmp from #tmp tmp
inner join sys.identity_columns ic
on tmp.COLUMN_NAME = ic.name
and tmp.object_id = ic.object_id


declare @count int,
		@object_id int,
		@tname varchar(300),
		@sql nvarchar(max),
		@ProcName nvarchar(max);

select @count = count(object_id) from #tmp

while @count > 0
begin
	SELECT top 1 @object_id = object_id, @tname = tname from #tmp order by #tmp.tname 
	SET @ProcName ='#region '+@tname;
	PRINT(@ProcName)
		--Get CODE By ID
	SET @ProcName = 'public static LTS.'+@tname+' '+ 'Get' + @tname +'ItemByID (int? '+@tname+'ID )' --+ @sp_type + @tname + '(' + @tname + ')'
	PRINT(@ProcName)
	SET @ProcName = '{
			LTS.'+@tname +' '+ LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+'  = new LTS.'+@tname +'();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
					 '+ LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+'= access.' + @tname +'.Where( o=>o.'+(Select    ic.name  from sys.identity_columns ic where ic.object_id=@object_id  )  +' == '+@tname+'ID).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            } 
			return '+ LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+';
        }'  +@nl
	PRINT(@ProcName)

		--Get All
	SET @ProcName = 'public static List<LTS.'+@tname+'>'+ 'Get' + @tname +'()' --+ @sp_type + @tname + '(' + @tname + ')'
	PRINT(@ProcName)
	SET @ProcName = '{
			List<LTS.'+@tname +'> '+ LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+'  = new List<LTS.'+@tname +'>();
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
					 '+ LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+'= access.' + @tname +'.ToList();
                }
            }
            catch (Exception ex)
            {
            } 
			return '+ LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+';
        }'  +@nl
	PRINT(@ProcName)


	--ADD CODE

	SET @ProcName = 'Insert' + @tname
	SET @ProcName = 'public static int '+ 'Add' + @tname +'(LTS.'+ @tname + ' ' + LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname)) +')' --+ @sp_type + @tname + '(' + @tname + ')'
	PRINT(@ProcName)
	SET @ProcName = '{
             int? '+@tname+'ID = -1;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
					 access.Insert' + @tname +'(' +  STUFF((select',' + ' ' +  LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+'.'+ COLUMN_NAME  
						from #tmp
						where object_id = @object_id 
						and #tmp.object_id  not in (select ic.object_id from sys.identity_columns ic where #tmp.COLUMN_NAME = ic.name and #tmp.object_id = ic.object_id)
						for xml path(''), type
					).value('.', 'NVARCHAR(MAX)') 
				,1,2,'')+',ref '+@tname+'ID);
                }
            }
            catch (Exception ex)
            {
            } 
			return '+@tname+'ID.Value;
        }'  +@nl
	PRINT(@ProcName)

	-- DELETE Code
	--create proc with params
	SET @ProcName = 'Delete'+'' + @tname
	--generate webservice code--
	SET @ProcName = 'public static bool Remove' + @tname +'(int '+@tname+'ID)' --+ @sp_type + @tname + '(' + @tname + ')'
	PRINT(@ProcName)
	SET @ProcName = '{
			bool deleted = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
					 access.Delete' + @tname +'('+@tname+'ID);
					 deleted = true;
                }
            }
            catch (Exception ex)
            {
            } 
			return deleted;
        }'  +@nl
	PRINT(@ProcName)



	--UPDATE CODE

	SET @ProcName = 'Update' + @tname
	SET @ProcName = 'public static bool '+ 'Update' + @tname +'(LTS.'+ @tname + ' ' + LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname)) +')' --+ @sp_type + @tname + '(' + @tname + ')'
	PRINT(@ProcName)
	SET @ProcName = '{
             bool completed = false;
            try
            {
                using (LTS.LTSBase access = new LTS.LTSDC())
                {
					  access.Update' + @tname +'(' +  STUFF((select',' + ' ' +  LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+'.'+ COLUMN_NAME  
						from #tmp
						
						where #tmp.object_id = @object_id 
						for xml path(''), type
					).value('.', 'NVARCHAR(MAX)') 
				,1,2,'')+','+(Select   LOWER(LEFT(@tname,1))+SUBSTRING(@tname,2,LEN(@tname))+'.'+ ic.name  from sys.identity_columns ic where ic.object_id=@object_id  )+');
				completed=true;
                }
				
            }
            catch (Exception ex)
            {
				completed=false;
            } 
			return completed;
        }'  +@nl
	PRINT(@ProcName)

	SET @ProcName ='#endregion;'
		--Get CODE
	PRINT(@ProcName)

	delete from #tmp where object_id = @object_id
	select @count = count(object_id) from #tmp


end


drop table #tmp


SET NOCOUNT OFF