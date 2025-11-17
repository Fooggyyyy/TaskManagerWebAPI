using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Infastructure.Infastructure.DataBase.ConfigurationTable
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.ProjectID);

            builder.Property(x => x.ProjectName).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(Status.Planned).IsRequired();

            builder.HasIndex(x => x.ProjectName).IsUnique();
        }
    }
}
