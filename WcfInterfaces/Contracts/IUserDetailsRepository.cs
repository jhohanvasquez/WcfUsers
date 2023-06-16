using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDomain.Entity;

namespace WcfInterfaces.Contracts
{
    public interface IUserDetailsRepository
    {
        bool DeleteUser(int UserInfo);
        bool FindById(int id);
        List<UserDetails> GetAllUser();
        List<UserDetails> GetUserDetails(string UserName);
        string InsertUserDetails(UserDetails UserInfo);
        bool UpdateUser(UserDetails UserID);
    }
}
