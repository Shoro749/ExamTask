using ExamTask.Models;
using ExamTask.Navigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ExamTask.Pages
{
    /// <summary>
    /// Interaction logic for EditScreen.xaml
    /// </summary>
    public partial class EditScreen : UserControl
    {
        private readonly DataContext _dataContext;
        private readonly Book _book;
        public EditScreen(DataContext dataContext, Book book)
        {
            InitializeComponent();
            _dataContext = dataContext;
            _book = book;
            tb_title.Text = book.Title;
            tb_author.Text = book.Author;
            tb_publisher.Text = book.Publisher;
            tb_pageCount.Text = Convert.ToString(book.PageCount);
            tb_genre.Text = book.Genre;
            tb_year.Text = Convert.ToString(book.Year);
            tb_costPrice.Text = Convert.ToString(book.CostPrice);
            tb_sellingPrice.Text = Convert.ToString(book.SellingPrice);
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            _book.Title = tb_title.Text;
            _book.Author = tb_author.Text;
            _book.Publisher = tb_publisher.Text;
            _book.PageCount = Convert.ToInt32(tb_pageCount.Text);
            _book.Genre = tb_genre.Text;
            _book.Year = Convert.ToInt32(tb_year.Text);
            _book.CostPrice = Convert.ToInt32(tb_costPrice.Text);
            _book.SellingPrice = Convert.ToInt32(tb_sellingPrice.Text);
            _book.IsContinuation = cb_IsContinuation.IsChecked ?? false;

            _dataContext.SaveChanges();
            NavigatorObject.Switch(new Bookstore(_dataContext));
        }
    }
}
