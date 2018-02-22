using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class ProductElectronicsModelMap : EntityTypeConfiguration<ProductElectronicsModel>
    {
        public ProductElectronicsModelMap()
        {
            HasKey(w => w.ProductId);

            Property(w => w.Manufacturer)
                .HasMaxLength(200);

            Property(w => w.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(w => w.Product)
                .WithOptional(w => w.ProductElectronics);

            ToTable("tbl_ProductElectronics");
        }
    }
}