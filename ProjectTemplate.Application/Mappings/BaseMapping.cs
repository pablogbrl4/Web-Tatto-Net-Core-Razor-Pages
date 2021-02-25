using AutoMapper;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Application.Mappings
{
    public class BaseMapping : Profile
    {
        public BaseMapping()
        {
            CreateMap<Agenda, AgendaDTO>().ReverseMap();

            CreateMap<Depoimentos, DepoimentosDTO>().ReverseMap();

            CreateMap<Estudio, EstudioDTO>().ReverseMap();

            CreateMap<Estudio_Tatuador, Estudio_TatuadorDTO>().ReverseMap();

            CreateMap<FotosEstudio, FotosEstudioDTO>().ReverseMap();

            CreateMap<FotoTatto, FotoTattoDTO>().ReverseMap();

            CreateMap<HorarioDeFuncionamentoEstudio, HorarioDeFuncionamentoEstudioDTO>().ReverseMap();

            CreateMap<Shopping, ShoppingDTO>().ReverseMap();

            CreateMap<Tatuador, TatuadorDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            CreateMap<Contatos, ContatosDTO>().ReverseMap();
        }
    }
}
