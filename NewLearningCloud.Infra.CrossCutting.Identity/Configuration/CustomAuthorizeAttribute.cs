using System.Web.Mvc;

namespace NewLearningCloud.Infra.CrossCutting.Identity.Configuration
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //    filterContext.Result = new HttpStatusCodeResult(403);
            //else
            //    filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
