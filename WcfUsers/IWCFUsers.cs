using System;
using System.Collections.Generic;
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

    [ServiceContract]
    public interface IWCFUsers
    {
       
        [OperationContract]
        List<UserDetails> GetUserDetails(string UserName);

        [OperationContract]
        string InsertUserDetails(UserDetails UserInfo);

        [OperationContract]
        List<UserDetails> GetAllUser();

        [OperationContract]
        bool UpdateUser(UserDetails UserID);

        [OperationContract]
        bool DeleteUser(int UserInfo);

        [OperationContract]
        bool FindById(int id);
    }
}
