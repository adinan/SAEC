using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using Newtonsoft.Json;
using SAEC.Dominio.Interfaces.Servicos;
using SAEC.MVC.Util;
using SAEC.MVC.ViewModels;

namespace SAEC.MVC.Controllers
{
    public class AlunoController : BaseController
    {
        private readonly IAlunoServico _alunoService;

        public AlunoController(IAlunoServico alunoService)
        {
            _alunoService = alunoService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int alunoId)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int alunoId)
        {
            throw new NotImplementedException();
        }

        public string Grid(BootGridRequest bootgridRequest)
        {
            BootGridResponse bootGridResponse = new BootGridResponse();
            var alunos = _alunoService.ObterTodos();

            bootGridResponse.current = bootgridRequest.current;
            bootGridResponse.rowCount = bootgridRequest.rowCount;

            if (!String.IsNullOrEmpty(bootgridRequest.searchphrase))
            {
                alunos = alunos.Where(a =>
                a.Nome.Contains(bootgridRequest.searchphrase) ||
                a.Cpf.Contains(bootgridRequest.searchphrase) ||
                a.Telefone.Contains(bootgridRequest.searchphrase));
            }

            if (bootgridRequest.sort != null && bootgridRequest.sort.Any())
            {
                switch (bootgridRequest.sort.First().Key)
                {
                    case "Codigo":
                        alunos = alunos.OrderBy("Id" + " " + bootgridRequest.sort.First().Value);
                        break;
                    case "Nome":
                        alunos = alunos.OrderBy("Nome" + " " + bootgridRequest.sort.First().Value);
                        break;
                    case "Cpf":
                        alunos = alunos.OrderBy("Cpf" + " " + bootgridRequest.sort.First().Value);
                        break;
                    case "Telefone":
                        alunos = alunos.OrderBy("Telefone" + " " + bootgridRequest.sort.First().Value);
                        break;
                }
            }
            else
                alunos = alunos.OrderBy(c => c.Id);


            var filtrado = alunos.ToList();

            var sqv = filtrado.Skip((bootgridRequest.current - 1) * bootgridRequest.rowCount)
                .Take(bootgridRequest.rowCount).Select(AutoMapper.Mapper.Map<GridAlunoViewModel>).ToList();

            bootGridResponse.rows = sqv;
            bootGridResponse.total = filtrado.Count;
            return JsonConvert.SerializeObject(bootGridResponse);
        }
    }
}