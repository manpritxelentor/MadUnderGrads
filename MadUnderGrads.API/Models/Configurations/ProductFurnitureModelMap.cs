using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class ProductFurnitureModelMap : EntityTypeConfiguration<ProductFurnitureModel>
    {
        public ProductFurnitureModelMap()
        {
            HasKey(w => w.ProductId);

            Property(w => w.Type)
                .HasMaxLength(50);

            Property(w => w.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(w => w.Product)
                .WithOptional(w => w.ProductFurniture);

            ToTable("tbl_ProductFurniture");
        }
    }
}