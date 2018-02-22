﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Models
{
    public class ProductModel : IBaseEntity
    {
        public ProductModel()
        {
            
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsNegotiable { get; set; }
        public decimal Price { get; set; }
        public string Condition { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual ProductTextbookModel ProductTextbooks { get; set; }
        public virtual ProductApparelModel ProductApparels { get; set; }
        public virtual ProductElectronicsModel ProductElectronics { get; set; }
        public virtual ProductFurnitureModel ProductFurniture { get; set; }
        public virtual ProductMisellanousModel ProductMisellanous { get; set; }
    }
}