using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Locations.Enums;

namespace NgCrm.BasicInfoService.Domain.Locations.Entities
{
    public class Location : AggregateRoot
    {

        public Location(LocationTypes locationTypeId, long? parentId, string title, string name, string phoneCode, int? sortOrder, string geometry, long? originalId)
        {
            LocationTypeId = locationTypeId;
            ParentId = parentId;
            Title = title;
            Name = name;
            PhoneCode = phoneCode;
            SortOrder = sortOrder;
            Geometry = geometry;
            OriginalId = originalId;

        }


        public void Update(LocationTypes locationTypeId, long? parentId, string title, string name, string phoneCode, int? sortOrder, string geometry, long? originalId)
        {
            LocationTypeId = locationTypeId;
            ParentId = parentId;
            Title = title;
            Name = name;
            PhoneCode = phoneCode;
            SortOrder = sortOrder;
            Geometry = geometry;
            OriginalId = originalId;
            ModifiedAt = DateTime.Now;

        }


        public LocationTypes LocationTypeId { get; private set; }
        public string Title { get; private set; }
        public string Name { get; private set; }
        public string PhoneCode { get; private set; }
        public int? SortOrder { get; private set; }
        public string Geometry { get; private set; }
        public long? ParentId { get; set; }

        public long? OriginalId { get; set; }
    }
}