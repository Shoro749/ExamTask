using ExamTask.Models;
using ExamTask.Navigator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace ExamTask.Pages
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        private readonly DataContext _dataContext;
        public HomeScreen()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(config.GetConnectionString("Default"))
                .Options;
            _dataContext = new DataContext(options);
        }

        private void InfoClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Login: Abmin\nPassword: 1234");
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var user = _dataContext.User.FirstOrDefault(u => u.Login == tb_login.Text);
            if (user != null)
            {
                if (user.Password == tb_password.Text)
                {
                    NavigatorObject.Switch(new Bookstore(_dataContext));
                }
                else
                {
                    // Uncorrect password
                    // NavigatorObject.Switch(new ErrorScreen());
                    throw new NotImplementedException();
                }
            }
            else
            {
                // Uncorrect login
                // NavigatorObject.Switch(new ErrorScreen());
                throw new NotImplementedException();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new RegisterScreen(_dataContext));
        }
    }
}
