﻿using System.ComponentModel;

namespace SAEC.MVC.ViewModels
{
    public class GridAlunoViewModel
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public string Nome { get; set; }

        [DisplayName("CPF")]
        public string Cpf { get; set; }
        public int Sexo { get; set; }
        public string Telefone { get; set; }

        [DisplayName("Data de Cadastro")]
        public string DataCadastro { get; set; }

        public string Cidade { get; set; }
    }
}