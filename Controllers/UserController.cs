using MakeMeUpzz.Handlers;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class UserController
    {
        UserHandler userHandler = new UserHandler();

        public User ValidateUser(string username, string password)
        {
            return userHandler.ValidateUser(username, password);
        }

        public void RememberUser(User user, HttpResponse response)
        {
            HttpCookie cookie = new HttpCookie("user_cookie");
            cookie.Value = user.UserID.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            response.Cookies.Add(cookie);
        }

        private bool ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            if (username.Length < 5 || username.Length > 15) return false;
            return Regex.IsMatch(username, @"^[a-zA-Z]+$");
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.EndsWith(".com");
        }

        private bool ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword)) return false;
            if (password != confirmPassword) return false;
            return Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d).+$");
        }

        public bool RegisterUser(string username, string email, DateTime dob, string gender, string password, string confirmPassword, out string errorMessage)
        {
            if (!ValidateUsername(username))
            {
                errorMessage = "Username must be 5-15 characters long and contain only alphabets.";
                return false;
            }

            if (!userHandler.IsUsernameUnique(username))
            {
                errorMessage = "Username is already taken.";
                return false;
            }

            if (!ValidateEmail(email))
            {
                errorMessage = "Email cannot be empty and must end with '.com'.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                errorMessage = "Gender must be chosen.";
                return false;
            }

            if (!ValidatePassword(password, confirmPassword))
            {
                errorMessage = "Password must be alphanumeric and match the confirmation password.";
                return false;
            }

            if (dob == DateTime.MinValue)
            {
                errorMessage = "Date of Birth cannot be empty.";
                return false;
            }

            userHandler.RegisterUser(username, email, dob, gender, password);
            errorMessage = string.Empty;
            return true;
        }

        public List<User> GetAllCustomers()
        {
            return userHandler.GetAllCustomers();
        }

        public User GetUserById(int id)
        {
            return userHandler.GetUserById(id);
        }

        public bool UpdateUser(User user, out string errorMessage)
        {
            if (!ValidateUsername(user.Username))
            {
                errorMessage = "Username must be 5-15 characters long and contain only alphabets.";
                return false;
            }

            if (!ValidateEmail(user.UserEmail))
            {
                errorMessage = "Email must end with '.com'.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.UserGender))
            {
                errorMessage = "Gender must be chosen.";
                return false;
            }

            if (user.UserDOB == DateTime.MinValue)
            {
                errorMessage = "Date of Birth cannot be empty.";
                return false;
            }

            userHandler.UpdateUser(user);
            errorMessage = string.Empty;
            return true;
        }

        public bool UpdatePassword(User user, string newPassword, string confirmPassword, out string error)
        {
            if (!ValidatePassword(newPassword, confirmPassword))
            {
                error = "Password must be alphanumeric and match the confirmation password.";
                return false;
            }

            user.UserPassword = newPassword;
            userHandler.UpdateUser(user);
            error = string.Empty;
            return true;
        }

    }
}