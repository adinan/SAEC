using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using SAEC.Dominio.Entidades;
using SAEC.Dominio.Interfaces.Repositorios;
using SAEC.Dominio.Interfaces.Servicos;

namespace SAEC.Dominio.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio) : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        

        public Usuario Autenticar(string cpf, string senha)
        {
            var usuario = _usuarioRepositorio.ObterPorCpf(cpf);
            if (usuario == null)
                return null;

            var hashSaltBanco = Convert.FromBase64String(usuario.Senha);

            var saltBanco = new byte[16];
            var hashBanco = new byte[20];

            Array.Copy(hashSaltBanco, 0, saltBanco, 0, 16);
            Array.Copy(hashSaltBanco, 16, hashBanco, 0, 20);
            
            var pbkdf2 = new Rfc2898DeriveBytes(senha, saltBanco, 10000);
            var hash = pbkdf2.GetBytes(20);

            return !hash.SequenceEqual(hashBanco) ? null : usuario;
        }

        public Usuario ObterPorCpf(string cpf)
        {
            return _usuarioRepositorio.ObterPorCpf(cpf);
        }

        public void Adicionar(Usuario usuario)
        {
            _usuarioRepositorio.ObterPorCpf(usuario.Cpf);
            if(_usuarioRepositorio.ObterPorCpf(usuario.Cpf) != null)
                throw new Exception("Cpf ja cadastrado");
            _usuarioRepositorio.AddOrUpdate(usuario);
        }

        
    }
}
