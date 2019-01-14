using System;

namespace SAEC.Dominio.Entidades
{
    public class ResponsavelAluno : EntidadeBase
    {
        public int TipoResponsavel { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Profissao { get; set; }
        public string Celular { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public int UsuarioIdAlteracao { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }
    }
}
