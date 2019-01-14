using System.Web;
using System.Web.Mvc;

namespace SAEC.MVC.Controllers
{
    public class BaseController : Controller
    {
        //public bool DeveLogar { get; set; } = true;
        ////public Usuario UsuarioLogado { get; set; }

        public const string UsuarioLogado = "UsuarioLogado";

        //public BaseController()
        //{
        //    if (DeveLogar && UsuarioLogado == null)
        //        Response.Redirect("/Login");
        //}


        ////public Usuario UsuarioLogado
        ////{
        ////    get
        ////    {
        ////        if (HttpContext.Items[UsuarioLogadoHttp] == null)
        ////            HttpContext.Items[UsuarioLogadoHttp] = new Usuario();
        ////        return HttpContext.Items[UsuarioLogadoHttp] as Usuario;
        ////    }
        ////}


        //public Usuario UsuarioLogado => (Usuario)TempData["UsuarioLogadoHttp"];

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