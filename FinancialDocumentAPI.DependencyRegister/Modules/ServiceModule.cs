using Microsoft.Extensions.DependencyInjection;
using FinancialDocumentAPI.Application.Interfaces;
using FinancialDocumentAPI.Application.Service;
using FinancialDocumentAPI.Domain.IRepositories;
using FinancialDocumentAPI.Infrastructure.Repositories;

namespace FinancialDocumentAPI.DependencyRegister.Modules;

public static class ServiceModule
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Register repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ITenantRepository, TenantRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IFinancialDocumentRepository, FinancialDocumentRepository>();
        
        // Register use cases
        services.AddScoped<IValidateRequestService, ValidateRequestService>();
        services.AddScoped<IRetrieveFinancialDocumentService, RetrieveFinancialDocumentService>();
        services.AddScoped<IAnonymizeFinancialDocumentService, AnonymizeFinancialDocumentService>();
    }
}