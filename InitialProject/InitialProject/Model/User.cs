﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }


        public User() { }


        public User(string username, string password, UserType userType)
        {
            Username = username;
            Password = password;
            UserType = userType;
        }

        public User(int id, string username, string password, UserType userType)
        {
            Id = id;
            Username = username;
            Password = password;
            UserType = userType;
        }
    }
}