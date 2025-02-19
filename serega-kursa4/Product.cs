using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serega_kursa4
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Article { get; set; }

        public Category CategoryInfo { get; set; }
    }

}
