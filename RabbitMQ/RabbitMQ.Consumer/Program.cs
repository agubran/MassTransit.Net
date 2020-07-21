using GreenPipes;
using MassTransit;
using RabbitMQ.Messages;
using System;

namespace RabbitMQ.Consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Command Receiver.";
            Console.WriteLine("Consumer Start Listening ");
            RunMassTransitReceiverWithRabbit_RegisterCustomerConsumer();
            //RunMassTransitReceiverWithRabbit_RegisterCustomerConsumer2();
        }
        private static void RunMassTransitReceiverWithRabbit_RegisterCustomerConsumer()
        {
            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.UseRetry(e =>
                {
                    ////The Immediate method accepts an integer and sets up a policy to resend a message that many times with no delay in between.
                    //e.Immediate(5));

                    ////The Except exception will run the retry policy EXCEPT for the exception type specified
                    //e.Except(typeof(ArgumentException)).Immediate(5));

                    ////The Selected exception will run the retry policy Select for the exception type specified
                    //e.Selected(typeof(ArgumentException)).Immediate(5));

                    //The Selected function where we can provide the exception types for which the retry policy should be applied
                    e.Interval(5, TimeSpan.FromSeconds(10));

                    ////Filter method which accepts a Func that returns a bool
                    //e.Filter<Exception>(ex => ex.Message.IndexOf("We pretend that an exception was thrown") > -1).Immediate(5));

                    ////Exponential policy builder we can specify a min and max interval for the time between retries (n^N)
                    //e.Exponential(5, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(5)));
                    
                    //Retry sending messages if one of these exceptions occured
                    e.Handle<TimeoutException>();

                    //Don't retry to send messages if one of these exceptions occured
                    e.Ignore<ArgumentNullException>();
                    e.Ignore<NullReferenceException>();
                });
                cfg.ReceiveEndpoint(host, RabbitMqConstants.NotificationServiceQueue, e =>
                {
                    e.Consumer<RegisterCustomerConsumer>();
                });
            });

            bus.Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Listening for Order registered events.. Press enter to exit");
            Console.ReadLine();
            bus.Stop();
        }

        private static void RunMassTransitReceiverWithRabbit_RegisterCustomerConsumer2()
        {
            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.NotificationServiceQueue, e =>
                {
                    e.Consumer<RegisterCustomerConsumer>();
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
