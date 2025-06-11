using serega_kursa4.dto;
using System;
using Microsoft;
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
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace serega_kursa4
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Window
    {

        private readonly AppDbContext _context;
        private ObservableCollection<Product> _cart;
        int clientIdGlobal;

        public PersonalAccount(int clientId)
        {
            InitializeComponent();
            _context = new AppDbContext();
            clientIdGlobal = clientId;
            LoadOrders(clientId);

            var client = MainWindow.CurrentClient;
            nameTextBlock.Text = client.Name;
            surNameTextBlock.Text = client.SurName;
            lastNameTextBlock.Text = client.LastName;
            emailTextBlock.Text = client.Email;
            phoneNumberTextBlock.Text = client.PhoneNumber;
            passwordBlock.Text = client.Password;

        }

        private void LoadOrders(int clientId)
        {
            var orderEntities = _context.Orders
                .Where(o => o.ClientID == clientId)
                .ToList();

            List<OrderViewHistory> ordersForView = new List<OrderViewHistory>();



            foreach (var order in orderEntities)
            {

                var orderItems = _context.OrderItems.Where(o => o.OrderID == order.OrderID).ToArray();

                decimal totalSum = 0;

                for(int i = 0; i < orderItems.Length; i++)
                {
                    totalSum += orderItems[i].Price;
                }

                var dto = new OrderViewHistory
                {
                    OrderID = order.OrderID,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalPrice = totalSum
                };

                ordersForView.Add(dto);
            }

            // 3. Привязываем к ListView
            OrdersListView.ItemsSource = ordersForView;
        }

        private void OpenOrderDetails(object sender, RoutedEventArgs e)
        {
      
        }


        private void OpenProducts(object sender, RoutedEventArgs e)
        {
            selectProducts selectProduct = new selectProducts();
            selectProduct.ShowDialog();

        }

        private void ChangePassword(object sender, RoutedEventArgs e)
        {

        }

        private void EditUserData(object sender, RoutedEventArgs e)
        {
            nameTextBlock.Visibility = Visibility.Collapsed;
            name.Visibility = Visibility.Visible;
            name.Text = nameTextBlock.Text;

            surNameTextBlock.Visibility = Visibility.Collapsed;
            surName.Visibility = Visibility.Visible;
            surName.Text = surNameTextBlock.Text;

            lastNameTextBlock.Visibility = Visibility.Collapsed;
            lastName.Visibility = Visibility.Visible;
            lastName.Text = lastNameTextBlock.Text;

            emailTextBlock.Visibility = Visibility.Collapsed;
            email.Visibility = Visibility.Visible;
            email.Text = emailTextBlock.Text;

            phoneNumberTextBlock.Visibility = Visibility.Collapsed;
            phoneNumber.Visibility = Visibility.Visible;
            phoneNumber.Text = phoneNumberTextBlock.Text;

            passwordBlock.Visibility = Visibility.Collapsed;
            userPassword.Visibility = Visibility.Visible;
            userPassword.Password = passwordBlock.Text;

            saveButton.Visibility = Visibility.Visible;
            changePassword.Visibility = Visibility.Collapsed;
            openCart.Visibility = Visibility.Collapsed;
            openProducts.Visibility = Visibility.Collapsed;

        }

        private void OpenCart(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindows = new CartWindow(_cart);
            cartWindows.ShowDialog();
        }

        private void RefreshOrders(object sender, RoutedEventArgs e)
        {
            LoadOrders(clientIdGlobal);
        }
        
        private async void SaveButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lastName.Text) ||
                  string.IsNullOrWhiteSpace(name.Text) ||
                  string.IsNullOrWhiteSpace(surName.Text) ||
                  string.IsNullOrWhiteSpace(phoneNumber.Text) ||
                  string.IsNullOrWhiteSpace(email.Text) ||
                  string.IsNullOrWhiteSpace(userPassword.Password)) 
                {
                    MessageBox.Show("Все поля должны быть заполнены.");
                    return;
                }

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

                var client = MainWindow.CurrentClient;

                client.Name = name.Text;
                client.SurName = surName.Text;
                client.LastName = lastName.Text;
                client.Email = email.Text;
                client.PhoneNumber = phoneNumber.Text;
                client.Password = userPassword.Password;

                using (var context = new AppDbContext())
                {
                    context.Entry(client).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }

                // Обновить интерфейс
                nameTextBlock.Text = client.Name;
                surNameTextBlock.Text = client.SurName;
                lastNameTextBlock.Text = client.LastName;
                emailTextBlock.Text = client.Email;
                phoneNumberTextBlock.Text = client.PhoneNumber;
                passwordBlock.Text = client.Password;

                // Спрятать поля редактирования
                nameTextBlock.Visibility = Visibility.Visible;
                name.Visibility = Visibility.Collapsed;

                surNameTextBlock.Visibility = Visibility.Visible;
                surName.Visibility = Visibility.Collapsed;

                lastNameTextBlock.Visibility = Visibility.Visible;
                lastName.Visibility = Visibility.Collapsed;

                emailTextBlock.Visibility = Visibility.Visible;
                email.Visibility = Visibility.Collapsed;

                phoneNumberTextBlock.Visibility = Visibility.Visible;
                phoneNumber.Visibility = Visibility.Collapsed;

                passwordBlock.Visibility = Visibility.Hidden;
                userPassword.Visibility = Visibility.Collapsed;

                saveButton.Visibility = Visibility.Collapsed;
                changePassword.Visibility = Visibility.Visible;
                openCart.Visibility = Visibility.Visible;
                openProducts.Visibility = Visibility.Visible;

                MessageBox.Show("Данные успешно обновлены.");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
               
        }

        private void SaveButtonLostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный email!");
                email.Focus();
            }
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

        private void PhoneNumberTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[\d+]");
        }
    }
}
