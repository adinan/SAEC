using System.Web.Mvc;
using SAEC.Dominio.Interfaces.Servicos;

namespace SAEC.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}