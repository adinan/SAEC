using AutoMapper;
using SAEC.Dominio.Entidades;

namespace SAEC.MVC.ViewModels.Profiles
{
    //CreateMap<Fonte,Destino>()
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>()
                .ConstructUsing(u => new Usuario(u.Nome, u.Cpf, u.Sexo, u.Telefone, u.CidadeId, u.Email, u.Senha));
                //.ConstructUsing(u => new Usuario(u.Nome, u.Cpf, u.Sexo));


            CreateMap<Usuario, UsuarioLogadoViewModel>().ReverseMap();
        }
    }
}