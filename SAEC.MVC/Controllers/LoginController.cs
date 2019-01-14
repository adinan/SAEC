using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SAEC.Dominio.Entidades;
using SAEC.Dominio.Interfaces.Servicos;
using SAEC.MVC.ViewModels;

namespace SAEC.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly ICidadeServico _cidadeServico;

        public LoginController(IUsuarioServico usuarioServico, ICidadeServico cidadeServico)
        {
            _usuarioServico = usuarioServico;
            _cidadeServico = cidadeServico;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioLogado = _usuarioServico.Autenticar(loginViewModel.Cpf, loginViewModel.Senha);

                    if (usuarioLogado != null)
                    {
                        Session[BaseController.UsuarioLogado] = Mapper.Map<Usuario, UsuarioLogadoViewModel>(usuarioLogado);
                        return RedirectToAction("Index", "Home");
                    }

                }

                ViewBag.MensagensErro = "Senha ou usuario invalido";
                return View();
            }
            catch
            {
                ViewBag.MensagensErro = "Erro operacional";
                return View();
            }
        }

        public ActionResult Create()
        {
            ViewBag.Cidades = _cidadeServico.ObterTodos().Select(cidade => new SelectListItem
            {
                Text = cidade.Nome,
                Value = cidade.Id.ToString()
            }).ToList();
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = Mapper.Map<Usuario>(usuarioViewModel);
                    _usuarioServico.Adicionar(usuario);

                    _usuarioServico.SalvarAlteracoes();
                    return RedirectToAction("Index");
                }
                return View(usuarioViewModel);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Logout()
        {

            return RedirectToAction("Index");
        }
    }
}