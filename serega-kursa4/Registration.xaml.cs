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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private readonly AppDbContext _context;

        public Registration()
        {
            InitializeComponent();
            _context = new AppDbContext(); 
        }

        private void registrationUser(object sender, RoutedEventArgs e)
        {
           
            string email = emailField.Text;
            string login = userName.Text;
            string password = passwordBox.Password;
            string confirmPassword = confirmPasswordBox.Password;

            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(login) 
                    || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Все поля должны быть заполнены.");
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Пароли не совпадают.");
                    return;
                }
                
                if (_context.Clients.AsNoTracking().Any(z => z.Login == login || z.Email == email))
                {
                    MessageBox.Show("Пользователь с таким логином или email уже существует.");
                    return;
                }
                
                var client = new Client
                {
                    Login = login,
                    Email = email,
                    Password = password,
                };

                _context.Clients.Add(client);
                _context.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно.");
                MainPage mainpage = new MainPage();
                mainpage.Show(); 
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n{ex.StackTrace}");
            }

        }

        private void BackToMainPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

