using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Customers.Dtos
{
    public class CustomerRelationDto : Dto
    {
        public long Id { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string NationalCode { get;  set; }
        public string? MobileNumber { get;  set; }
        public string? FixNumber { get;  set; }
        public long RelationTitleId { get; set; }
        public string RelationTitle { get; set; }

    }
}
