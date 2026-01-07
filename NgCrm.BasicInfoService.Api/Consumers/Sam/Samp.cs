using Goldiran.Framework.Integration.MessageBus;
using NgCrm.BasicInfoService.Integration.Roles;

namespace NgCrm.BasicInfoService.Api.Consumers.Sam
{
    public class RoleCreatedHandler2 : IMessageHander<RoleCreatedMessage>
    {
        public async Task HandleAsync(RoleCreatedMessage message, CancellationToken cancellationToken)
        {
            Console.WriteLine("Handle2:   " + message.BusinessId);
            // Console.WriteLine(context.Message.BusinessId);
            //Thread.Sleep(2000);
        }
    }

}
