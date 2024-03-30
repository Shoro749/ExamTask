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

namespace ExamTask.Pages
{
    /// <summary>
    /// Interaction logic for WriteOffScreen.xaml
    /// </summary>
    public partial class WriteOffScreen : UserControl
    {
        private readonly DataContext _dataContext;
        private Book _book;
        public WriteOffScreen(DataContext dataContext, Book selectedBook)
        {
            InitializeComponent();
            _dataContext = dataContext;
            _book = selectedBook;
            dataGrid.ItemsSource = _dataContext.BooksWrittenOff.ToList();
        }

        private void WriteOff_Click(object sender, RoutedEventArgs e)
        {
            if (tb_reason.Text.Length > 0)
            {
                _dataContext.BooksWrittenOff.Add(new BooksWrittenOff
                {
                    book = _book,
                    Reason = tb_reason.Text
                });
                _dataContext.SaveChanges();
                dataGrid.ItemsSource = _dataContext.BooksWrittenOff.ToList();
                NavigatorObject.Switch(new Bookstore(_dataContext));
            }
            else
            {
                MessageBox.Show("Please enter reason for book write-off.");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Bookstore(_dataContext));
        }
    }
}
