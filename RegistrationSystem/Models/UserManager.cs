﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationSystem.Models
{
   public class UserManager
    {
        private List<Userdb> users;

        public UserManager() {

            users = new List<Userdb>();
            Admin();

        }
        public void Admin()
        {
            if (!users.Any(u => u.Role == "admin"))
            {
                var newUser = new Userdb
                {
                    Role = "admin",
                    FirstName = "Jhun Rey",
                    LastName = "Canasa",
                    MiddleName = "Guinto",
                    UserName = "JhunreyCute",
                    Password = "69420",
                    Email = "jhunreyCuteLangSakalam@gmail.com",
                };

                users.Add(newUser);
            }
        }
        public void AddUser(string firstName, string lastName, string middleName,string userName, string password, string email)
        {
            var newUser = new Userdb
            {
                Role = "user",
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                UserName = userName,
                Password = password,
                Email = email,
            };

            users.Add(newUser);
            
        }
       
        public bool CheckUser(string userName, string passWord)
        {
            foreach (var user in users) {
                if (user.UserName == userName && user.Password == passWord)
                {
                    return true;
                } 

            }
            return false;
           
        }
        public Userdb GetUser(string userName, string passWord)
        {
            foreach (var user in users)
            {
                if (user.UserName == userName && user.Password == passWord)
                {
                    return user;
                }
            }
            return null;
        }

        public void ListAllUser() {

            foreach (var user in users) {
                Debug.WriteLine($" {user.Role}{user.FirstName}");
            } 

        }
    }
}
