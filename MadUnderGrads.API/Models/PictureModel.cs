using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class PictureModel : IBaseEntity
    {
        public PictureModel()
        {
            Products = new List<ProductModel>();
            Events = new List<EventModel>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Alternative { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
        public virtual ICollection<EventModel> Events { get; set; }
    }
}