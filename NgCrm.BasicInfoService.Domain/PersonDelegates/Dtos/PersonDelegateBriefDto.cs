using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Dtos
{
    public class PersonDelegateBriefDto : Dto
    {
        public long Id { get; set; }
        public long AssignerPersonId { get; set; }
        public long AssignerPositionId { get; set; }
        public long DelegatePersonId { get; set; }
        public long CreatePersonId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DelegateReasonTypes ReasonTypeId { get; set; }
        public DelegateStatusTypes StatusTypeId { get; set; }

        // Extras
        public string CreatePersonFullName { get; set; }
        public string AssignerPersonFullName { get; set; }
        public string AssignerPositionTitle { get; set; }
        public string DelegatePersonFullName { get; set; }
        public string ReasonTypeTitle { get; set; }
        public string StatusTypeTitle { get; set; }

    }
}