

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WF.RetailCloud.Contracts;

namespace WF.RetailCloud.EntityMapper.Contracts
{
    public class ContractCfg : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {

            builder.ToTable("Contracts", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.Type).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.ContractCode).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.RefId).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.SignatureTime).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Amount).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Desc).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Attachments).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}



