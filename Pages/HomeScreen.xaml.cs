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

            //Book book1 = new Book
            //{
            //    Title = "The Great Gatsby",
            //    Author = "F. Scott Fitzgerald",
            //    Publisher = "Scribner",
            //    PageCount = 180,
            //    Genre = "Classic",
            //    Year = 1925,
            //    CostPrice = 10,
            //    SellingPrice = 20,
            //    IsContinuation = false,
            //};

            //Book book2 = new Book
            //{
            //    Title = "Harry Potter and the Philosopher's Stone",
            //    Author = "J.K. Rowling",
            //    Publisher = "Bloomsbury Publishing",
            //    PageCount = 223,
            //    Genre = "Fantasy",
            //    Year = 1997,
            //    CostPrice = 8,
            //    SellingPrice = 15,
            //    IsContinuation = true,
            //};

            //User user = new User
            //{
            //    Login = "Admin",
            //    Password = "1234"
            //};

            //_dataContext.Book.Add(book1);
            //_dataContext.Book.Add(book2);
            //_dataContext.User.Add(user);
            //_dataContext.SaveChanges();
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
                    MessageBox.Show("Uncorrect password");
                }
            }
            else
            {
                // Uncorrect login
                MessageBox.Show("Uncorrect login");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigatorObject.Switch(new RegisterScreen(_dataContext));
        }
    }
}
