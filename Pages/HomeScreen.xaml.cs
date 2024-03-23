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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void InfoClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Login: Abmin\nPassword: 1234");
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (tb_login.Text == "Admin" && tb_password.Text == "1234")
            {
                NavigatorObject.Switch(new Bookstore());
            }
            else
            {
                //NavigatorObject.Switch(new ErrorScreen());
            }
        }
    }
}
