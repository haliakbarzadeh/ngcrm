using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Organizations.Enums
{
    public enum OrganizationTypes
    {
        [Description("درون سازمانی")]
        IntraOrganization = 1,

        [Description("داخلی شرکت")]
        CompanyInternal = 2,

        [Description("شریکان تجاری")]
        BusinessPartners = 3
    }
}
