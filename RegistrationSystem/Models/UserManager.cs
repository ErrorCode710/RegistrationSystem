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

        private static UserManager _instance;
        public static UserManager Instance => _instance ??= new UserManager();

        private List<Userdb> users;
        private int IdCounter = 1;

        public UserManager() {

            users = new List<Userdb>();
            Admin();
            LoadDummyUsers();

        }
        public void Admin()
        {
            if (!users.Any(u => u.Role == "admin"))
            {
                var newUser = new Userdb
                {
                    Id = 0,
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
        public void AddUser(string firstName, string lastName, string middleName,string userName, string password, string email,string role)
        {
            var newUser = new Userdb
            {
                Id = IdCounter++,
                Role = role,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                UserName = userName,
                Password = password,
                Email = email,
            };

            users.Add(newUser);
            
        }

        public void AddUserFromObject(Userdb user)
        {
            
            var newUser = new Userdb
            {
                Id = IdCounter++,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                UserName = user.UserName,
                Password = user.Password ?? "defaultPassword",
                Email = user.Email,
                Role = user.Role ?? "user" 
            };

            users.Add(newUser);
            Debug.WriteLine($"Added new user: {newUser.UserName} (ID: {newUser.Id})");
        }

        public void DeleteUser(int UserId)
        {
            var userToRemove = users.FirstOrDefault(u => u.Id == UserId );

            if (userToRemove != null) {
            
             users.Remove(userToRemove);
            }
           
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
                Debug.WriteLine($" {user.Role} {user.FirstName} {user.Id}");
            } 

        }
        public List<Userdb> GetAllUsers()
        {
            return users;
        }

       
        public void LoadDummyUsers()
        {

           
            AddUser("Joshua", "Garcia", "Canasa", "garciajoshuae", "4143", "joshuaGarcia@gmail.com", "user");
            AddUser("Daniel", "Padilla", "Canasa", "supremo_dp", "4143", "supremoDj@gmail.com", "user");
            AddUser("Jarren", "Garcia", "Canasa", "jarrengarcia_", "4143", "jarrengarcia@gmail.com", "user");
            AddUser("No", "", "MiddleName", "jarrengarcia_", "4143", "joshuaGarcia@gmail.com", "user");
        }
        public bool UsernameExists(string username)
        {
            return users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
