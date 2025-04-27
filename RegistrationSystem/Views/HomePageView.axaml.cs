using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RegistrationSystem.ViewModels;

namespace RegistrationSystem.Views;

public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();
        DataContext = new HomePageViewModel();
    }
}