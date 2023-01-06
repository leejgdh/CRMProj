using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using SharedProject.Models.Base;
using System.Threading.Tasks;

namespace SharedProject.Helpers
{
    public static class ServiceBusMessageHelper
    {
        public static async Task SendMessageAsync(this ServiceBusClient client, IServiceBusEventBase message)
        {

            var sender = client.CreateSender(message.Topic);

            ServiceBusMessage sbmessage = new ServiceBusMessage(JsonConvert.SerializeObject(message))
            {
                Subject = message.Subject,
            };

            await sender.SendMessageAsync(sbmessage);
            await sender.DisposeAsync();
        }
    }
}
