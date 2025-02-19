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
    /// Логика взаимодействия для addClient.xaml
    /// </summary>
    public partial class addClient : Window
    {

        private readonly AppDbContext _context;

        public addClient()
        {
            _context = new AppDbContext();
            InitializeComponent();
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            string Name = name.Text;
            string Surname = surName.Text;
            string Lastname = lastName.Text;
            string phone = phoneNumber.Text;
            string Email = email.Text;


            // Проверка на пустые поля
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname) ||
                string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            var clients = new Client
            {
                Name = Name,
                SurName = Surname,
                LastName = Lastname,
                PhoneNumber = phone,
                Email = Email,
                LoyaltyLevel = loyaltyLevelComboBox.Text,
            };

            try
            {
                // Добавление клиента в базу данных
                _context.Clients.Add(clients);
                _context.SaveChanges();

                // Уведомление об успешном добавлении клиента
                MessageBox.Show("Клиент успешно добавлен.");

                // Закрытие окна
                this.Close();
            }
            catch (Exception ex)
            {
                // Ошибка при добавлении товара
                MessageBox.Show($"Произошла ошибка при добавлении клиента: {ex.Message}\n{ex.StackTrace}");
            }


        }

        private void BackToMainPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
