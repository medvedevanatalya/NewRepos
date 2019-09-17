using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2
{
    public class FiltersHelper : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //if(!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
            if (!filterContext.ExceptionHandled && filterContext.Exception is DivideByZeroException)
            {
                //filterContext.Result = new RedirectResult("~/Views/Shared/Error.cshtml");
                //filterContext.ExceptionHandled = true;

                filterContext.Result = ViewResult
                    {
                    ViewName = @"~/ Views / Shared / Error.cshtml";
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}