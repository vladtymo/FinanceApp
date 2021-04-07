using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UsersRepository : IUserRepository
    {
        internal MyDbContext myDbContext;

        public UsersRepository(MyDbContext _myDbContext)
        {
            myDbContext = _myDbContext; 
        }
        public async Task Create(User user)
        {
            string pass = ComputeSha256Hash(user.Password);
            user.Password = pass;
            myDbContext.Users.Add(user);
            await myDbContext.SaveChangesAsync();
        }
        public Task<User> GetById(int id)
        {
            return Task.Run(() =>
            {
                return myDbContext.Users.FirstOrDefault(s => s.Id == id);
            });
        }
        public Task<User> GetByLogin(string login)
        {
            return Task.Run(() =>
            {
                return myDbContext.Users.FirstOrDefault(s => s.Login == login);
            });
        }
        public async Task UpdatePassword(int id, string newPassword)
        {
            var _user = myDbContext.Users.FirstOrDefault(s => s.Id == id);
            if (_user != null)
            {
                string pass = ComputeSha256Hash(newPassword);
                _user.Password = pass;
                await myDbContext.SaveChangesAsync();
            }
            else
                return;
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
