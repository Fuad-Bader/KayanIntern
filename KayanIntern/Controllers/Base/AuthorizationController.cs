using KayanIntern.Provider.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KayanIntern.KayanIntern.Controllers.Base
{
    public class AuthorizationController : Controller
    {
        protected Users CurrentUser { get; set; }

        public AuthorizationController()
        {
            CurrentUser = new Users();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cookie = context.HttpContext.User;

            var currentusertype = CurrentUser.GetType();

            foreach (var property in currentusertype.GetProperties())
            {
                var cookieclaim = cookie.FindFirst(property.Name);
                if (cookieclaim != null)
                {
                    var propertytype = property.PropertyType;
                    var cookieClaimValue = cookieclaim.Value;

                    if (propertytype == typeof(string))
                    {
                        property.SetValue(CurrentUser, cookieClaimValue);
                    }
                }
            }



            //CurrentUser.UserName = cookie.FindFirst(ClaimTypes.Name)?.Value; // use ?.value to get the claim value
            //CurrentUser.Email = cookie.FindFirst(ClaimTypes.Email)?.Value;
            //CurrentUser.Role = cookie.FindFirst(ClaimTypes.Role)?.Value;

            base.OnActionExecuting(context);
        }



        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    // Code to be executed after the action method
        //}
    }
}
