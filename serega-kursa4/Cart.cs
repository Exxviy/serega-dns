using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serega_kursa4
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        [ForeignKey("Client")]
        public int ClientID { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        // Связь с пользователем
        public Client Client { get; set; }
        // Связь с товаром
        public Product Product { get; set; }
    }
}
