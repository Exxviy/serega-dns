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
    /// Логика взаимодействия для Sorting.xaml
    /// </summary>
    public partial class Sorting : Window
    {
        private readonly AppDbContext _context;

        public Sorting()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadCategories();
        }

        private void LoadCategories()
        {
            categoryField.ItemsSource = _context.Categories.ToList();
            categoryField.DisplayMemberPath = "CategoryName"; 
            categoryField.SelectedValuePath = "CategoryID";   
        }

        private void BackWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SortCategory(object sender, RoutedEventArgs e)
        {
            
        }
    }
    
}
