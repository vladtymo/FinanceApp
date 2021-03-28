using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersDb
    {
        private UserDbContext _context;

        public UsersDb()
        {
            _context = new UserDbContext();
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public void AddUser(User value)
        {
            try
            {
                UserDbContext newUser = new UserDbContext();

                newUser.Users.Add(new User()
                {
                    Login = value.Login,
                    Password = value.Password,
                });
                newUser.SaveChanges();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
