using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class ProductTextbookModelMap : EntityTypeConfiguration<ProductTextbookModel>
    {
        public ProductTextbookModelMap()
        {
            HasKey(w => w.ProductId);

            Property(w => w.ISBN)
                .IsRequired()
                .HasMaxLength(50);

            Property(w => w.Title)
                .IsRequired()
                .HasMaxLength(256);

            Property(w => w.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(w => w.Product)
                .WithOptional(w => w.ProductTextbooks);

            ToTable("tbl_ProductTextbook");
        }
    }
}