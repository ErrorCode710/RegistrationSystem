using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RegistrationSystem.Models;
using RegistrationSystem.ViewModels;
using System;
using System.Diagnostics;

namespace RegistrationSystem;

public partial class FormsWindow : Window
{

    public Userdb NewUser { get; set; }
    public FormsWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
    private void OnAddButtonClicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedItem = RoleComboBox.SelectedItem as ComboBoxItem;
        string selectedRole = selectedItem?.Content?.ToString() ?? "user";

        if (string.IsNullOrWhiteSpace(UserName.Text))
        {
            Debug.WriteLine("Username is required!");
            return;
        }


        NewUser = new Userdb
        {
            FirstName = FirstName.Text,
            LastName = LastName.Text,
            MiddleName = MiddleName.Text,
            UserName = UserName.Text,
            Email = Email.Text,
            Role = selectedRole, 
            Password = Password.Text 
        };

        Debug.WriteLine($"Creating user: {NewUser.UserName}");
        Close(NewUser);
    }

   
    private void OnCancelButtonClicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close(); 
    }

   
}
