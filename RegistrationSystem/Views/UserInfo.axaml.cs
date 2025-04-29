using Avalonia.Controls;
using Avalonia.Interactivity;
using RegistrationSystem.Views;

namespace RegistrationSystem
{
    public partial class UserInfo : Window
    {
        public UserInfo(string firstName, string lastName, string middleName, string username, string email, string password)
        {
            InitializeComponent();

            
            FirstNameText.Text = firstName;
            LastNameText.Text = lastName;
            MiddleNameText.Text = middleName;
            UsernameText.Text = username;
            EmailText.Text = email;
            PasswordText.Text = password;

          
            CloseButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object? sender, RoutedEventArgs e)
        {
            
            var loginWindow = new LogInWindow(); 
            loginWindow.Show();

            this.Close();
        }
    }
}
