using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Persons.ReadModels
{
    public class PersonContactReadModel : ReadModel
    {
        public long PersonId { get; set; }
        public PersonContactTypes ContactTypeId { get; set; }
        public string Contact { get; set; }
        public bool IsActive { get; set; }
        public int PriorityOrder { get; set; }
    }
}

