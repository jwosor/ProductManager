using System;

namespace ProductManager.Entitites
{
    public class Product : Entity
    {
        public string Description { get; set; }
        public Boolean State { get; set; }
        public DateTime MakingDate { get; set; }
        public DateTime ValidityDate { get; set; }
        public int IdSupplier { get; set; }
         
    }
}
