using AutoMapper;
using resto.application.Dtos;
using resto.domain.Entities;

namespace resto.application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCommandeDto, Commande>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id during creation
                .ForMember(dest => dest.Produit, opt => opt.Ignore()); // The Produit will be handled separately

            CreateMap<Commande, CreateCommandeDto>();
        }
    }
}
