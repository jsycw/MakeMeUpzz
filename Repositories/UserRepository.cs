using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class UserRepository
    {
        MakeMeUpzzDatabaseEntities db = DatabaseSingleton.GetInstance();
        public User GetUserById(int id)
        {
            return (from u in db.Users where u.UserID == id select u).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public int GenerateId()
        {
            var lastUserId = db.Users.OrderByDescending(u => u.UserID).Select(u => u.UserID).FirstOrDefault();
            return lastUserId + 1;
        }

        public void RegisterUser(int id, String username, String email, DateTime dob, String gender, String role, String password)
        {
            User user = new User();
            user.UserID = id;
            user.Username = username;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserRole = role;
            user.UserPassword = password;
            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<User> GetUsersByRole()
        {
            return db.Users.Where(u => u.UserRole == "User").ToList();
        }

        public void UpdateUser(User user)
        {
            User now = db.Users.FirstOrDefault(u => u.UserID == user.UserID);

            if (now != null)
            {
                now.Username = user.Username;
                now.UserEmail = user.UserEmail;
                now.UserDOB = user.UserDOB;
                now.UserGender = user.UserGender;
                now.UserPassword = user.UserPassword;
                db.SaveChanges();
            }
        }

        public User GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.Username == username);
        }

        public bool IsUsernameUnique(string username)
        {
            return !db.Users.Any(u => u.Username == username);
        }
    }
}