using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Departments.ReadModels
{
    public class DepartmentReadModel : ReadModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ParentTitle { get; set; }
        public string ParentName { get; set; }

        //public virtual DepartmentReadModel Parent { get; set; }
        //public virtual ICollection<DepartmentReadModel> Children { get; set; } = new List<DepartmentReadModel>();
    }
}