using Avalonia.Controls;
using FluentAvalonia.UI.Windowing;
using RegistrationSystem.ViewModels;
using MsBox.Avalonia;
namespace RegistrationSystem.Views;

public partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();
        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
        this.DataContext = new MainWindowViewModel();

        
         
    }
    private void OnLogoutButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
        

        this.Close();
        var logInWindow = new LogInWindow();
        logInWindow.Show();
    }
}