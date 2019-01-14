using SAEC.Common;
using System;
using System.Collections.Generic;


namespace SAEC.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public const int NomeMinLength = 4;
        public const int NomeMaxLength = 100;
        public string Nome { get; private set; }
        
        public const int CpfMaxLength = 12; 
        public string Cpf { get; private set; }

        public const int EnderecoMaxLength = 254;
        public string Email { get; private set; }


        public int Sexo { get; private set; }
        public string Telefone { get; private set; }
        public int Cidade { get; private set; }
        public string Senha { get; private set; }
        public virtual ICollection<ResponsavelAluno> ResponsavelAluno { get; set; }

        //utilizada pelo EF
        //protected Usuario()
        //{
            
        //}

        public Usuario(string nome, string cpf, int sexo, string tel, int cidade, string email, string senha)
        {
            SetNome(nome);
            SetCpf(cpf);
            SetSexo(sexo);
            SetTel(tel);
            SetCidade(cidade);
            SetEmail(email);
            SetSenha(senha);
        }

        private void SetTel(string tel)
        {
            if (!tel.IsNullOrWhiteSpace())
                Telefone = tel;
            else
                throw new Exception("Telefone inválido");
        }

        private void SetEmail(string email)
        {
            if (!email.IsNullOrWhiteSpace())
                Email = email;
            else
                throw new Exception("Email inválido");
        }

        private void SetNome(string nome)
        {
            if (nome.IsNullOrWhiteSpace())
                throw new Exception("Nome inválido.");
            if (nome.Length < NomeMinLength)
                throw new Exception("Nome muito curto.");
            if (nome.Length > NomeMaxLength)
                throw new Exception("Nome muito longo.");

            Nome = nome;
        }

        private void SetCpf(string cpf)
        {
            if (!cpf.IsNullOrWhiteSpace())
                Cpf = cpf;
            else
                throw new Exception("Cpf inválido");
        }

        private void SetSexo(int sexo)
        {
            if (sexo > 0)
                Sexo = sexo;
            else
                throw new Exception("Selecione o Sexo");
        }

        private void SetCidade(int cidade)
        {
            if (cidade > 0)
                Cidade = cidade;
            else
                throw new Exception("Selecione a Cidade");
        }

        private void SetSenha(string senha)
        {
            if (senha.Length > 4)
                Senha = senha;
            else
                throw new Exception("Senha deve ter no minio 4 caracteres");
        }

    }
}