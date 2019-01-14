using System;

namespace SAEC.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
