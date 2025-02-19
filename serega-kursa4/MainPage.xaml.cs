using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            addSku product = new addSku();
            product.ShowDialog();
        }

        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            createOrder order = new createOrder();
            order.ShowDialog();
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            addClient client = new addClient();
            client.ShowDialog();
        }

        private void NextProduct(object sender, RoutedEventArgs e)
        {
            sku sku = new sku();
            sku.ShowDialog();
        }

        private void NextOrders(object sender, RoutedEventArgs e)
        {
            order orders = new order();
            orders.ShowDialog();
        }

        private void NextClient(object sender, RoutedEventArgs e)
        {
            clients clients = new clients();
            clients.ShowDialog();
        }

        private void NextReports(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void NextEmployees(object sender, RoutedEventArgs e)
        {
            employees employee = new employees();
            employee.ShowDialog();
        }

        private void NextSettings(object sender, RoutedEventArgs e)
        {
            settings settings = new settings();
            settings.ShowDialog();
        }
    }
}
