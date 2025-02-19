using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для addSku.xaml
    /// </summary>
    public partial class addSku : Window
    {
        private readonly AppDbContext _context;
        private Product _currentProduct;

        public addSku(Product product = null)
        {
            InitializeComponent();
            _context = new AppDbContext(); // Инициализация контекста базы данных
            LoadCategories();

            if (product != null) // Проверяем, передан ли товар для редактирования
            {
                _currentProduct = product;
                LoadProductData();
            }
        }

        //ДОБАВИТЬ TRY CATCH

        private void LoadProductData()
        {
           
            productName.Text = _currentProduct.ProductName;
            quantityProduct.Text = _currentProduct.Quantity.ToString();
            priceProducts.Text = _currentProduct.Price.ToString();

          
            categoryList.SelectedValue = _currentProduct.CategoryID;
        }

        private void LoadCategories()
        {
            
            var categories = _context.Categories.ToList();

           
            categoryList.ItemsSource = categories;
            categoryList.DisplayMemberPath = "CategoryName"; 
            categoryList.SelectedValuePath = "CategoryID"; 
        }

        private void AddNewProducts(object sender, RoutedEventArgs e)
        {
            // Получаем данные из UI
            string product = productName.Text;

            // проверяем,выбрана ли категория

            if (categoryList.SelectedValue == null)
            {
                MessageBox.Show("Выберите категорию товара.");
                return;
            }

            int selectedCategoryId = (int)categoryList.SelectedValue; // Получаем выбранный ID категории
            
            string article = GenerateArticleCode();

            // Проверка на пустые поля

            if (string.IsNullOrWhiteSpace(product) || selectedCategoryId == 0 || string.IsNullOrWhiteSpace(quantityProduct.Text) || string.IsNullOrWhiteSpace(priceProducts.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены корректно.");
                return;
            }

            // Проверка на корректность введенных данных (например, цена и количество должны быть числами)
            if (!int.TryParse(quantityProduct.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Количество должно быть числом.");
                return;
            }

            if (!decimal.TryParse(priceProducts.Text, out decimal price) || price <=0 )
            {
                MessageBox.Show("Цена должна быть числом.");
                return;
            }

            if (_context.Products.Any(p => p.Article == article))
            {
                MessageBox.Show("Товар с таким артикулом уже существует.");
                return;
            }

            try
            {
                if (_currentProduct == null)
                {
                    _currentProduct = new Product
                    {
                        ProductName = product,
                        CategoryID = selectedCategoryId,
                        Quantity = quantity,
                        Price = price,
                        Article = article
                    };

                    _context.Products.Add(_currentProduct);
                }
                else
                {
                    _currentProduct.ProductName = productName.Text;
                    _currentProduct.CategoryID = selectedCategoryId;
                    _currentProduct.Quantity = quantity;
                    _currentProduct.Price = price;
                    _context.Products.AddOrUpdate(_currentProduct);
                }
                _context.SaveChanges();

                MessageBox.Show("Товар успешно сохранен.");
            }
            catch (Exception ex)
            {
                // Ошибка при добавлении товара
                MessageBox.Show($"Произошла ошибка при добавлении товара: {ex.Message}\n{ex.StackTrace}");
            }

        }
        // Метод для генерации уникального артикула
        private string GenerateArticleCode()
        {
            // Генерация артикула в формате: ГодМесяцДеньЧасМинутаСекунда
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void BackToMainPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
