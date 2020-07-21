using MassTransit;
using RabbitMQ.Messages;
using System;
using System.Threading.Tasks;
using MassTransit.Transports.InMemory;
namespace RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CUSTOMER REGISTRATION COMMAND PUBLISHER");
            Console.Title = "Publisher window";
            //RunMassTransitSendWithRabbit();
            RunMassTransitPublisherWithRabbit();
            Console.ReadKey();
        }
      

        private static void RunMassTransitPublisherWithRabbit()
        {
            //Get Bus Configurtion 
            var rabbitBusControl = BusConfigurator.ConfigureBus();
            //Publich Message (IRegisterCustomer)
            Task sendTask = rabbitBusControl.Publish<IRegisterCustomer>(new
            {
                Id = Guid.NewGuid(),
                Name = "Abdurabu",
                Preferred = true,
                Address = "New Street",
                RegisteredUtc = DateTime.UtcNow,
                Type = 1,
                DefaultDiscount = 0,

            });
            Console.ReadKey();
        }

        private static void RunMassTransitSendWithRabbit()
        {
            var rabbitBusControl = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + $"{RabbitMqConstants.NotificationServiceQueue}");
            Task<ISendEndpoint> sendEndpointTask = rabbitBusControl.GetSendEndpoint(sendToUri);
            var sendEndpoint = sendEndpointTask.Result;

            Task sendTask = sendEndpoint.Send<IRegisterCustomer>(new
            {
                Id = Guid.NewGuid(),
                Name = "Abdurabu",
                Preferred = true,
                Address = "Test",
                RegisteredUtc = DateTime.UtcNow,
                Type = 1,
                DefaultDiscount = 0
            });
            Console.ReadKey();
        }
    }
}
