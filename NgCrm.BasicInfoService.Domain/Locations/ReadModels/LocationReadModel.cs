using Goldiran.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace NgCrm.BasicInfoService.Domain.Locations.ReadModels
{
    public class LocationReadModel : ReadModel
    {
        public int LocationTypeId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public int? SortOrder { get; set; }
        public long? ParentId { get; set; }
        public HierarchyId Hierarchy { get; set; }

        public string Geometry { get; set; }
    }
}