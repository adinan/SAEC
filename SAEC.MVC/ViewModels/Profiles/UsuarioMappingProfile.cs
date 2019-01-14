using AutoMapper;
using SAEC.Dominio.Entidades;

namespace SAEC.MVC.ViewModels.Profiles
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>()
                .ConstructUsing(u => new Usuario(u.Nome, u.Cpf, (int)u.Sexo, u.Telefone, u.Cidade.Id, u.Email, u.Senha))
                //.ConstructUsing(s => new RestrictedName(s.Name))

                .ReverseMap();
            CreateMap<Usuario, UsuarioLogadoViewModel>().ReverseMap();
        }
    }
}