using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RegistrationSystem.ViewModels;

namespace RegistrationSystem.Views;

public partial class UserPageView : UserControl
{
    public UserPageView()
    {
        InitializeComponent();
        DataContext = new UserPageViewModel();
    }

    private async void TryLogInButton_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LogInWindow();
        loginWindow.Show(); 
    }


}