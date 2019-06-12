

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WF.RetailCloud.DataDictionarys;

namespace WF.RetailCloud.EntityMapper.DataDictionarys
{
    public class DataDictionaryCfg : IEntityTypeConfiguration<DataDictionary>
    {
        public void Configure(EntityTypeBuilder<DataDictionary> builder)
        {

            builder.ToTable("DataDictionarys", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.Group).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Code).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Value).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Desc).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Seq).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.CreationTime).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}



