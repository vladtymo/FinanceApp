using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.Property(a => a.Login)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.Password)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
