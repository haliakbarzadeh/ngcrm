using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Persons.Dtos
{
    public class PersonSummaryDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; } 
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public string PersonalCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
