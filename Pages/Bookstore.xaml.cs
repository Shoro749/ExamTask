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
    /// Interaction logic for Bookstore.xaml
    /// </summary>
    public partial class Bookstore : UserControl
    {
        private readonly DataContext _dataContext;
        public Bookstore(DataContext dataContext)
        {
            InitializeComponent();
            _dataContext = dataContext;
            dataGrid.ItemsSource = _dataContext.Book.ToList();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new AddBookScreen(_dataContext));
        }
    }
}
