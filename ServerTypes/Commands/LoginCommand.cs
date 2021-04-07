using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerTypes
{
    public class LoginCommand : ICommand
    {
        public CommandResult Execute(object parameters)
        {
            if (parameters.GetType() != typeof(object[]))
            {
                return new CommandResult(false, typeof(RegisterCommand));
            }

            IUserRepository userRepository = new UsersRepository(new MyDbContext());

            // [0] - Login; [1] - Password;
            object[] userData = parameters as object[];

            User user = userRepository.GetByLogin((string)userData[0]).Result;

            if(user == null)
            {
                return new CommandResult(false, typeof(LoginCommand));
            }

            if (user.Password == ComputeSha256Hash((string)userData[1]))
            {
                return new CommandResult(true, typeof(LoginCommand));
            }   
            else
            {
                return new CommandResult(false, typeof(LoginCommand));
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
