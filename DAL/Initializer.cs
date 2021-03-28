using System.Data.Entity;

namespace DAL
{
    internal class Initializer : DropCreateDatabaseIfModelChanges<UserDbContext>
    {
        protected override void Seed(UserDbContext context)
        {
            base.Seed(context);

            context.Users.Add(new User()
            {
                Password = "admin",
                Login = "admin",
            });
            context.SaveChanges();
        }
    }
}