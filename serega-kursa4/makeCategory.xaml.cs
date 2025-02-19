using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для makeCategory.xaml
    /// </summary>
    public partial class makeCategory : Window
    {

        private readonly AppDbContext _context;
        public makeCategory()
        {
            InitializeComponent();
            _context = new AppDbContext(); // Инициализация контекста базы данных
        }

        private void AddCategory(object sender, RoutedEventArgs e)
        {
            string categoryName = categoryField.Text;

            if (string.IsNullOrEmpty(categoryName))
              
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Введите название категории.");
                return;
            }

            var existingCategory = _context.Categories
                    .FirstOrDefault(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            if (existingCategory != null)
            {
                MessageBox.Show("Такая категория уже существует.");
                return;
            }

            try
            {
                var category = new Category 
                { 
                    CategoryName = categoryName 
                };

                _context.Categories.Add(category);
                _context.SaveChanges();
                MessageBox.Show("Категория добавлена.");
                categoryField.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении категории: " + ex.Message);
            }
        }

        private void DeleteCategory(object sender, RoutedEventArgs e)
        {
            string categoryName = categoryField.Text;

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Введите название категории для удаления.");
                return;
            }


            var categoryToDelete = _context.Categories.FirstOrDefault(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            if (categoryToDelete == null)
            {
                MessageBox.Show("Категория не найдена.");
                return;
            }

            var productsInCategory = _context.Products
                  .Any(p => p.CategoryID == categoryToDelete.CategoryID);

            if (productsInCategory)
            {
                MessageBox.Show("Невозможно удалить категорию, так как в ней есть товары.");
                return;
            }

            // Ищем категорию по имени
            var category = _context.Categories
                    .FirstOrDefault(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

                if (category == null)
                {
                    MessageBox.Show("Категория не найдена.");
                    return;
                }


            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges(); // Сохраняем изменения в базе

                MessageBox.Show("Категория удалена.");
                categoryField.Clear(); // Очищаем поле ввода
            }
               
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при удалении категории: " + ex.Message);
            }
        }

        private void BackToMainPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
