using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace serega_kursa4
{
    public class ProductMovement
    {
        [Key]
        public int MovementID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }

        public DateTime MovementDate { get; set; } = DateTime.Now;

        public string MovementType { get; set; }  // "Приход" или "Расход"
        public int Quantity { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public string Comment { get; set; }
    }
}
