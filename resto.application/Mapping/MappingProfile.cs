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
            CreateMap<CreateProduitRequestDto, Produit>();
            CreateMap<Produit, GetProduitResponseDto>();

            // this will create Commande from CreateCommandeRequestDto
            CreateMap<CreateCommandeRequestDto, Commande>()
            .ForMember(dest => dest.DateCommande, opt => opt.MapFrom(src => System.DateTime.UtcNow));

            // this will create CreateCommandeResponseDto from Commande
            CreateMap<Commande, CreateCommandeResponseDto>();

            CreateMap<Commande, GetCommandeResponseDto>();

        }
    }
}
