using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Test2.Constant;

namespace Test2.Filters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // The action filter logic.
            Controller controller = filterContext.Controller as Controller;
            var session = filterContext.HttpContext.Session;
            string userFullName = filterContext.HttpContext.Session.GetString(SessionKey.User.UserFullName);
            var sessionStatus = ((userFullName != null && userFullName != "") ? true : false);
            if (controller != null)
            {
                if (session == null || !sessionStatus)
                {
                    filterContext.Result =
                           new RedirectToRouteResult(
                               new RouteValueDictionary{
                                   { "controller", "Admin" },
                                   { "action", "Login" }}
                               );

                }
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}
