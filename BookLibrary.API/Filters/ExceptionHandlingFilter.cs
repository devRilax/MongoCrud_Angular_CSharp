using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;


namespace BookLibrary.API.Filters
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public ExceptionHandlingFilter() : base() { }


        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.Exception.Message);
        }

    }
}