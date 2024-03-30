using ExamTask.Models;
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
        public SellBookScreen(DataContext dataContext, List<Book> books)
        {
            InitializeComponent();
            tb_discount.Text = "0";
        }
    }
}
