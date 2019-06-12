
-- select * from [dbo].[retail] where tablename='RetailProduct'

declare @temp table(rowno int, tablename nvarchar(255), fieldname nvarchar(255));

insert into @temp
select row_number() over(order by tablename) as rownum, tablename, fieldname 
from [dbo].[basetb] where tablename='customer'

--select * from @temp

declare @count int
declare @i int = 1
declare @tname nvarchar(50)
declare @ltname nvarchar(50)

declare @fname nvarchar(50)
declare @lfname nvarchar(50)
declare @fdesc nvarchar(50)
declare @ftype nvarchar(50)
declare @isre nvarchar(50)
declare @len1 int
declare @len2 int

select @count = count(1) from @temp
select top 1 @tname = tablename from @temp
set @ltname = LOWER(left(@tname,1)) + right(@tname,len(@tname)-1)
/*
create table if not exists shopUsers(
            id varchar(36) PRIMARY KEY not null,
            account nvarchar(50) not null,
            password varchar(200) not null,
            name varchar(50),
            role int not null,
            shopId varchar(36),
            isEnable int,
            creationTime datetime,
            creatorUserId varchar(36),
            lastModificationTime datetime,
            lastModifierUserId varchar(36)
        );
*/
declare @ctable nvarchar(max) = 'create table if not exists '+ @ltname +'('+ CHAR(13) + CHAR(10)+
            'id varchar(36) PRIMARY KEY not null,' + CHAR(13) + CHAR(10)

declare @mysqltable nvarchar(max) = 'create table if not exists `'+ LOWER(@tname) +'s`('+ CHAR(13) + CHAR(10)+
            '`Id` char(36) PRIMARY KEY not null,' + CHAR(13) + CHAR(10)

declare @esql nvarchar(max) = 'export class '+@tname+' {' + CHAR(13) + CHAR(10)+ ' id: string;'+ CHAR(13) + CHAR(10)
declare @isql nvarchar(max) = 'init(data?: any) {'+ CHAR(13) + CHAR(10)+
        'if (data) {'+ CHAR(13) + CHAR(10)+
            'this.id = data["id"];' + CHAR(13) + CHAR(10)
declare @tosql nvarchar(max) = 'toJSON(data?: any) {' + CHAR(13) + CHAR(10)+
        'data = typeof data === ''object'' ? data : {};' + CHAR(13) + CHAR(10)+
        'data["id"] = this.id;' + CHAR(13) + CHAR(10)

declare @rowsql nvarchar(max) = ''
declare @thsql nvarchar(max) = '<tr>' + CHAR(13) + CHAR(10)
declare @tdsql nvarchar(max) = '<tr>' + CHAR(13) + CHAR(10)
declare @efcode nvarchar(max) = '[Table("'+@tname+'s")]'  + CHAR(13) + CHAR(10) +
    'public class '+@tname+' : Entity<Guid> //注意修改主键Id数据类型'  + CHAR(13) + CHAR(10) + '{' + CHAR(13) + CHAR(10)

declare @setform nvarchar(max) = 'protected setFormValues(entity: '+ @tname +'): void {' + CHAR(13) + CHAR(10)
declare @getform nvarchar(max) = 'protected getFormValues(): void {' + CHAR(13) + CHAR(10)

while @i <= @count
begin

select @fname = r.fieldname,@fdesc = isnull(r.fielddesc,''),@ftype = r.fieldtype, @isre = isnull(r.isre,''), @len1 = isnull(r.fieldlen,0), @len2 = isnull(r.fieldlen2,0)  from @temp t 
inner join [dbo].[basetb] r on t.tablename = r.tablename and t.fieldname = r.fieldname
where t.tablename = @tname and t.rowno = @i

set @lfname =  LOWER(left(@fname,1)) + right(@fname,len(@fname)-1)
set @rowsql = @rowsql + @lfname + ','

--1.数据库创建脚本
if @fname != 'id' begin
	
	set @ctable = @ctable + @lfname + ' '
	set @mysqltable = @mysqltable + '`' +  @fname + '` '
	set @esql = @esql + @lfname + ': ' 
	set @isql = @isql + 'this.' + @lfname + ' = data["'+@lfname+'"];' + CHAR(13) + CHAR(10)
	set @tosql = @tosql + 'data["'+@lfname+'"] = this.' + @lfname + ';' + CHAR(13) + CHAR(10)
	set @thsql = @thsql + '<th>'+ @fdesc +'</th>' + CHAR(13) + CHAR(10)
	set @tdsql = @tdsql + '<td>{{item.'+ @lfname +'}}</td>' + CHAR(13) + CHAR(10)
	set @efcode = @efcode + '/// <summary>' + CHAR(13) + CHAR(10) +
		'/// ' + @fdesc + CHAR(13) + CHAR(10) +
		'/// </summary>' + CHAR(13) + CHAR(10)
	set @setform = @setform + 'this.setControlVal('''+@lfname+''', entity.'+@lfname+');' + CHAR(13) + CHAR(10)
	set @getform = @getform + 'this.'+@ltname+'.'+@lfname+' = this.getControlVal('''+@lfname+''');' + CHAR(13) + CHAR(10)

	if @ftype = 'string'
	begin
		if @len1 = 0 begin set @len1 = 50  end

		set @ctable = @ctable + 'nvarchar('+ cast(@len1 as varchar(20))+')'
		set @mysqltable = @mysqltable  + 'varchar('+ cast(@len1 as varchar(20))+')'
		set @esql = @esql + 'string;'+ CHAR(13) + CHAR(10)

		set @efcode = @efcode + '[StringLength('+ cast(@len1 as varchar(20))+ ')]' + CHAR(13) + CHAR(10)

	end
	else if @ftype = 'Guid'
	begin
		set @ctable = @ctable + 'varchar(36)'
		set @mysqltable = @mysqltable + 'char(36)'
		--set @esql = @esql + 'string'
		set @esql = @esql + 'string;'+ CHAR(13) + CHAR(10)
	end
	else if @ftype = 'decimal'
	begin
		set @ctable = @ctable + 'decimal('+cast(@len1 as varchar(20))+','+cast(@len2 as varchar(20))+')'
		set @mysqltable = @mysqltable  + 'decimal('+cast(@len1 as varchar(20))+','+cast(@len2 as varchar(20))+')'
		set @esql = @esql + 'number;'+ CHAR(13) + CHAR(10)
	end
	else if @ftype = 'bool'
	begin
		set @ctable = @ctable + 'int'
		set @mysqltable = @mysqltable + 'bit'
		set @esql = @esql + 'boolean;'+ CHAR(13) + CHAR(10)
	end
	else
	begin
		set @ctable = @ctable + @ftype
		
		if (@ftype = 'float' or @ftype = 'int' or @ftype = 'long')
		begin
		 set @esql = @esql + 'number;'+ CHAR(13) + CHAR(10)
		 if(@ftype = 'long')
		 begin
		  set @mysqltable = @mysqltable + 'bigint'
		 end
		 else
		 begin
		  set @mysqltable = @mysqltable + @ftype
		 end
		end
		else if @ftype = 'DateTime'
		begin
		 set @esql = @esql + 'Date;'+ CHAR(13) + CHAR(10)
		 set @mysqltable = @mysqltable + @ftype
		end
		else
		begin
		  set @esql = @esql + @ftype+ ';'+ CHAR(13) + CHAR(10)
		  set @mysqltable = @mysqltable + @ftype
		end
	end

	if @isre = 'Y'
	begin
		set @ctable = @ctable + ' not null'
		set @mysqltable = @mysqltable + ' not null'
		set @efcode = @efcode + '[Required]'+ CHAR(13) + CHAR(10)
		set @efcode = @efcode + ' public virtual '+ @ftype +' '+ @fname +' { get; set; }'+ CHAR(13) + CHAR(10)
	end
	else
	begin
		set @efcode = @efcode + ' public virtual '+ @ftype + (case when @ftype = 'string' then ' ' else '? ' end ) + @fname +' { get; set; }'+ CHAR(13) + CHAR(10)
	end

	if @i = @count
	begin
		set @ctable = @ctable + CHAR(13) + CHAR(10) + ');'
		set @mysqltable = @mysqltable + CHAR(13) + CHAR(10) + ');'
		set @isql = @isql + '}' + CHAR(13) + CHAR(10) + '}' + CHAR(13) + CHAR(10)
		set @tosql = @tosql + 'return data;' + CHAR(13) + CHAR(10) + '}' + CHAR(13) + CHAR(10)
	end
	else 
	begin
		set @ctable = @ctable + ',' + CHAR(13) + CHAR(10)
		set @mysqltable = @mysqltable + ',' + CHAR(13) + CHAR(10)
	end

end

set @i = @i + 1
end

set @esql = @esql + 'constructor(data?: any) {' + CHAR(13) + CHAR(10) +
        'if (data) {' + CHAR(13) + CHAR(10) +
            'for (var property in data) {' + CHAR(13) + CHAR(10) +
                'if (data.hasOwnProperty(property))' + CHAR(13) + CHAR(10) +
                    '(<any>this)[property] = (<any>data)[property];' + CHAR(13) + CHAR(10) +
            '}'+ CHAR(13) + CHAR(10) +
        '}'+ CHAR(13) + CHAR(10) +
    '}' + CHAR(13) + CHAR(10)

set @esql = @esql + @isql

set @esql = @esql + @tosql

set @esql = @esql + 'static fromJS(data: any): '+@tname+' {' + CHAR(13) + CHAR(10) +
        'let result = new '+@tname+'();' + CHAR(13) + CHAR(10) +
        'result.init(data);' + CHAR(13) + CHAR(10) +
        'return result;' + CHAR(13) + CHAR(10) +
    '}' + CHAR(13) + CHAR(10) +
'static fromJSArray(dataArray: any[]): '+@tname+'[] {' + CHAR(13) + CHAR(10) +
        'let array = [];' + CHAR(13) + CHAR(10) +
        'dataArray.forEach(result => {' + CHAR(13) + CHAR(10) +
            'let item = new '+@tname+'();' + CHAR(13) + CHAR(10) +
            'item.init(result);' + CHAR(13) + CHAR(10) +
            'array.push(item);' + CHAR(13) + CHAR(10) +
        '});' + CHAR(13) + CHAR(10) +
        'return array;' + CHAR(13) + CHAR(10) +
    '}' + CHAR(13) + CHAR(10) +
'clone() {' + CHAR(13) + CHAR(10) +
        'const json = this.toJSON();' + CHAR(13) + CHAR(10) +
        'let result = new '+@tname+'();' + CHAR(13) + CHAR(10) +
        'result.init(json);' + CHAR(13) + CHAR(10) +
        'return result;' + CHAR(13) + CHAR(10) +
    '}' + CHAR(13) + CHAR(10) + '}'

set @thsql = @thsql + '</tr>' + CHAR(13) + CHAR(10)
set @tdsql = @tdsql + '</tr>' + CHAR(13) + CHAR(10)

set @efcode = @efcode + '}'  + CHAR(13) + CHAR(10)

set @setform = @setform + '}'  + CHAR(13) + CHAR(10)
set @getform = @getform + '}'  + CHAR(13) + CHAR(10)

select '创建sqlite表', @ctable 
union all
select '创建ts entity', @esql
union all
select '列行', @rowsql
union all
select '表头', @thsql
union all
select '表列', @tdsql
union all
select 'ts set form values', @setform
union all
select 'ts get form values', @getform
union all
select 'ef entity', @efcode
union all
select 'mysql table', @mysqltable

 