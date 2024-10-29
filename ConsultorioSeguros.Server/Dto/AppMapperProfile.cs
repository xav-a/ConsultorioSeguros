using AutoMapper;
using ConsultorioSeguros.Server.Entities;

namespace ConsultorioSeguros.Server.Dto
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<InsurancePlanInputDto, InsurancePlan>();
            CreateMap<ClientInputDto, Client>();

            CreateMap<InsurancePlan, InsurancePlanDto>();
            CreateMap<Client, ClientDto>()
                .ForMember(c => c.InsurancePlans, opt => opt.MapFrom(src => src.InsurancePlans));

            CreateMap<InsurancePolicy, InsurancePolicyDto>();
        }
    }
}
