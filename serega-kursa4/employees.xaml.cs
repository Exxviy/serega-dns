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
    /// Логика взаимодействия для employees.xaml
    /// </summary>
    public partial class employees : Window
    {
        private readonly AppDbContext _context;

        

        public employees()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            EmployeesListView.ItemsSource = _context.Employees.ToList();
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            var addEditEmployeeWindow = new AddEditEmployeeWindow();
            addEditEmployeeWindow.ShowDialog();
            LoadEmployees();
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            if (EmployeesListView.SelectedItem is Employee selectedEmployee)
            {
                var editEmployeeWindow = new AddEditEmployeeWindow(selectedEmployee);
                editEmployeeWindow.ShowDialog();
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования.");
            }
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            if (EmployeesListView.SelectedItem is Employee selectedEmployee)
            {
                if (MainWindow.CurrentUserEmployee != null && selectedEmployee.EmployeeID == MainWindow.CurrentUserEmployee.EmployeeID)
                {
                    MessageBox.Show("Вы не можете удалить себя!");
                    return;
                }

                if (MessageBox.Show("Вы уверены, что хотите удалить сотрудника?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.Employees.Remove(selectedEmployee);
                    _context.SaveChanges();
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
            }
        }

        private void searchTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            //string search = "Поиск...";
            //if (searchTextBox.Text == search)
            //{
            //    searchTextBox.Clear();
            //}
        }

        private void searchTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            //string search = "Поиск...";
            //string empty = "";
            //if (searchTextBox.Text == empty)
            //    searchTextBox.Text = search;
        }

        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchTextBox == null || _context == null)
                return;

            string searchText = searchTextBox.Text.ToLower();

            EmployeesListView.ItemsSource = _context.Employees.Where(emp =>
                emp.EmployeeName.ToLower().Contains(searchText) ||
                emp.EmployeeLogin.ToLower().Contains(searchText) ||
                emp.EmployeeSurName.ToLower().Contains(searchText) ||
                emp.Role.ToLower().Contains(searchText) ||
                emp.Email.ToLower().Contains(searchText)).ToList();
        }

        private void BackWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
