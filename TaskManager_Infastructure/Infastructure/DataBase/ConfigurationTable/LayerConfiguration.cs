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
    public class LayerConfiguration : IEntityTypeConfiguration<Layer>
    {
        public void Configure(EntityTypeBuilder<Layer> builder)
        {
            builder.HasKey(x => x.LayerID);

            builder.Property(x => x.LayerName);

            builder.HasOne(x => x.Project)
                .WithMany(y => y.Layers)
                .HasForeignKey(z => z.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
