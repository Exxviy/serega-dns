using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            var client = MainWindow.CurrentClient;
            if (client != null)
            {
                phoneNumber.Text = client.PhoneNumber;
                email.Text = client.Email;
            }


            methodDelievery.SelectionChanged += DeliveryMethodChanged;
            BankComboBox.SelectionChanged += PaymentMethodChanged;
        }

        private void DeliveryMethodChanged(object sender, SelectionChangedEventArgs e)
        {
            if (methodDelievery.SelectedItem is ComboBoxItem selectedItem)
            {
                string selected = selectedItem.Content.ToString();

                // Если выбран "Самовывоз", скрываем поле адреса
                address.Visibility = selected == "Самовывоз"
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            }
        }

        private void PaymentMethodChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BankComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selected = selectedItem.Content.ToString();

                bool isCash = selected == "При получении";

                CardNumberBox.Visibility = isCash ? Visibility.Collapsed : Visibility.Visible;
                CvvBox.Visibility = isCash ? Visibility.Collapsed : Visibility.Visible;
            }
        }


        private async void Pay(object sender, RoutedEventArgs e)
        {
            // Проверка формата телефона (только цифры, 10-15 символов)
            if (!Regex.IsMatch(phoneNumber.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Некорректный формат телефона! Введите номер от 10 до 15 цифр.");
                return;
            }

            // Проверка email
            if (!Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный формат email!");
                return;
            }

            bool isCashPayment = false;

            if (BankComboBox.SelectedItem is ComboBoxItem selectedPayment)
            {
                isCashPayment = selectedPayment.Content.ToString() == "При получении";
            }

            payBtn.Visibility = Visibility.Collapsed;

            // ❗ Проверяем карту ТОЛЬКО если это НЕ оплата при получении
            if (!isCashPayment && (string.IsNullOrWhiteSpace(CardNumberBox.Text) || CvvBox.Password.Length != 3))
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

            address.Visibility = Visibility.Collapsed;
            email.Visibility = Visibility.Collapsed;
            phoneNumber.Visibility = Visibility.Collapsed;
            methodDelievery.Visibility = Visibility.Collapsed;
            CardNumberBox.Visibility = Visibility.Collapsed;
            CvvBox.Visibility = Visibility.Collapsed;
            BankComboBox.Visibility = Visibility.Collapsed;
            SuccessMessage.Visibility = Visibility.Visible;

            //Order updateStatusOrder = new Order(); 
            var updateStatusOrder = _context.Orders.Where(o => o.OrderID == idOrder).ToList();


            foreach (var order in updateStatusOrder)
            {
                order.Status = isCashPayment ? "В обработке" : "Оплачен";
                order.OrderDate = DateTime.Now;

                // Добавляем доставку
                Shipment shipment = new Shipment
                {
                    OrderID = order.OrderID,
                    ShipmentDate = DateTime.Now.AddDays(1), // можно заменить на желаемую дату
                    ShipmentStatus = "Ожидает отправки",
                    TrackingNumber = "TRK" + Guid.NewGuid().ToString("N").Substring(0, 8)
                };

                _context.Shipments.Add(shipment);
            }


            await _context.SaveChangesAsync();

            await Task.Delay(1500);
            this.Close();

            // Скрыть поля, показать благодарность
           
            
        }

        private void PhoneNumberTextChanged(object sender, TextChangedEventArgs e)
        {
            string text = phoneNumber.Text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (text.Length > 1 && text[0] != '+')
            {
                text = "+" + text; // Добавляем "+" в начало
            }

            if (text.Length > 12) // Обрезаем до 12 символов (пример для +7)
            {
                text = text.Substring(0, 12);
            }

            phoneNumber.Text = text;
            phoneNumber.CaretIndex = text.Length; // Ставим курсор в конец строки
        }

        private void PhoneNumberPreviewText(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[\d+]");
        }

        private void PayBtnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный email!");
                email.Focus();
            }
        }
    }
}
