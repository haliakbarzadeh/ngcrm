using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Persons.Enums
{
    public enum ContractTypes
    {
        [Description("دائم")]
        Permanent = 1,

        [Description("موقت")]
        Temporary = 2 
    }
}
