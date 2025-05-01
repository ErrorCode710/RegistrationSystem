using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FluentAvalonia.UI.Windowing;
using RegistrationSystem.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using System.Linq;
using RegistrationSystem.ViewModels;

namespace RegistrationSystem.Views;

public partial class LogInWindow : AppWindow
{
    public LogInWindow()
    {
        InitializeComponent();
        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;

       
        

    }
    private void OnLogInButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        logInValidationAsync(); // Call the validation method when the button is clicked
    }
    private async Task logInValidationAsync()
    {
        // we need to create an indicator if th
        string inputUserName = UserName.Text;
        string inputPassword = Password.Text;


        //var userValid = new UserManager();
        var userValid = UserManager.Instance;
        var user = userValid.GetUser(inputUserName, inputPassword);

        string email = user?.Email;
        string firstName = user?.FirstName;
        string lastName = user?.LastName;
        string middleName = user?.MiddleName;
        string role = user?.Role;
        string password = user?.Password;
        string userName = user?.UserName;

        bool isUserValid = userValid.CheckUser(inputUserName, inputPassword);

       

        if (user != null) {
            if (user.Role == "admin")
            {
                onLoginSucces(firstName, lastName, middleName, userName, email, password, role);
            }
            else {
                 onLoginSucces(firstName, lastName, middleName, userName, email, password, role);
            }
        
        } else
        {
            var box = MessageBoxManager
          .GetMessageBoxStandard("Caption", "Login Invalid Please Try Again",
              ButtonEnum.Ok);



            var result = await box.ShowAsync();
        }
       
        
    }
    private void onLoginSucces(string firstname, string lastname, string middlename, string username, string email, string password, string role)
    {
        
        
        var existingMainWindow = Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.Windows.FirstOrDefault(w => w is MainWindow)
            : null;

        if (role == "admin")
        {
            if (existingMainWindow != null)
            {
                Debug.WriteLine("MainWindow is already open.");
                var userWindow = new UserInfo(firstname, username, middlename, username, email, password);
                userWindow.Show();


            }
            else
            {
               
                var mainWindow = new MainWindow();
                var mainWindowViewModel = new MainWindowViewModel
                {
                    LoggedInUsername = username 
                };
                mainWindow.DataContext = mainWindowViewModel;
                mainWindow.Show();

                Debug.WriteLine("MainWindow opened.");
            }

            this.Close();
        }
        else
        {
            var userWindow = new UserInfo(firstname, username, middlename, username, email, password);
            userWindow.Show();
            Debug.WriteLine("UserInfo window opened.");
            this.Close();
        }
    }

}