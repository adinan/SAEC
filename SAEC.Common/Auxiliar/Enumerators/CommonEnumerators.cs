using System.ComponentModel.DataAnnotations;

namespace SAEC.Common.Auxiliar.Enumerators
{
    public enum EDiaSemana
    {
        [Display(Name = "Domingo")]
        Domingo = 1,

        [Display(Name = "Segunda-feira")]
        Segunda = 2,

        [Display(Name = "Terça-feira")]
        Terca = 3,

        [Display(Name = "Quarta-feira")]
        Quarta = 4,

        [Display(Name = "Quinta-feira")]
        Quinta = 5,

        [Display(Name = "Sexta-feira")]
        Sexta = 6,

        [Display(Name = "Sábado")]
        Sabado = 7
    }

    public enum ESexo
    {
        [Display(Name = "Masculino")]
        Masculino = 1,

        [Display(Name = "Feminino")]
        Feminino11 = 2
    }
}
