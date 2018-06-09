using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class PictureModelMap : EntityTypeConfiguration<PictureModel>
    {
        public PictureModelMap()
        {
            HasKey(w => w.Id);

            ToTable("tbl_Picture");
        }
    }
}