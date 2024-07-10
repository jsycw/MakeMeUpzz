using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class UserFactory
    {
        public static User Create(int id, String username, String email, DateTime dob, String gender, String role, String password)
        {
            User user = new User();
            user.UserID = id;
            user.Username = username;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserRole = role;
            user.UserPassword = password;
            return user;
        }
    }
}