using System;
using System.Collections.Generic;

namespace SAEC.Dominio.Entidades
{
    public class Aluno : EntidadeBase
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Matricula { get; set; }
        public int Idade { get; set; }
        public int Sexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int ResponsavelId { get; set; }
        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<ResponsavelAluno> ResponsavelAluno { get; set; }
    }
}
