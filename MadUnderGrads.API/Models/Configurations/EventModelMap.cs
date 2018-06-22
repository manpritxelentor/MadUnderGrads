using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class EventModelMap : EntityTypeConfiguration<EventModel>
    {
        public EventModelMap()
        {
            HasKey(w => w.Id);

            HasOptional(w => w.Picture)
                .WithMany(w => w.Events)
                .HasForeignKey(w => w.PictureId);

            ToTable("tbl_Event");
        }
    }
}