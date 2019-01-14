using System.Web;
using System.Web.Mvc;

namespace SAEC.MVC.Controllers
{
    public class BaseController : Controller
    {
        public const string UsuarioLogado = "UsuarioLogado";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            if (controller != null)
            {
                if (session[UsuarioLogado] == null)
                    controller.HttpContext.Response.Redirect("/Login/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}