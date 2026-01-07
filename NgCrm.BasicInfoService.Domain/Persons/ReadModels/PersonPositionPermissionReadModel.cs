using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Persons.ReadModels
{
    public class PersonPositionPermissionReadModel : ReadModel
    {
        public long PersonPositionId { get; set; }
        public long PermissionId { get; set; }
        public bool IsAllow { get; set; }
    }
}

