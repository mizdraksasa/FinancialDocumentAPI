using System.ComponentModel;

namespace FinancialDocumentAPI.Domain;

public enum eCompanyType
{
    [Description("Small")]
    Small = 1,

    [Description("Medium")]
    Medium = 2
}
