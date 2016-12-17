using Warden.Common.Host;
using Warden.Services.Organizations.Framework;
using Warden.Services.Organizations.Shared.Commands;
using Warden.Services.Users.Shared.Events;

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
                .SubscribeToEvent<NewUserSignedIn>()
                .SubscribeToEvent<UserSignedIn>()
                .Build()
                .Run();
        }
    }
}
