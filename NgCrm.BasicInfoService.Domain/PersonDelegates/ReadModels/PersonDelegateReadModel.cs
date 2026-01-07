using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.ReadModels
{
    public class PersonDelegateReadModel : ReadModel
    {
        public long AssignerPersonId { get; set; }
        public long AssignerPositionId { get; set; }
        public long DelegatePersonId { get; set; }
        public long CreatePersonId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DelegateReasonTypes ReasonTypeId { get; set; }
        public DelegateStatusTypes StatusTypeId { get; set; }

        public string Description { get; set; }

        public virtual PersonReadModel AssignerPerson { get; set; }
        public virtual PositionReadModel AssignerPosition { get; set; }
        public virtual PersonReadModel DelegatePerson { get; set; }
        public virtual PersonReadModel CreatePerson { get; set; }
    }
}