using AutoMapper;
using resto.application.Dtos.Responses;
using resto.domain.Entities;

namespace resto.application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Commande, CreateCommandeResponseDto>()
            .ForMember(dest => dest.Produit, opt => opt.Ignore())
        }
    }
}
