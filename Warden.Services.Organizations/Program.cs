using Warden.Common.Host;
using Warden.Services.Organizations.Framework;
using Warden.Messages.Commands.Organizations;
using Warden.Messages.Events.Users;

namespace Warden.Services.Organizations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebServiceHost
                .Create<Startup>(port: 5052)
                .UseAutofac(Bootstrapper.LifetimeScope)
                .UseRabbitMq(queueName: typeof(Program).Namespace)
                .SubscribeToCommand<CreateOrganization>()
                .SubscribeToCommand<CreateWarden>()
                .SubscribeToCommand<DeleteWarden>()
                .SubscribeToEvent<SignedIn>()
                .SubscribeToEvent<SignedUp>()
                .Build()
                .Run();
        }
    }
}
