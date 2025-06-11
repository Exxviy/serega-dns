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
    /// Логика взаимодействия для PayedOrder.xaml
    /// </summary>
    public partial class PayedOrder : Window
    {
        AppDbContext _context = new AppDbContext();
        int idOrder;
        public PayedOrder(int id)
        {
            InitializeComponent();
            idOrder = id;
        }

        private async void Pay(object sender, RoutedEventArgs e)
        {
            payBtn.Visibility = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(CardNumberBox.Text) || CvvBox.Password.Length != 3)
            {
                payBtn.Visibility = Visibility.Visible;
                MessageBox.Show("Пожалуйста, введите корректные данные карты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Показать загрузку
            LoadingPanel.Visibility = Visibility.Visible;

            // Имитация задержки (оплата)
            await Task.Delay(3000); // 3 секунды

            // Скрыть загрузку
            LoadingPanel.Visibility = Visibility.Collapsed;

            CardNumberBox.Visibility = Visibility.Collapsed;
            CvvBox.Visibility = Visibility.Collapsed;
            BankComboBox.Visibility = Visibility.Collapsed;
            SuccessMessage.Visibility = Visibility.Visible;

            //Order updateStatusOrder = new Order(); 
             var updateStatusOrder = _context.Orders.Where(o => o.OrderID == idOrder).ToList();


            foreach(var order in updateStatusOrder)
            {
                order.Status = "Оплачен";
                order.OrderDate = DateTime.Now;
          
            }

                await _context.SaveChangesAsync();

            await Task.Delay(1500);
            this.Close();

            // Скрыть поля, показать благодарность
           
            
        }
    }
}
