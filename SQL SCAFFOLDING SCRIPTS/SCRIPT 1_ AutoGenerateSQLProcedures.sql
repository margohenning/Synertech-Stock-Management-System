SET NOCOUNT ON 
declare @sp_type varchar(max) = 'Update'

select distinct isc.COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH, t.name tname, t.object_id
into #tmp
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

declare @nl varchar(40) = '
'

declare @count int,
		@object_id int,
		@tname varchar(300),
		@sql nvarchar(max);

select @count = count(object_id) from #tmp

while @count > 0
begin

	select top 1 @object_id = object_id, @tname = tname from #tmp
	
	--create INSERT proc with params
	set @sql = 'IF OBJECT_ID(''dbo.[Insert' + @tname +']'') IS NOT NULL DROP PROCEDURE dbo.[Insert' + @tname +']' +@nl +'GO' +@nl
    set @sql = @sql +'CREATE PROCEDURE dbo.[Insert' + @tname +']'+ @nl + STUFF((select   ', ' + @nl + '	@' + COLUMN_NAME + ' ' + DATA_TYPE + case when DATA_TYPE in ('geometry', 'geography','image')  then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) is null then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) = '-1' then '(max)'  else '(' +  convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) + ')' end 
						from #tmp
						where object_id = @object_id 
						for xml path(''), type
					).value('.', 'NVARCHAR(MAX)') 
				,1,4,'') + ',' + @nl +'	@ID INT OUT' + @nl +'AS' + @nl +'BEGIN'
	set @sql += @nl + @nl + 'Insert into dbo.['+@tname+']('+ STUFF((select ',' + quotename(COLUMN_NAME) 
																			from #tmp
																			where object_id = @object_id  
																			for xml path(''), type
																		).value('.', 'NVARCHAR(MAX)') 
																	,1,1,'') + ')' + @nl + 'values (' + STUFF((select ',@' + COLUMN_NAME
																												from #tmp
																												where object_id = @object_id 
																												for xml path(''), type
																											).value('.', 'NVARCHAR(MAX)') 
																										,1,1,'') + ')' + @nl + @nl + 'set @ID = SCOPE_IDENTITY();' + @nl
	print(@sql + @nl + 'END')
	print('GO')
	print('')

	--Delete
			--create proc with params
			set @sql = 'IF OBJECT_ID(''dbo.[Delete' + @tname +']'') IS NOT NULL DROP PROCEDURE dbo.[Delete' + @tname +']' +@nl +'GO' +@nl
			set @sql += 'CREATE PROCEDURE dbo.Delete' + @tname + @nl + STUFF((select   ', ' + @nl + '	@' + COLUMN_NAME + ' ' + DATA_TYPE + case when DATA_TYPE in ('geometry', 'geography')  then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) is null then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) = '-1' then '(max)'  else '(' +  convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) + ')' end 
								from sys.identity_columns ic
								inner join sys.tables t
								on ic.object_id = t.object_id
								inner join INFORMATION_SCHEMA.COLUMNS c
								on ic.name = c.COLUMN_NAME
								and c.TABLE_NAME = t.name
								where t.object_id = @object_id 
								for xml path(''), type
							).value('.', 'NVARCHAR(MAX)') 
						,1,4,'') + @nl +'AS' + @nl +'BEGIN'		
			set @sql += @nl + 'Delete from dbo.['+@tname+'] where ' +  STUFF((select 'and ' + quotename(COLUMN_NAME) + ' = @' +  COLUMN_NAME + ' '
														from sys.identity_columns ic
														inner join sys.tables t
														on ic.object_id = t.object_id
														inner join INFORMATION_SCHEMA.COLUMNS c
														on ic.name = c.COLUMN_NAME
														and c.TABLE_NAME = t.name
														where t.object_id = @object_id 
														for xml path(''), type
														).value('.', 'NVARCHAR(MAX)') 
													,1,4,'')
		
			print(@sql + @nl + 'END')
			print('GO')
			print('')
	--Update
			set @sql = 'IF OBJECT_ID(''dbo.[Update' + @tname +']'') IS NOT NULL DROP PROCEDURE dbo.[Update' + @tname +']' +@nl +'GO' +@nl
			set @sql += 'CREATE PROCEDURE dbo.[Update' + @tname +']'+ @nl + STUFF((select   ', ' + @nl + '	@' + COLUMN_NAME + ' ' + DATA_TYPE + case when DATA_TYPE in ('geometry', 'geography','image')  then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) is null then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) = '-1' then '(max)'  else '(' +  convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) + ')' end 
																					from #tmp
																					where object_id = @object_id 
																					for xml path(''), type
																				).value('.', 'NVARCHAR(MAX)') 
																			,1,4,'') 
																		  + STUFF((select   ', ' + @nl + '	@' + COLUMN_NAME + ' ' + DATA_TYPE + case when DATA_TYPE in ('geometry', 'geography','image')  then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) is null then '' when convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) = '-1' then '(max)'  else '(' +  convert(varchar(300),CHARACTER_MAXIMUM_LENGTH) + ')' end 
																				from sys.identity_columns ic
																				inner join sys.tables t
																				on ic.object_id = t.object_id
																				inner join INFORMATION_SCHEMA.COLUMNS c
																				on ic.name = c.COLUMN_NAME
																				and c.TABLE_NAME = t.name
																				where t.object_id = @object_id 
																				for xml path(''), type
																				).value('.', 'NVARCHAR(MAX)') 
																			,1,0,'') + @nl +'AS' + @nl +'BEGIN'
			set @sql += @nl + 'Update dbo.['+@tname+'] set '+	STUFF((select ', ' + quotename(COLUMN_NAME) + ' = @' +  COLUMN_NAME + ' '
																	from #tmp
																	where object_id = @object_id
																	for xml path(''), type
																).value('.', 'NVARCHAR(MAX)') 
															,1,1,'')+' where ' +  STUFF((select 'and ' + quotename(name) + ' = @' +  name + ' '
																						from sys.identity_columns
																						where object_id = @object_id 
																						for xml path(''), type
																					).value('.', 'NVARCHAR(MAX)') 
																				,1,4,'')

	print(@sql + @nl + 'END')
	print('GO')
	print('')

	delete from #tmp where object_id = @object_id
	select @count = count(object_id) from #tmp
end


drop table #tmp


SET NOCOUNT OFF