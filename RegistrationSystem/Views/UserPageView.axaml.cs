using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RegistrationSystem.Models;
using RegistrationSystem.ViewModels;
using System.Globalization;
using System;

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

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.DataContext is Userdb selectedUser)
        {
        

            if (btn.Content.ToString() == "Edit")
            {
                // Switch to edit mode
                UserGrid.SelectedItem = selectedUser;
                UserGrid.BeginEdit();

                btn.Content = "Save";
            }
            else if (btn.Content.ToString() == "Save")
            {
                // Save logic
                var userManager = new UserManager();
                userManager.UpdateUser(selectedUser); // assumes this commits to DB or collection

                UserGrid.CommitEdit();
                btn.Content = "Edit";
            }
        }
    }

    public class BoolToEditSaveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool isEditing && isEditing) ? "Save" : "Edit";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == "Save";
        }
    }

}