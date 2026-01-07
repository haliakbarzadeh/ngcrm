using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Entities
{
    [Auditable]
    public class AccessGroup : AggregateRoot
    {
        public AccessGroup(string title, string name, bool? isActive, string description)
        {
            Title = title;
            Name = name;
            IsActive = isActive;
            Description = description;
        }

        public void Update(string title, string name, bool? isActive, string description)
        {
            Title = title;
            Name = name;
            IsActive = isActive;
            Description = description;
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public bool? IsActive { get; private set; }
        public string Description { get; private set; }

    }
}
