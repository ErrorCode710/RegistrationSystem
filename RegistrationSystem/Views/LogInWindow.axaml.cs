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
        

        var userValid = new UserManager();
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
    private void onLoginSucces(string firstname ,string lastname, string middlename, string username, string email, string password, string Role)
    {
         if(Role == "admin") {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        } else
        {
            var mainWindow = new UserInfo(firstname, username, middlename, username,email,password);
            mainWindow.Show();
            this.Close();
        }
        // if the user is addmin show this admin panel if not show the log in sucess page and box
        
    }
   
}