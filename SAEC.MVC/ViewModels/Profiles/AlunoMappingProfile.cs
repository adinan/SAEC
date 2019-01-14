using SAEC.Dominio.Entidades;
using AutoMapper;

namespace SAEC.MVC.ViewModels.Profiles
{
    public class AlunoMappingProfile : Profile
    {
        public AlunoMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();

            CreateMap<Aluno, GridAlunoViewModel>()
                .ForMember(dest => dest.DataCadastro, opts => opts.MapFrom(src => src.DataCadastro.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.Cidade, opts => opts.MapFrom(src => src.Cidade.Nome))
                .ReverseMap();
            //.ForMember(dest => dest.DataFimAtual, opts => opts.MapFrom(src => src.FaseDAI.LastOrDefault(f => f.Status == (int)EStatus.Ativo).DataFim != null ? src.FaseDAI.LastOrDefault(f => f.Status == (int)EStatus.Ativo).DataFim.Value.ToString("yyyy-MM-dd") : ""))
            
        }
    }
}