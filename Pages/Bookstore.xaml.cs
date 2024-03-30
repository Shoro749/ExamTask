using ExamTask.Models;
using ExamTask.Navigator;
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
using System.Xml;

namespace ExamTask.Pages
{
    /// <summary>
    /// Interaction logic for Bookstore.xaml
    /// </summary>
    public partial class Bookstore : UserControl
    {
        private readonly DataContext _dataContext;
        public Bookstore(DataContext dataContext)
        {
            InitializeComponent();
            _dataContext = dataContext;

            //Book book1 = new Book
            //{
            //    Title = "The Great Gatsby",
            //    Author = "F. Scott Fitzgerald",
            //    Publisher = "Scribner",
            //    PageCount = 180,
            //    Genre = "Classic",
            //    Year = 1925,
            //    CostPrice = 10,
            //    SellingPrice = 20,
            //    IsContinuation = false,
            //};

            //Book book2 = new Book
            //{
            //    Title = "Harry Potter and the Philosopher's Stone",
            //    Author = "J.K. Rowling",
            //    Publisher = "Bloomsbury Publishing",
            //    PageCount = 223,
            //    Genre = "Fantasy",
            //    Year = 1997,
            //    CostPrice = 8,
            //    SellingPrice = 15,
            //    IsContinuation = true,
            //};
            //dataContext.Book.Add(book1);
            //dataContext.Book.Add(book2);
            //_dataContext.SaveChanges();

            dataGrid.ItemsSource = _dataContext.Book.ToList();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new AddBookScreen(_dataContext));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var books = _dataContext.Book.Where(b => b.Title == tb_search.Text || b.Author == tb_search.Text || b.Genre == tb_search.Text).ToList();

            if (books.Any())
            {
                dataGrid.ItemsSource = books;
            }
            else
            {
                dataGrid.ItemsSource = _dataContext.Book.ToList();
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = dataGrid.SelectedItems;
            if (selectedItems.Count > 0)
            {
                List<int> selectedIds = new List<int>();

                foreach (var selectedItem in selectedItems)
                {
                    if (selectedItem is Book yourObject)
                    {
                        int id = yourObject.Id;
                        selectedIds.Add(id);
                    }
                }

                foreach (var id in selectedIds)
                {
                    Book item = _dataContext.Set<Book>().Find(id) ??
                    throw new ArgumentNullException();

                    _dataContext.Set<Book>().Remove(item);
                    _dataContext.SaveChanges();
                }
                dataGrid.ItemsSource = _dataContext.Book.ToList();
            }
            else
            {
                MessageBox.Show("Please select at least one item to delete.");
            }
            
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dataGrid.SelectedItems;
            if (selectedItem.Count == 1)
            {
                var selectedBook = selectedItem[0] as Book;
                if (selectedBook != null)
                {
                    NavigatorObject.Switch(new EditScreen(_dataContext, selectedBook));
                }
            }
            else
            {
                MessageBox.Show("Please select at least one item to edit.");
            }
        }

        private void SellBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = dataGrid.SelectedItems;
            if (selectedItems.Count > 0)
            {
                List<Book> selectedBooks = new List<Book>();
                foreach (var item in selectedItems)
                {
                    if (item is Book book)
                    {
                        selectedBooks.Add(book);
                    }
                }
                NavigatorObject.Switch(new SellBookScreen(_dataContext, selectedBooks));
                dataGrid.ItemsSource = _dataContext.Book.ToList();
            }
            else
            {
                MessageBox.Show("Please select at least one item to edit.");
            }
        }

        private void WriteOfBook_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PromoteBooks_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PutBookAside_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
