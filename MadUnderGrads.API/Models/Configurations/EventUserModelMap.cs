using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class EventUserModelMap : EntityTypeConfiguration<EventUserModel>
    {
        public EventUserModelMap()
        {
            HasKey(w => w.Id);

            HasRequired(w => w.Event)
                .WithMany(w => w.EventUsers)
                .HasForeignKey(w => w.EventId);

            HasRequired(w => w.User)
                .WithMany(w => w.EventUsers)
                .HasForeignKey(w => w.UserId);

            ToTable("tbl_EventUserMap");
        }
    }
}