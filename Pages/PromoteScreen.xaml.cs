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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamTask.Pages
{
    /// <summary>
    /// Interaction logic for PromoteScreen.xaml
    /// </summary>
    public partial class PromoteScreen : UserControl
    {
        private readonly DataContext _dataContext;
        private List<Book> _books;
        public PromoteScreen(DataContext dataContext, List<Book> books)
        {
            InitializeComponent();
            _dataContext = dataContext;
            _books = books;
        }

        private void Promote_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (int.TryParse(tb_promote.Text, out number))
            {
                if (number >= 0 && number <= 100)
                {
                    foreach (Book book in _books)
                    {
                        book.SellingPrice = Convert.ToInt32(Convert.ToDecimal(book.SellingPrice) * (Convert.ToDecimal(number) / 100));
                    }
                    _dataContext.SaveChanges();
                    NavigatorObject.Switch(new Bookstore(_dataContext));
                }
                else
                {
                    MessageBox.Show("Please enter a number in percentages.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number in percentages.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new Bookstore(_dataContext));
        }
    }
}
