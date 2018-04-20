using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class TeacherModelMap : EntityTypeConfiguration<TeacherModel>
    {
        public TeacherModelMap()
        {
            HasKey(w => w.Id);

            Property(w => w.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(w => w.CreatedBy)
                .IsRequired()
                .HasMaxLength(128);

            Property(w => w.ModifiedBy)
                .IsOptional()
                .HasMaxLength(128);

            ToTable("tbl_Teacher");
        }
    }
}