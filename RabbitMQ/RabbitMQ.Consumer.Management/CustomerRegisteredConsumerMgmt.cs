using MassTransit;
using RabbitMQ.Messages;
using System;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Management
{
    class CustomerRegisteredConsumerMgmt : IConsumer<IRegisterCustomer>
    {
        public Task Consume(ConsumeContext<IRegisterCustomer> context)
        {
            var newCustomer = context.Message;
            Console.WriteLine("Management Consumer : A new customer has signed up, it's time to register it. Details: ");
            Console.WriteLine(newCustomer.Id);
            Console.WriteLine(newCustomer.Name);
            Console.WriteLine(newCustomer.Address);
            Console.WriteLine(newCustomer.Preferred);

            return Task.FromResult(context.Message);
        }
    }
}
