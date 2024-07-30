using FinancialDocumentAPI.Shared.Dto;
using FinancialDocumentAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialDocumentAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialDocumentController : ControllerBase
{
    private readonly IValidateRequestService _validateRequestService;
    private readonly IRetrieveFinancialDocumentService _retrieveFinancialDocumentService;
    private readonly IAnonymizeFinancialDocumentService _anonymizeFinancialDocumentService;
    
    public FinancialDocumentController(
        IValidateRequestService validateRequest,
        IRetrieveFinancialDocumentService retrieveFinancialDocument,
        IAnonymizeFinancialDocumentService anonymizeFinancialDocument)
    {
        _validateRequestService = validateRequest;
        _retrieveFinancialDocumentService= retrieveFinancialDocument;
        _anonymizeFinancialDocumentService = anonymizeFinancialDocument;
    }

    [HttpPost("retrieve")]
    public async Task<IActionResult> RetrieveFinancialDocument([FromBody] RequestModelDto request)
    {
        var validationResult = await _validateRequestService.ValidateAsync(request.ProductCode, request.TenantId, request.DocumentId);
        if (!validationResult.IsValid)
            return StatusCode(403, validationResult.ErrorMessage);
        
        var document = await _retrieveFinancialDocumentService.RetrieveAsync(request.TenantId, request.DocumentId, request.ProductCode);
        var anonymizedDocument = await _anonymizeFinancialDocumentService.AnonymizeAsync(document, request.ProductCode);
        
        return Ok(anonymizedDocument);
    }
}
