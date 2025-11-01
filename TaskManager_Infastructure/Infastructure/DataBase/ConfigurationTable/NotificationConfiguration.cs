using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Infastructure.Infastructure.DataBase.ConfigurationTable
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.NotificationID);

            builder.Property(x => x.NotificationName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NotificationDescription).HasMaxLength(1000);

            builder.HasOne(x => x.Task)
                .WithMany(y => y.Notifications)
                .HasForeignKey(z => z.TaskID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
               .WithMany(y => y.Notifications)
               .HasForeignKey(z => z.UserID)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
