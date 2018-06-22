using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class ProductTypeModelMap : EntityTypeConfiguration<ProductTypeModel>
    {
        public ProductTypeModelMap()
        {
            HasKey(w => w.Id);

            HasRequired(w => w.Category)
                .WithMany(w => w.ProductTypes)
                .HasForeignKey(w => w.CategoryId);

            ToTable("tbl_ProductType");
        }
    }
}