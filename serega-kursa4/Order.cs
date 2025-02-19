using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serega_kursa4
{
    public class Order
{
    public int OrderID { get; set; }
    public int ClientID { get; set; }
    public int Client { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}

}
