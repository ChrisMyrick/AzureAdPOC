using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalAD_POC.Models
{
    public class UserInfoFromAD
    {
        public UserInfoFromAD(string login, string email, string displayName)
        {
            this.Login = login;
            this.Email = email;
            this.DisplayName = displayName;
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }

        public override bool Equals(object obj)
        {
            return this.Login.Equals(((UserInfoFromAD)obj).Login);
        }

        public override int GetHashCode()
        {
            return this.Login.GetHashCode();
        }
    }
}
