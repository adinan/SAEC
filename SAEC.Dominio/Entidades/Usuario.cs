using SAEC.Common;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using SAEC.Common.Auxiliar.Enumerators;


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
        
        public ESexo Sexo { get; private set; }
        public string Telefone { get; private set; }

        public const int TamnhoSenhaMinima = 4;
        public string Senha { get; private set; }

        public int CidadeId { get; private set ; }

        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<ResponsavelAluno> ResponsavelAluno { get; set; }

        //utilizada pelo EF
        protected Usuario()
        {

        }

        public Usuario(string nome, string cpf, ESexo sexo, string telefone, int cidade, string email, string senha)
        {
            SetNome(nome);
            SetCpf(cpf);
            SetSexo(sexo);
            SetTel(telefone);
            SetCidade(cidade);
            SetEmail(email);
            SetSenha(senha);
        }

        private void SetTel(string telefone)
        {
            if (!telefone.IsNullOrWhiteSpace())
                Telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "");
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
            nome = nome.Trim();
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
                Cpf = cpf.Replace(".", "").Replace("-", "");
            else
                throw new Exception("Cpf inválido");
        }

        private void SetSexo(ESexo sexo)
        {
            if (sexo > 0)
                Sexo = sexo;
            else
                throw new Exception("Selecione o Sexo");
        }

        private void SetCidade(int cidade)
        {
            if (cidade > 0)
                CidadeId = cidade;
            else
                throw new Exception("Selecione a Cidade");
        }

        private void SetSenha(string senha)
        {
            if (senha.Length > 4)
                Senha = CriptografaSenha(senha);
            else
                throw new Exception("Senha deve ter no minio 4 caracteres");
        }

        private string CriptografaSenha(string senha)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);

            var hash = pbkdf2.GetBytes(20);
            var hashbytes = new byte[36];

            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);

            return Convert.ToBase64String(hashbytes);
        }

    }
}