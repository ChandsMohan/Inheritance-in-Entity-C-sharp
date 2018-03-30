using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityInheritance_MT
{
    public partial class Login
    {
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public static Login Authenticate(string UserName, string Password)
        {
            try
            {
                using (EntityInheritanceEntities context = new EntityInheritanceEntities())
                {
                    Login login = context.Logins.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
                    return login;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
    }
}
