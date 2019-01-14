using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

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
        Feminino = 2
    }

    public static class Enum
    {

        /// <summary>
        /// Retorna a descrição da opção selecionada no enum.
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pEnum"></param>
        /// <returns></returns>
        public static string GetDescription(int pValue, Type pEnum)
        {
            try
            {
                string name = System.Enum.GetName(pEnum, pValue);
                DisplayAttribute displayAttr = (DisplayAttribute)pEnum.GetField(name).GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
                if (displayAttr != null)
                    name = displayAttr.Name;
                return name;
            }
            catch
            {
                return "Erro";
            }
        }
    }
}
