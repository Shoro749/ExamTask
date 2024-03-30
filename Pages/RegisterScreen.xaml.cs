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
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : UserControl
    {
        private readonly DataContext dataContext;
        public RegisterScreen(DataContext _dataContext)
        {
            InitializeComponent();
            dataContext = _dataContext;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_login.Text))
            {
                throw new ArgumentException(nameof(tb_login.Text));
            }
            else if (string.IsNullOrWhiteSpace(tb_password.Text))
            {
                throw new ArgumentException(nameof(tb_password.Text));
            }
            else
            {
                var user = new User
                {
                    Login = tb_login.Text,
                    Password = tb_password.Text,
                };
                dataContext.User.Add(user);
                dataContext.SaveChanges();
                MessageBox.Show("You have successfully registered!");
                NavigatorObject.Switch(new HomeScreen());
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new HomeScreen());
        }
    }
}
