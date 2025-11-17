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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserID);

            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Role).HasDefaultValue(Role.Developer).IsRequired();

            builder.HasOne(x => x.Project)
                .WithMany(y => y.Users)
                .HasForeignKey(z => z.ProjectID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Email).IsUnique();

        }   
    }
}
