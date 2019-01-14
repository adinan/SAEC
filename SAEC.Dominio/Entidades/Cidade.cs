using System.Collections.Generic;

namespace SAEC.Dominio.Entidades
{
    public class Cidade : EntidadeBase
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}
