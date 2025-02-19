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
using System.Windows.Shapes;

namespace serega_kursa4
{
    /// <summary>
    /// Логика взаимодействия для selectProducts.xaml
    /// </summary>
    /// 
    //CategoryComboBox
    public partial class selectProducts : Window
    {

        private ObservableCollection<Product> _cart = new ObservableCollection<Product>();
        private readonly AppDbContext _context;
        private int cartItemCount = 0;
        public selectProducts()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            if (_context == null)
            {
                return;
            }

            var categories = _context.Categories.ToList();
            categories.Insert(0, new Category { CategoryID = 0, CategoryName = "Все категории" });

            //categoryFilters.ItemsSource = categories;
            //categoryFilters.DisplayMemberPath = "CategoryName";
            //categoryFilters.SelectedValuePath = "CategoryID";
        }


        private void LoadProducts()
        {
            var products = _context.Products.ToList();
            var categories = _context.Categories.ToList();
            ProductsListView.ItemsSource = _context.Products.ToList();


            //foreach (var product in products)
            //{
            //    var category = categories.FirstOrDefault(c => c.CategoryID == product.CategoryID);
            //    product.CategoryInfo = category;
            //}
            //productList.ItemsSource = products;
        }

        //private void searchTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (search == null || _context == null)
        //        return;

        //    string searchText = search.Text.ToLower();

        //    productList.ItemsSource = _context.Products.Where(prd =>
        //        prd.ProductName.ToLower().Contains(searchText)).ToList();
        //}

        //private void categoryFiltersSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (categoryFilters.SelectedValue == null)
        //        return;

        //    int selectedCategoryID = (int)categoryFilters.SelectedValue;

        //    if (selectedCategoryID == 0)
        //    {
        //        LoadProducts();
        //        return;
        //    }

        //    var filteredProducts = _context.Products
        //        .Where(p => p.CategoryID == selectedCategoryID)
        //        .ToList();


        //    var categories = _context.Categories.ToList();
        //    foreach (var product in filteredProducts)
        //    {
        //        product.CategoryInfo = categories.FirstOrDefault(c => c.CategoryID == product.CategoryID);
        //    }


        //    //productList.ItemsSource = filteredProducts;
        //}

        private void CartNext(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow(_cart);
            cartWindow.Show();
            this.Close();
        }

        private void AddToCart(object sender, RoutedEventArgs e)
        {
            cartItemCount++;
            CartItemCount.Text = cartItemCount.ToString();

            Button button = sender as Button;
            if (button?.Tag is Product product)
            {
                _cart.Add(product);
            }


        }
    }
    
}
