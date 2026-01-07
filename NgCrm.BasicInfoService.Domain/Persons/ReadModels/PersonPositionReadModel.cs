using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Persons.ReadModels
{
    public class PersonPositionReadModel : ReadModel
    {
        public long PersonId { get; set; }
        public long PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InternalNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual PositionReadModel Position { get; set; }
        public virtual ICollection<PersonPositionPermissionReadModel> PersonPositionPermissions { get; set; } = new List<PersonPositionPermissionReadModel>();
    }
}

