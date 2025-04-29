using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistrationSystem.Models;
using MsBox.Avalonia;
using System.Text.RegularExpressions;
using MsBox.Avalonia.Enums;
using RegistrationSystem.Views;
using Avalonia.Controls.ApplicationLifetimes;



namespace RegistrationSystem.ViewModels
{
   public partial class UserPageViewModel : ViewModelBase
    {
        public ObservableCollection<Userdb> Users {get;}
        private readonly List<Userdb> _allUsers = new();
        private readonly UserManager userManager = UserManager.Instance;





        [ObservableProperty]
        private string _searchText = string.Empty;


        public UserPageViewModel() {
           

            Users = new ObservableCollection<Userdb>(userManager.GetAllUsers());
            

            _allUsers = userManager.GetAllUsers().ToList(); 
            Users = new ObservableCollection<Userdb>(_allUsers);
            userManager.ListAllUser();




            

        }
        

        [RelayCommand]
        public async Task AddUserAsync()
        {
            var addUserWindow = new FormsWindow();

            var safeOwner = new Window()
            {
                Width = 1,
                Height = 1,
                WindowStartupLocation = WindowStartupLocation.Manual,
                ShowInTaskbar = false,
                CanResize = false,
                SystemDecorations = SystemDecorations.None
            };
            safeOwner.Show();

            var result = await addUserWindow.ShowDialog<Userdb?>(safeOwner);
            safeOwner.Close();

            if (result != null)
            {

                if (!IsValidEmail(result.Email))
                {


                    var box = MessageBoxManager
           .GetMessageBoxStandard("Invalid Email", "Please Provide Valid Email", ButtonEnum.Ok);
                    _ = await box.ShowAsync();

                    return;
                }
                if (userManager.UsernameExists(result.UserName))
                {
                    var box = MessageBoxManager
                       .GetMessageBoxStandard("Duplicate Username", "This username already exists.", ButtonEnum.Ok);
                    await box.ShowAsync();
                    return;
                }
                Users.Add(result);
                userManager.AddUserFromObject(result); 
                userManager.ListAllUser();
            }
        }

        [RelayCommand]
        private void Delete(Userdb user)
        {

            if (user == null) return;

            Dispatcher.UIThread.Post(() =>
            {

                
                userManager.DeleteUser(user.Id);
                Debug.WriteLine($"Deleting user: {user.UserName}");
                Users.Remove(user);
                _allUsers.Remove(user);
                Debug.WriteLine($"This is the update list of user");
                userManager.ListAllUser();
                Debug.WriteLine($"This is the update list of user");
               
            });
        }
        
        
        [RelayCommand]
        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                
                Users.Clear();
                foreach (var user in _allUsers)
                {
                    Users.Add(user);
                }
            }
            else
            {
              
                var filtered = _allUsers.Where(u =>
                    (u.UserName?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) == true) ||
                    (u.Email?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) == true) ||
                    (u.FirstName?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) == true) ||
                    (u.LastName?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) == true)
                ).ToList();

                Users.Clear();
                foreach (var user in filtered)
                {
                    Users.Add(user);
                }
            }
        }
        partial void OnSearchTextChanged(string value)
        {
         
            SearchCommand.Execute(null);
        }

        public static bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }



    }
}
