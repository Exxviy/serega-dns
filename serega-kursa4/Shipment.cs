using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serega_kursa4
{
    public class Shipment
    {
        [Key]
        public int ShipmentID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string ShipmentStatus { get; set; }
        public string TrackingNumber { get; set; }

        // Связь с заказом
        public Order Order { get; set; }
    }

}
