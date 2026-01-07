using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Departments.Dtos
{
    public class DepartmentBriefDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ParentTitle { get; set; }
        public string ParentName { get; set; }
    }
}