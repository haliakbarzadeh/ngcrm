using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.Domain.PersonAccessGroups.ReadModels
{
    public class PersonAccessGroupReadModel : ReadModel
    {
        public long PersonId { get; set; }
        public long AccessGroupId { get; set; }


        public PersonReadModel Person { get; set; }
        public AccessGroupReadModel AccessGroup { get; set; }
    }
}