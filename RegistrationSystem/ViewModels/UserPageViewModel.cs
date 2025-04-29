using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistrationSystem.Models;



namespace RegistrationSystem.ViewModels
{
   public partial class UserPageViewModel : ViewModelBase
    {
        public ObservableCollection<Userdb> Users {get;}

        //public ICommand EditCommand { get;}
        //public ICommand DeleteCommand { get; }

        public UserPageViewModel() {
            var userManager = new UserManager();

            userManager.AddUser("Joshua", "Garcia", "Canasa", "JoshuaGarcia142", "4143", "joshuaGarcia@gmail.com");
            userManager.AddUser("Joshua1", "Garcia", "Canasa", "JoshuaGarcia142", "4143", "joshuaGarcia@gmail.com");
            userManager.AddUser("Joshua2", "Garcia", "Canasa", "JoshuaGarcia142", "4143", "joshuaGarcia@gmail.com");

            Users = new ObservableCollection<Userdb>(userManager.GetAllUsers());

            userManager.ListAllUser();


            //DeleteCommand = ReactiveCommand.Create<Userdb>(user =>
            //{

            //    //Users.Remove(user);

            //    Dispatcher.UIThread.Post(() =>
            //    {
            //        Debug.WriteLine($"Deleting user: {user?.UserName ?? "null"}");

            //    });
            //});


            



            }

        [RelayCommand]
        private void Delete(Userdb user)
        {
            if (user == null) return;

            Dispatcher.UIThread.Post(() =>
            {
                Debug.WriteLine($"Deleting user: {user.UserName}");
                Users.Remove(user);
            });
        }


    }
}
