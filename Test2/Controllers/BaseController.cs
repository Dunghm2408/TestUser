using Test2.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Test2.Constant;

namespace Test2.Controllers
{
    [AuthenticationFilter]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
        }

        protected string GetUserName()
        {
            return HttpContext.Session.GetString(SessionKey.User.UserFullName);
        }
    }
}

