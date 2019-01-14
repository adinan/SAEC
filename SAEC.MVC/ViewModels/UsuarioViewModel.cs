using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SAEC.Common.Auxiliar.Enumerators;
using SAEC.Dominio.Entidades;
using SAEC.MVC.ViewModels.Validacoes;

namespace SAEC.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(Usuario.NomeMaxLength, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(Usuario.NomeMinLength, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }

        
        [Required(ErrorMessage = "Preencha o campo Cpf")]
        [CustomValidationCpf(ErrorMessage = "CPF inválido")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sexo")]
        public ESexo Sexo { get; set; }

        [Required(ErrorMessage = "Preencha o campo tel")]
        //MascaraTelefone
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        public Cidade Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(Usuario.EnderecoMaxLength, ErrorMessage = "Máximo {1} caracteres"),]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        public string Senha { get; set; }

    }


}