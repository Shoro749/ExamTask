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
    /// Interaction logic for SellBookScreen.xaml
    /// </summary>
    public partial class SellBookScreen : UserControl
    {
        private readonly DataContext _dataContext;
        private List<Book> _books;
        public SellBookScreen(DataContext dataContext, List<Book> books)
        {
            InitializeComponent();

            _dataContext = dataContext;
            tb_discount.Text = "0";
            _books = books;

            int sum = 0;
            foreach (Book book in books)
            {
                string str = $"Book: {book.Title}; Price: {book.SellingPrice};";
                sum += Convert.ToInt32(book.SellingPrice);
                lb_bill.Items.Add(str);
            }
            l_value.Content = $"VALUE: {sum}";
            l_totalValue.Content = $"TOTAL VALUE: {sum}";

            tb_discount.TextChanged += (sender, e) =>
            {
                if (int.TryParse(tb_discount.Text, out int discount))
                {
                    int totalValue = Convert.ToInt32(discount);

                    l_totalValue.Content = "TOTAL VALUE: " + (sum - totalValue).ToString();
                }
                else
                {
                    throw new ArgumentException(nameof(tb_discount.Text));
                }
            };
        }

        private void SellBook_Click(object sender, RoutedEventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (var selectedItem in _books)
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
            NavigatorObject.Switch(new Bookstore(_dataContext));
        }
    }
}
