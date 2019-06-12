

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WF.RetailCloud.Tasks;

namespace WF.RetailCloud.EntityMapper.CompletedTasks
{
    public class CompletedTaskCfg : IEntityTypeConfiguration<CompletedTask>
    {
        public void Configure(EntityTypeBuilder<CompletedTask> builder)
        {

            builder.ToTable("CompletedTasks", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.Content).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.IsCompleted).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.RefId).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.EmployeeId).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.CreationTime).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}



