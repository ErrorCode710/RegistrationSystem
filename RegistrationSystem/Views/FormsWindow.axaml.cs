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
        if (string.IsNullOrWhiteSpace(UserName.Text))
        {
            Debug.WriteLine("Username is required!");
            return;
        }


        NewUser = new Userdb
        {
            FirstName = FirstName.Text,
            LastName = LastName.Text,
            UserName = UserName.Text,
            Email = Email.Text,
            Role = "user", // Default role for new user
            Password = "jhunreyCute" // You can implement a password field if you need
        };

        Debug.WriteLine($"Creating user: {NewUser.UserName}");
        Close(NewUser);
    }

   
    private void OnCancelButtonClicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close(); 
    }

   
}
