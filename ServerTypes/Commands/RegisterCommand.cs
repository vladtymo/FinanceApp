using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Entities;
using DAL.EF;

namespace ServerTypes
{
    public class RegisterCommand : ICommand
    {
        public CommandResult Execute(object parameters)
        {
            if (parameters.GetType() != typeof(object[]))
            {
                return new CommandResult(false, typeof(RegisterCommand));
            }

            UsersRepository userRepository = new UsersRepository(new MyDbContext());

            // [0] - Login; [1] - Password; [2] - Email; [3] - Name; [4] - Suranme;
            object[] userData = parameters as object[];

            User user = new User();

            user.Login = (string)userData[0];
            user.Password = (string)userData[1];
            user.Email = (string)userData[2];
            user.Name = (string)userData[3];
            user.Surname = (string)userData[4];

            userRepository.Create(user);

            return new CommandResult(true, typeof(RegisterCommand));
        }
    }
}
