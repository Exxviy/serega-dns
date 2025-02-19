using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace serega_kursa4
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private readonly AppDbContext _context;
        private ObservableCollection<Product> _cart;

        public CartWindow(ObservableCollection<Product> cart)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _cart = cart;

            LoadCart();
        }

        private void LoadCart()
        {
            CartListView.ItemsSource = _cart;
        }

        private void RemoveFromCart(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button?.Tag is Product product)
            {
                _cart.Remove(product);
                LoadCart();
            }
        }

        private void PlaceOrder(object sender, RoutedEventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста!");
                return;
            }

            int clientId = MainWindow.CurrentClient.ClientID; 
            var newOrder = new Order
            {
                ClientID = clientId,
                OrderDate = DateTime.Now,
                Status = "В обработке",
                OrderItems = new List<OrderItem>()
            };

            foreach (var product in _cart)
            {
                newOrder.OrderItems.Add(new OrderItem
                {
                    ProductID = product.ProductID,
                    Quantity = 1,
                    Price = product.Price
                });
            }

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            _cart.Clear();

            MessageBox.Show("Заказ оформлен!");
            
        }
      


        private void BackWindow(object sender, RoutedEventArgs e)
        {
            selectProducts selectProducts = new selectProducts();
            selectProducts.Show();
            Close();
        }

    }
}
