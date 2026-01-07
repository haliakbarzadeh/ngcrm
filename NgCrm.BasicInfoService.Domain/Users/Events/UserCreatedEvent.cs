using Goldiran.Framework.Domain.Events;

namespace NgCrm.BasicInfoService.Domain.Users.Events
{
    public class UserCreatedEvent : CreatedDomainEvent
    {
        public UserCreatedEvent(Guid businessId)
          : base(businessId, DateTime.Now)
        {

        }
    }
}
