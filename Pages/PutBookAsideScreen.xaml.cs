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
    /// Interaction logic for PutBookAsideScreen.xaml
    /// </summary>
    public partial class PutBookAsideScreen : UserControl
    {
        private readonly DataContext _dataContext;
        private Book book;
        public PutBookAsideScreen(DataContext dataContext, Book selectedBook)
        {
            InitializeComponent();
            _dataContext = dataContext;
            book = selectedBook;
            dataGrid.ItemsSource = _dataContext.ShelvedBooks.ToList();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Bookstore(_dataContext));
        }

        private void PutBookAside_Click(object sender, RoutedEventArgs e)
        {
            _dataContext.ShelvedBooks.Add(new ShelvedBooks
            {
                book = book,
            });
            _dataContext.SaveChanges();
            NavigatorObject.Switch(new Bookstore(_dataContext));
        }
    }
}
