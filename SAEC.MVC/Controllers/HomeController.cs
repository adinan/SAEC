using System.Web.Mvc;
using SAEC.Dominio.Interfaces.Servicos;

namespace SAEC.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUsuarioServico _usuarioServico;

        public HomeController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public ActionResult Index()
        {
            /*var novoUsuario = new Usuario("Adinan", "02610393180", 1, "67981611046", 1, "froidy@gmail.com", "1123456");
            _usuarioServico.AddOrUpdate(novoUsuario);

            var possuiAcesso = _usuarioServico.Autenticar(novoUsuario);

            
            //_usuarioServico.SalvarAlteracoes();*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}