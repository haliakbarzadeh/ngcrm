using Goldiran.Framework.Integration.MessageBus;
using NgCrm.BasicInfoService.Integration.Roles;

namespace NgCrm.BasicInfoService.Api.Consumers.Roles
{
    public class RoleCreatedHandler : IMessageHander<RoleCreatedMessage>
    {
        public async Task HandleAsync(RoleCreatedMessage message, CancellationToken cancellationToken)
        {
            Console.WriteLine("Handle:   " + message.BusinessId);
            // Console.WriteLine(context.Message.BusinessId);
            Thread.Sleep(100);
        }
    }
}
