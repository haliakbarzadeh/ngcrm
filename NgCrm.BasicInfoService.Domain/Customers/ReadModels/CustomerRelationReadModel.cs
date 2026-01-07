using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Customers.ReadModels
{
    public class CustomerRelationReadModel : ReadModel
    {
        public long CustomerId { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string NationalCode { get;  set; }
        public string? MobileNumber { get;  set; }
        public string? FixNumber { get;  set; }
        public long RelationTitleId { get;  set; }
        public BaseInfoReadModel RelationTitle { get; set; }
        public CustomerReadModel Customer { get; set; }

    }
}
