using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class ProductApparelModelMap : EntityTypeConfiguration<ProductApparelModel>
    {
        public ProductApparelModelMap()
        {
            HasKey(w => w.ProductId);

            Property(w => w.Material)
                .HasMaxLength(200);

            Property(w => w.Size)
                .HasMaxLength(50);

            Property(w => w.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(w => w.Product)
                .WithOptional(w => w.ProductApparels);

            ToTable("tbl_ProductApparel");
        }
    }
}