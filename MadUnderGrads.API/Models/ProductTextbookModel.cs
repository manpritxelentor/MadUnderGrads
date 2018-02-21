using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductTextbookModel : IBaseEntity
    {
        public int ProductId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public bool NotesIncluded { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}