using System.Web.Http;
using WcfInfrastructure.Repositories;
using WcfInterfaces.Contracts;

namespace WcfApiLog.Controllers
{
    /// <summary>
    /// customer controller class for testing security token 
    /// </summary>
    [Authorize]
    [RoutePrefix("api/logs")]
    public class LogsController : ApiController
    {
        public static ILogRepository iUserDetailsRepository = new LogRepository();

        [HttpPost]
        public IHttpActionResult InsertLog(string description)
        {
            iUserDetailsRepository.InsertLog(description);
            return Ok();
        }
    }
}
