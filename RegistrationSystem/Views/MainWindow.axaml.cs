using Avalonia.Controls;
using FluentAvalonia.UI.Windowing;
using RegistrationSystem.ViewModels;
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
}