using System.ComponentModel.DataAnnotations;

namespace SAEC.MVC.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Preencha o campo Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        public string Senha { get; set; }
    }
}