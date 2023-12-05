using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace NeoSOFT.Domain.Model
{

    public partial class Product
    {
       
        public string id { get; set; } 
       
        public string productName { get; set; }
        
        public string productDescription { get; set; }
        
        public int productCategory { get; set; }
        
        public decimal productPrice { get; set; }
        public bool isActive { get; set; }  
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set;}
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set;}

    }
}
