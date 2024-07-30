using AutoMapper;
using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Domain.Entities;

namespace FinancialDocumentAPI.DependencyRegister.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<FinancialDocumentDto, FinancialDocument>().ReverseMap();
        CreateMap<TransactionDto, Transaction>().ReverseMap();
        CreateMap<ClientDto, Client>().ReverseMap();
        CreateMap<CompanyInfoDto, Client>().ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.RegistrationNumber))
                                           .ForMember(dest => dest.CompanyType, opt => opt.MapFrom(src => src.CompanyType))
                                           .ReverseMap();
    }
}
