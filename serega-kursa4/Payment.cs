using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serega_kursa4
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        // Связь с заказом
        public Order Order { get; set; }
    }
}
