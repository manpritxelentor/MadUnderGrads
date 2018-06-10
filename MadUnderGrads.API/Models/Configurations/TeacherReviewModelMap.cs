using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models.Configurations
{
    public class TeacherReviewModelMap : EntityTypeConfiguration<TeacherReviewModel>
    {
        public TeacherReviewModelMap()
        {
            HasKey(w => w.Id);

            Property(w => w.Description)
                .IsRequired()
                .HasMaxLength(500);
            Property(w => w.Rating)
                .HasPrecision(18, 2);

            HasRequired(w => w.Teacher)
                .WithMany(w => w.Reviews)
                .HasForeignKey(w => w.TeacherId);

            HasRequired(w => w.ReviewerUser)
                .WithMany(w => w.TeacherReviews)
                .HasForeignKey(w => w.Reviewer);

            ToTable("tbl_TeacherReview");
        }
    }
}