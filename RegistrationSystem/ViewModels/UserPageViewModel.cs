using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistrationSystem.Models;
using RegistrationSystem.Views;



namespace RegistrationSystem.ViewModels
{
   public partial class UserPageViewModel : ViewModelBase
    {
        public ObservableCollection<Userdb> Users {get;}
        private readonly List<Userdb> _allUsers = new();
        private readonly UserManager userManager = new UserManager();



       

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
            // Optional: Trigger search automatically when text changes
            SearchCommand.Execute(null);
        }


    }
}
