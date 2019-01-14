using SAEC.Dominio.Entidades;
using AutoMapper;
using SAEC.Common.Auxiliar.Enumerators;

namespace SAEC.MVC.ViewModels.Profiles
{
    public class AlunoMappingProfile : Profile
    {
        public AlunoMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();

            CreateMap<Aluno, GridAlunoViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Sexo, opts => opts.MapFrom(src => Enum.GetDescription(src.Sexo, typeof(ESexo))))
                .ForMember(dest => dest.DataCadastro, opts => opts.MapFrom(src => src.DataCadastro.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Cidade, opts => opts.MapFrom(src => src.Cidade.Nome))

                .ReverseMap();
            //.ForMember(dest => dest.DataFimAtual, opts => opts.MapFrom(src => src.FaseDAI.LastOrDefault(f => f.Status == (int)EStatus.Ativo).DataFim != null ? src.FaseDAI.LastOrDefault(f => f.Status == (int)EStatus.Ativo).DataFim.Value.ToString("yyyy-MM-dd") : ""))
            
        }
    }
}