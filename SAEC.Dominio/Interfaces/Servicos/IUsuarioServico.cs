using System;
using System.Collections.Generic;
using SAEC.Dominio.Entidades;

namespace SAEC.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico : IServicoBase<Usuario>
    {
        Usuario Autenticar(string cpf, string senha);
        Usuario ObterPorCpf(string cpf);
        void Adicionar(Usuario usuario);
    }
}
