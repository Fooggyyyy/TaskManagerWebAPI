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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.CommentID);

            builder.Property(x => x.CommentBody).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ReleaseDate).IsRequired();

            builder.HasOne(x => x.Task)
                .WithMany(y => y.Comments)
                .HasForeignKey(z => z.TaskID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(y => y.Comments)
                .HasForeignKey(z => z.UserID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
