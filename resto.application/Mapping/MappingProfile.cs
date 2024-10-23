using AutoMapper;
using resto.application.Dtos.Responses;
using resto.application.Dtos.Requests;
using resto.domain.Entities;

namespace resto.application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // this will create Commande from CreateCommandeRequestDto
            CreateMap<CreateCommandeRequestDto, Commande>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.DateCommande, opt => opt.MapFrom(src => System.DateTime.UtcNow));

            // this will create CreateCommandeResponseDto from Commande
            CreateMap<Commande, CreateCommandeResponseDto>();

            CreateMap<Commande, GetAllCommandesResponseDto>();

        }
    }
}
