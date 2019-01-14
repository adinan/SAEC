using System;

namespace SAEC.MVC.ViewModels
{
    [Serializable]
    public class UsuarioLogadoViewModel
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Cpf { get; set; }
    }
}