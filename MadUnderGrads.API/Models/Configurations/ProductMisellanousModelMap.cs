﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class ProductMisellanousModelMap : EntityTypeConfiguration<ProductMisellanousModel>
    {
        public ProductMisellanousModelMap()
        {
            HasKey(w => w.ProductId);

            Property(w => w.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(w => w.Product)
                .WithOptional(w => w.ProductMisellanous);

            ToTable("tbl_ProductMisellanous");
        }
    }
}