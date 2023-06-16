using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfDomain.Entity;
using WcfInfrastructure.Repositories;
using WcfInterfaces.Contracts;

namespace WcfUsers
{
    public class ServiceUsers : IWCFUsers
    {
        public static IUserDetailsRepository iUserDetailsRepository = new UserDetailsRepository();

        public bool DeleteUser(int UserInfo)
        {
            return iUserDetailsRepository.DeleteUser(UserInfo);
        }

        public bool FindById(int id)
        {
            return iUserDetailsRepository.FindById(id);
        }

        public List<UserDetails> GetAllUser()
        {
            return iUserDetailsRepository.GetAllUser();
        }

        public List<UserDetails> GetUserDetails(string UserName)
        {
            return iUserDetailsRepository.GetUserDetails(UserName);
        }

        public string InsertUserDetails(UserDetails UserInfo)
        {
            return iUserDetailsRepository.InsertUserDetails(UserInfo);
        }

        public bool UpdateUser(UserDetails UserID)
        {
            return iUserDetailsRepository.UpdateUser(UserID);
        }
    }
}

