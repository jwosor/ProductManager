using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.WebApi.DTOs
{
    public class FilterProductDTO
    {
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? MakingDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ValidityDate { get; set; }

        public int IdSupplier { get; set; }

        public bool OrderAscending { get; set; }
        public string OrderField { get; set; }
    }
}
