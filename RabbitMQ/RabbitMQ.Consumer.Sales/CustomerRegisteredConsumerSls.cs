using MassTransit;
using RabbitMQ.Messages;
using System;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Sales
{
    class CustomerRegisteredConsumerSls : IConsumer<IRegisterCustomer>
    {
        public Task Consume(ConsumeContext<IRegisterCustomer> context)
        {
            var newCustomer = context.Message;
            Console.WriteLine("Great to see the new customer finally being registered, a big sigh from sales!");
            Console.WriteLine(newCustomer.Id);
            Console.WriteLine(newCustomer.Name);
            Console.WriteLine(newCustomer.Address);
            Console.WriteLine(newCustomer.Preferred);

            return Task.FromResult(context.Message);
        }
    }
}
