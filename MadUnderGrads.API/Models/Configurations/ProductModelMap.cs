﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class ProductModelMap : EntityTypeConfiguration<ProductModel>
    {
        public ProductModelMap()
        {
            HasKey(w => w.Id);

            Property(w => w.Description)
                .IsOptional()
                .HasMaxLength(2000);

            Property(w => w.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(w => w.Category)
                .WithMany(w => w.Products)
                .HasForeignKey(w => w.CategoryId);

            HasOptional(w => w.Creator)
                .WithMany(w => w.CreatedProducts)
                .HasForeignKey(w => w.CreatedBy);

            HasOptional(w => w.Updator)
                .WithMany(w => w.UpdatedProducts)
                .HasForeignKey(w => w.UpdatedBy);

            ToTable("tbl_Product");
        }
    }
}