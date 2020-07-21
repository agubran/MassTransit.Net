using MassTransit;
using RabbitMQ.Messages;
using System;

namespace RabbitMQ.Consumer.Sales
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Sales consumer";
            Console.WriteLine(" ================= SALES  =================");
            RunMassTransitReceiverWithRabbit();
        }
        private static void RunMassTransitReceiverWithRabbit()
        {
            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.NotificationServiceQueue +".sales", e =>
                {
                    e.Consumer<CustomerRegisteredConsumerSls>();
                });
            });

            bus.Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"Listening for Order registered events.. Press enter to exit");
            Console.WriteLine(" ==================================");
            Console.ReadLine();
            bus.Stop();
        }
    }
}
