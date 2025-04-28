using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationSystem.Models;


namespace RegistrationSystem.ViewModels
{
   public  class UserPageViewModel : ViewModelBase
    {
        public ObservableCollection<Userdb> Users {get;}

        public UserPageViewModel() {
            var userManager = new UserManager();

            userManager.AddUser("JOshua", "Garcia", "Canasa", "JoshuaGarcia142", "4143", "joshuaGarcia@gmail.com");
            userManager.AddUser("JOshua1", "Garcia", "Canasa", "JoshuaGarcia142", "4143", "joshuaGarcia@gmail.com");
            userManager.AddUser("JOshua2", "Garcia", "Canasa", "JoshuaGarcia142", "4143", "joshuaGarcia@gmail.com");

            Users = new ObservableCollection<Userdb>(userManager.GetAllUsers());

            userManager.ListAllUser();
        }
       

    }
}
