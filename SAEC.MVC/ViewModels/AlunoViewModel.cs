using System;

namespace SAEC.MVC.ViewModels
{
    public class AlunoViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Sexo { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cidade { get; set; }
    }
}