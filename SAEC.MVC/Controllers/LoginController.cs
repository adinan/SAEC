using System;
using System.Collections.Generic;
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
                TempData["MensagensErro"] = "Senha ou Usuário inválido";
                return View();
            }
            catch(Exception ex)
            {
                TempData["MensagensErro"] = ex.Message;
                return View();
            }
        }

        public ActionResult Create()
        {
            PopularDropDownCidade();

            return View();
        }


        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                PopularDropDownCidade();

                if (ModelState.IsValid)
                {
                    var usuario = Mapper.Map<Usuario>(usuarioViewModel);
                    _usuarioServico.Adicionar(usuario);

                    _usuarioServico.SalvarAlteracoes();
                    TempData["MensagensSucesso"] = "Usuário registrado com Sucesso!";

                    return RedirectToAction("Index");

                }
                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                TempData["MensagensErro"] = ex.Message;

                return View(usuarioViewModel);
            }
        }


        public ActionResult Logout()
        {
            Session.Clear();
            TempData.Clear();
            return RedirectToAction("Index");
        }

        private void PopularDropDownCidade()
        {
            ViewData["CidadeId"] = _cidadeServico.ObterTodos().OrderBy(p => p.Nome)
                .Select(c => new SelectListItem
                {
                    Text = c.Nome,
                    Value = c.Id.ToString()
                }).ToList();
        }

    }
}