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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace serega_kursa4
{
    /// <summary>
    /// Логика взаимодействия для createOrder.xaml
    /// </summary>
    public partial class createOrder : Window
    {

        private readonly AppDbContext _context;
        public createOrder()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Получаем все товары из базы данных
            var products = _context.Products.ToList();

            // Преобразуем товары в строку вида "Товар - Цена руб."
            var productDisplayList = products.Select(p => $"{p.ProductName} - {p.Price} руб.").ToList();

            // Привязываем список строк к ListBox
            ProductListBox.ItemsSource = productDisplayList;
        }

        private void BackToMainPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
