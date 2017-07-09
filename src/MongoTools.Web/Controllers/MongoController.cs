using Microsoft.AspNetCore.Mvc;
using MongoTools.Core.Models;

namespace MongoTools.Web.Controllers
{
    [Route("api/[controller]")]
    public class MongoController : Controller
    {

        public void DumpDatabase()
        {
            
        }

        [HttpGet]
        public string DoImport()
        {
            var processParameter = ProcessParameters.MongoDump;
            var wrapper= new ProcessWrapper(processParameter);
            wrapper.StartAndWait();
            return wrapper.GetText();
        }
    }
}