using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RegistrationSystem.Models;
using RegistrationSystem.ViewModels;

namespace RegistrationSystem.Views;

public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();
        DataContext = new HomePageViewModel();
        var userManager = new UserManager();
        Totaluser.Text = userManager.GetTotalUsers().ToString();
    }


}