using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        private readonly AppDbContext _context;
        private Employee _employee;
        private bool _isEditMode;

        public AddEditEmployeeWindow(Employee employee = null)
        {
            InitializeComponent();
            _context = new AppDbContext();

            if (employee != null)
            {
                _employee = employee;
                _isEditMode = true;
                LoadEmployeeData();
            }
            else
            {
                _employee = new Employee();
                _isEditMode = false;
            }
        }


        private void LoadEmployeeData()
        {
            lastNameField.Text = _employee.EmployeeSurName;
            firstNameField.Text = _employee.EmployeeName;
            middleNameField.Text = _employee.EmployeeLastName;
            loginField.Text = _employee.EmployeeLogin;
            roleField.Text = _employee.Role;
            phoneField.Text = _employee.PhoneNumber;
            emailField.Text = _employee.Email;
        }

        private void SaveEmployee(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(lastNameField.Text) ||
                   string.IsNullOrWhiteSpace(firstNameField.Text) ||
                   string.IsNullOrWhiteSpace(loginField.Text) ||
                   string.IsNullOrWhiteSpace(roleField.Text) ||
                   string.IsNullOrWhiteSpace(phoneField.Text) ||
                   string.IsNullOrWhiteSpace(emailField.Text))
                {
                    MessageBox.Show("Все поля должны быть заполнены.");
                    return;
                }

                // Проверка формата телефона (только цифры, 10-15 символов)
                if (!Regex.IsMatch(phoneField.Text, @"^\+?\d{10,15}$"))
                {
                    MessageBox.Show("Некорректный формат телефона! Введите номер от 10 до 15 цифр.");
                    return;
                }

                // Проверка email
                if (!Regex.IsMatch(emailField.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Некорректный формат email!");
                    return;
                }

                if (!_isEditMode && _context.Employees.Any(z => z.EmployeeLogin == loginField.Text))
                {
                    MessageBox.Show("Сотрудник с таким логином уже существует.");
                    return;
                }

                _employee.EmployeeSurName = lastNameField.Text;
                _employee.EmployeeName = firstNameField.Text;
                _employee.EmployeeLastName = middleNameField.Text;
                _employee.EmployeeLogin = loginField.Text;
                _employee.Role = roleField.Text;
                _employee.PhoneNumber = phoneField.Text;
                _employee.Email = emailField.Text;


                if (_isEditMode)
                {
                    _context.Employees.AddOrUpdate(_employee);
                }
                else
                {
                    _context.Employees.Add(_employee);
                }

                if (_employee.HireDate < new DateTime(1753, 1, 1))
                {
                    _employee.HireDate = DateTime.Now;
                }

                _context.SaveChanges();
                MessageBox.Show("Сотрудник успешно сохранён.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void phoneFieldTextChanged(object sender, TextChangedEventArgs e)
        {
            string text = phoneField.Text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (text.Length > 1 && text[0] != '+')
            {
                text = "+" + text; // Добавляем "+" в начало
            }

            if (text.Length > 12) // Обрезаем до 12 символов (пример для +7)
            {
                text = text.Substring(0, 12);
            }

            phoneField.Text = text;
            phoneField.CaretIndex = text.Length; // Ставим курсор в конец строки
        }

        private void phoneFieldPreviewText(object sender, TextCompositionEventArgs e)
        {
            // Разрешаем ввод только цифр и "+"
            e.Handled = !Regex.IsMatch(e.Text, @"[\d+]");
        }



        private void saveEmployeeLostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(emailField.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Некорректный email!");
                emailField.Focus();
            }
        }

        private void BackWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }

}
