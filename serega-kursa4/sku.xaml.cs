using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace serega_kursa4
{
    /// <summary>
    /// Логика взаимодействия для sku.xaml
    /// </summary>
    public partial class sku : Window
    {

        private readonly AppDbContext _context;

        public sku()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadProducts(); 
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _context.Categories.ToList();

            categories.Insert(0, new Category { CategoryID = 0, CategoryName = "Все категории" });

            categoryFilter.ItemsSource = categories;
            categoryFilter.DisplayMemberPath = "CategoryName";
            categoryFilter.SelectedValuePath = "CategoryID";
            categoryFilter.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            var products = _context.Products.ToList(); 
            var categories = _context.Categories.ToList(); 

           
            foreach (var product in products)
            {
                var category = categories.FirstOrDefault(c => c.CategoryID == product.CategoryID);
                product.CategoryInfo = category; 
            }
            productsList.ItemsSource = products;
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            var addSkuWindow  = new addSku();
            addSkuWindow.ShowDialog();
            LoadProducts();
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            if (productsList.SelectedItem is Product selectedProduct)
            {
                var editWindow = new addSku(selectedProduct);
                editWindow.ShowDialog();
                LoadProducts();
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования.");
            }
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (productsList.SelectedItem is Product selectedProduct)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить товар?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.Products.Remove(selectedProduct);
                    _context.SaveChanges();
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }

        private void searchTextBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (searchTextBox == null || _context == null)
                return;

            string searchText = searchTextBox.Text.ToLower();

            productsList.ItemsSource = _context.Products.Where(prd =>
                prd.ProductName.ToLower().Contains(searchText)).ToList();
        }

        private void ChangeCategory(object sender, RoutedEventArgs e)
        {
            makeCategory addCategory = new makeCategory();
            addCategory.ShowDialog();
        }

        private void BackWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SortingCategories(object sender, RoutedEventArgs e)
        {
            Sorting sortingWindow = new Sorting();
            sortingWindow.ShowDialog();
        }

        private void CategoryFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoryFilter.SelectedValue == null)
                return;

            int selectedCategoryID = (int)categoryFilter.SelectedValue;

            if (selectedCategoryID == 0)
            {
                LoadProducts(); 
                return;
            }

            var filteredProducts = _context.Products
                .Where(p => p.CategoryID == selectedCategoryID)
                .ToList();

           
            var categories = _context.Categories.ToList();
            foreach (var product in filteredProducts)
            {
                product.CategoryInfo = categories.FirstOrDefault(c => c.CategoryID == product.CategoryID);
            }

           
            productsList.ItemsSource = filteredProducts;
        }
    }

  
}


