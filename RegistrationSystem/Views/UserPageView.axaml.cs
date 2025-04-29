using Avalonia;
using Avalonia.Controls;
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


}