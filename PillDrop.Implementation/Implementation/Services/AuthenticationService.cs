using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Extensions;

namespace PillDrop.Implementation.Implementation.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public User Validate(string username, string password)
        {
            var user = _userService.GetByEmail(username);
            if (user == null)
                throw new Exception("Invalid Username or Password.");
            if (username == "" && password == "")
                throw new Exception("Please enter your username and password.");
            if (username == "")
                throw new Exception("Please enter your username.");
            if (password == "")
                throw new Exception("Please enter your password.");
            //if (TemporaryPasswordCredentialsIsValid(user, username, password))
            //{
            //    if ((user.TemporaryPasswordCreatedDate.Value.AddMinutes(60) < DateTime.Now))
            //    {
            //        throw new Exception("The temporary password has expired");
            //    }
            //    return user;
            //}
            if (!CredentialsIsValid(user, username, password))
                throw new Exception("Invalid Username or Password.");
            return user;
        }
        public bool TemporaryPasswordCredentialsIsValid(User user, string userName, string password)
        {
            if (user == null)
                return false;

            if (!string.IsNullOrEmpty(user.TemporaryPassword) &&
                user.TemporaryPassword == GetPasswordHash(userName, password))
            {
               _userService.SaveOrUpdate(user);

                return true;
            }

            return false;
        }
        public string GetPasswordHash(string userName, string password)
        {
            const string passwordSalt = "hmmmmm...th1s 1s very s@lty. I l0ve AppointMat3.";
            var hashedPassword = string.Format("{0}{1}{2}", userName, passwordSalt, password);
            return hashedPassword.ToHash();
        }

        public bool CredentialsIsValid(User user, string userName, string password)
        {
            if (user == null)
                return false;

            if (user.PasswordHash == GetPasswordHash(userName, password))
            {
                return true;
            }

            return false;
        }
      
    }
}
