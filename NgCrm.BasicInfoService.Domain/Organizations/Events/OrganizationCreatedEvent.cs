using Goldiran.Framework.Domain.Events;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;

namespace NgCrm.BasicInfoService.Domain.Organizations.Events
{
    public class OrganizationCreatedEvent : CreatedDomainEvent
    {
        public OrganizationCreatedEvent(
            Guid businessId,
            string title,
            string name,
            long? parentId,
            OrganizationTypes organizationTypeId,
            int? code,
            string address,
            HierarchyId? hierarchy,
            DateTime createdAt
        ) : base(businessId, createdAt)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            OrganizationTypeId = organizationTypeId;
            Code = code;
            Address = address;
            Hierarchy = hierarchy;
        }

        public string Title { get; }
        public string Name { get; }
        public long? ParentId { get; }
        public OrganizationTypes OrganizationTypeId { get; }
        public int? Code { get; }
        public string Address { get; }
        public HierarchyId? Hierarchy { get; }
    }
}
