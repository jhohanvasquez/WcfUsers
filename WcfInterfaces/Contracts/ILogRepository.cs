using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDomain.Entity;

namespace WcfInterfaces.Contracts
{
    public interface ILogRepository
    {
        void InsertLog(string log);
    }
}
