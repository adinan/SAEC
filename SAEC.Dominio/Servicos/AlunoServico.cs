using SAEC.Dominio.Entidades;
using SAEC.Dominio.Interfaces.Repositorios;
using SAEC.Dominio.Interfaces.Servicos;

namespace SAEC.Dominio.Servicos
{
    public class AlunoServico : ServicoBase<Aluno>, IAlunoServico
    {
        public AlunoServico(IAlunoRepositorio alunoRepositorio) : base(alunoRepositorio)
        {
        }
    }
}
