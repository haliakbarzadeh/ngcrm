using Goldiran.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;

namespace NgCrm.BasicInfoService.Domain.Organizations.Entities
{
    public class Organization : AggregateRoot
    {
        public Organization(string title, string name, long? parentId, OrganizationTypes organizationTypeId, int? code, string address, bool isActive)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            OrganizationTypeId = organizationTypeId;
            Code = code;
            Address = address;
            IsActive = isActive;

            //AddEvent(new OrganizationCreatedEvent(BusinessId, title, name, parentId, organizationTypeId, code, address, CreatedAt));
        }

        public void Update(string title, OrganizationTypes organizationTypeId, string name, int? code, string address, bool isActive)
        {
            Title = title;
            Name = name;
            Code = code;
            Address = address;
            IsActive = isActive;
            OrganizationTypeId = organizationTypeId;

            ModifiedAt = DateTime.Now;
        }


        public string Title { get; private set; }
        public string Name { get; private set; }
        public long? ParentId { get; private set; }
        public OrganizationTypes OrganizationTypeId { get; private set; }
        public int? Code { get; private set; }
        public string Address { get; private set; }
        public bool IsActive { get; private set; }

        public HierarchyId? Hierarchy { get; private set; }

        //public virtual ICollection<Organization> InverseParent { get; private set; } = new List<Organization>();

        public virtual Organization Parent { get; private set; }

        //public virtual ICollection<Position> Positions { get; private set; } = new List<Position>();

    }
}
