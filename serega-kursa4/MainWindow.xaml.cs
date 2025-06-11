using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public static Employee CurrentUserEmployee { get; private set; }

        public static Client CurrentClient { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();  
        }

        private void LoginAuthorization(object sender, RoutedEventArgs e)
        {
            string loginOrEmail = loginTextBox.Text;
            string password = PasswordBox.Password;
            string loginUser = loginTextBox.Text;
            string passwordUser = PasswordBox.Password;
            

            try
            {
                if (string.IsNullOrEmpty(loginOrEmail) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Все поля должны быть заполнены.");
                    return;
                }
              
                var userEmployee = _context.Employees.FirstOrDefault(u => u.EmployeeLogin == loginOrEmail 
                || u.Email == loginOrEmail);
                var user = _context.Clients.FirstOrDefault(u => u.Login == loginOrEmail 
                || u.Email == loginOrEmail);

                if (_context.Clients == null)
                {
                    MessageBox.Show("Ошибка загрузки базы данных клиентов.");
                    return;
                }


                if (user == null && userEmployee == null)
                {
                    MessageBox.Show("Пользователь не найден.");
                    return;
                }
                if (userEmployee != null)
                {
                    if (userEmployee.EmployeePassword != password)
                    {
                        MessageBox.Show("Неверный пароль!");
                        return;
                    }

                    CurrentUserEmployee = userEmployee;
                    MessageBox.Show("Авторизация успешна.");
                    MainPage mainPage = new MainPage();
                    mainPage.Show();
                    this.Close();
                }
                else if (user != null)
                {
                    if (string.IsNullOrEmpty(user.Password) || user.Password != password)
                    {
                        MessageBox.Show("Неверный пароль!");
                        return;
                    }

                    CurrentClient = user;
                    MessageBox.Show("Авторизация успешна.");

                    PersonalAccount personalAccounts = new PersonalAccount(user.ClientID);
                    personalAccounts.Show();
                    this.Close();

                }
                }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void OpenRegistration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
