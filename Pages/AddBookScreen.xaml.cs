using ExamTask.Models;
using ExamTask.Navigator;
using System.Windows;
using System.Windows.Controls;

namespace ExamTask.Pages;

/// <summary>
/// Interaction logic for AddBookScreen.xaml
/// </summary>
public partial class AddBookScreen : UserControl
{
    private readonly DataContext _dataContext;
    public AddBookScreen(DataContext dataContext)
    {
        InitializeComponent();
        _dataContext = dataContext;
    }

    private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        _dataContext.Book.Add(new Book
        {
            Title = tb_title.Text,
            Author = tb_author.Text,
            Publisher = tb_publisher.Text,
            PageCount = Convert.ToInt32(tb_pageCount.Text),
            Genre = tb_genre.Text,
            Year = Convert.ToInt32(tb_year.Text),
            CostPrice = Convert.ToInt32(tb_costPrice.Text),
            SellingPrice = Convert.ToInt32(tb_sellingPrice.Text),
            IsContinuation = cb_IsContinuation.IsChecked ?? false,
        });
        _dataContext.SaveChanges();
        NavigatorObject.Switch(new Bookstore(_dataContext));
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        NavigatorObject.Switch(new Bookstore(_dataContext));
    }
}
