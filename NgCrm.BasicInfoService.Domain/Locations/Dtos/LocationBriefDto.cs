using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Locations.Enums;

namespace NgCrm.BasicInfoService.Domain.Locations.Dtos
{
    public class LocationBriefDto : Dto
    {
        public long Id { get; set; }
        public LocationTypes LocationTypeId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public int? SortOrder { get; set; }
        public string Geometry { get; set; }
        public long? ParentId { get; set; }

        public long? OriginalId { get; set; }
    }
}
