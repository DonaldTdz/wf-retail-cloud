

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WF.RetailCloud.Products;

namespace WF.RetailCloud.EntityMapper.Products
{
    public class ProductCfg : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Products", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.Type).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Name).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Specification).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Unit).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.IsEnabled).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.CreationTime).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}



