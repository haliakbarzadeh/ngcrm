using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Dtos
{
    public class WorkspaceBriefDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public bool IsSystem { get; set; }
        public string Description { get; set; }

    }
}
