using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Infastructure.Infastructure.DataBase.ConfigurationTable
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskManager_Domain.Domain.Entites.Task>
    {
        public void Configure(EntityTypeBuilder<TaskManager_Domain.Domain.Entites.Task> builder)
        {
            builder.HasIndex(x => x.TaskName);

            builder.HasKey(x => x.TaskID);

            builder.Property(x => x.TaskName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.DateStart).IsRequired();
            builder.Property(x => x.DateEnd).IsRequired();
            builder.Property(x => x.IsCompleted).HasDefaultValue(false).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(y => y.Tasks)
                .HasForeignKey(z => z.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Layer)
                .WithMany(y => y.Tasks)
                .HasForeignKey(z => z.LayerID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Project)
                .WithMany(y => y.Tasks)
                .HasForeignKey(z => z.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
