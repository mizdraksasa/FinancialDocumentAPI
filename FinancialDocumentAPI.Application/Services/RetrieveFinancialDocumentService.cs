using AutoMapper;
using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Application.Interfaces;
using FinancialDocumentAPI.Domain.IRepositories;

namespace FinancialDocumentAPI.Application.Service;

public class RetrieveFinancialDocumentService : IRetrieveFinancialDocumentService
{
    private readonly IFinancialDocumentRepository _financialDocumentRepository;
    private readonly IMapper _mapper;
    
    public RetrieveFinancialDocumentService(IFinancialDocumentRepository financialDocumentRepository, IMapper mapper)
    {
        _financialDocumentRepository = financialDocumentRepository;
        _mapper = mapper;
    }
    
    public async Task<FinancialDocumentDto> RetrieveAsync(Guid tenantId, Guid documentId, string productCode)
    {
        var document = await _financialDocumentRepository.GetFinancialDocumentAsync(tenantId, documentId, productCode);
        return _mapper.Map<FinancialDocumentDto>(document);
    }
}