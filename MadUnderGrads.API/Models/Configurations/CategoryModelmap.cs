using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class CategoryModelMap : EntityTypeConfiguration<CategoryModel>
    {
        public CategoryModelMap()
        {
            HasKey(w => w.Id);

            Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(128);

            Property(w => w.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            ToTable("tbl_Category");
        }
    }
}