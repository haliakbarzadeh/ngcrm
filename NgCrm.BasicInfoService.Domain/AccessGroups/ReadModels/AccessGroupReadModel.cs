using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels
{
    public class AccessGroupReadModel : ReadModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
    }
}
