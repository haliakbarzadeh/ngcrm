using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Roles.Events;

namespace NgCrm.BasicInfoService.Domain.Roles.Entities
{
    public class Role : AggregateRoot
    {
        public Role(string title, string name, long? parentId)
        {
            Title = title;
            Name = name;
            ParentId = parentId;

            AddEvent(new RoleCreatedEvent(BusinessId, title, name, parentId, CreatedAt));

        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public long? ParentId { get; private set; }
    }


}
