using DempAPI.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DempAPI.Controllers
{

    public class MyActionFilter : Attribute, IActionFilter
    {
        public string id { get; set; }
        public MyActionFilter(string n)
        {
            id = n;
        }
        public bool AllowMultiple => true;

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            var actName = actionContext.ActionDescriptor.ActionName;

            Trace.WriteLine($"{id} Before execution of {actName}");
            logs.filewrite.WriteLine(DateAndTime.Now);
            logs.filewrite.WriteLine(id + " Before execution of " + actName);
            if (logs.filewrite != null)
            {
                logs.filewrite.Close();
                logs.filewrite = null;
            }

            var result = continuation();
            result.Wait();

            Trace.WriteLine($"{id} After execution of {actName}");
            logs.filewrite.WriteLine(DateAndTime.Now);
            logs.filewrite.WriteLine(id + " After execution of " + actName);
            if (logs.filewrite != null)
            {
                logs.filewrite.Close();
                logs.filewrite = null;
            }

            return result;
        }
    }

    // option extend ActionFilterAttribute class
    public class MyActionFilter2 : ActionFilterAttribute
    {
        public string id { get; set; }
        public MyActionFilter2(string n)
        {
            id = n;
        }

        // before 
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actName =actionContext.ActionDescriptor.ActionName;
            Trace.WriteLine($"{id} Before execution of {actName}");
            logs.filewrite.WriteLine(DateAndTime.Now);
            logs.filewrite.WriteLine(id +" Before execution of " + actName);
            if (logs.filewrite != null)
            {
                logs.filewrite.Close();
                logs.filewrite = null;
            }
        }

        // after 
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var actName =actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            Trace.WriteLine($"{id} After execution of {actName}");
            logs.filewrite.WriteLine(DateAndTime.Now);
            logs.filewrite.WriteLine(id + " After execution of " + actName);
            if (logs.filewrite != null)
            {
                logs.filewrite.Close();
                logs.filewrite = null;
            }
        }
    }

    /// <summary>
    /// Below API's are to check the demonstration of Filters.
    /// </summary>

    [MyActionFilter("filter at controller level")]
    public class ActionFiltersController : ApiController
    {

        /// <summary>
        /// Get API_1 binded to the filter 1
        /// </summary>
        /// <returns></returns>
        [MyActionFilter("filter 1")]
        [Route("api/af/get")]
        public string Get()
        {
            logs.filewrite.WriteLine(DateAndTime.Now);
            logs.filewrite.WriteLine("Inside action method get...");
            logs.filewrite.WriteLine("Action Get from Action Filters Controller");
            Trace.WriteLine("Inside action method get...");
            return "Action Get from Action Filters Controller";
            if (logs.filewrite != null)
            {
                logs.filewrite.Close();
                logs.filewrite = null;
            }
        }

        /// <summary>
        /// Get API_2 binded to the filter 2
        /// </summary>
        /// <returns></returns>
       // [OverrideActionFilters]
       // Above line will disable the Filters at Controller level and Global scopes.
        [MyActionFilter2("filter 2")]
        [Route("api/af/get2")]
        public string Get2()
        {
            logs.filewrite.WriteLine(DateAndTime.Now);
            logs.filewrite.WriteLine("Inside action method get2...");
            logs.filewrite.WriteLine("Action Get2 from Action Filters Controller");
            Trace.WriteLine("Inside action method get2...");
            return "Action Get2 from Action Filters Controller";
            if (logs.filewrite != null)
            {
                logs.filewrite.Close();
                logs.filewrite = null;
            }
        }
    }
}
