using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Roles.ReadModels
{
    public class RoleReadModel : ReadModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
