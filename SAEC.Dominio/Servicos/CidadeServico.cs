using SAEC.Dominio.Entidades;
using SAEC.Dominio.Interfaces.Repositorios;
using SAEC.Dominio.Interfaces.Servicos;

namespace SAEC.Dominio.Servicos
{
    public class CidadeServico : ServicoBase<Cidade>, ICidadeServico
    {
        public CidadeServico(ICidadeRepositorio cidadeRepositorio) : base(cidadeRepositorio)
        {
        }
    }
}
