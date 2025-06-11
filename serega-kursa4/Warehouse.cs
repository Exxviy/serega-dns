using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace serega_kursa4
{
    public class Warehouse
    {
        [Key]
        public int WarehouseID { get; set; }

        public string WarehouseName { get; set; }
        public string Location { get; set; }

        public ICollection<ProductMovement> ProductMovements { get; set; }
    }
}
