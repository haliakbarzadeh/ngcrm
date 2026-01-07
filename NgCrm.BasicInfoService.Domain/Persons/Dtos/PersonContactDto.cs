using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Persons.Dtos
{
    public class PersonContactDto : Dto
    {
        public PersonContactTypes ContactTypeId { get; set; }
        public string Contact { get; set; }
        public bool IsActive { get; set; }
        public int PriorityOrder { get; set; }
    }
}
