using MassTransit;
using RabbitMQ.Messages;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer
{
    public class RegisterCustomerConsumer : IConsumer<IRegisterCustomer>
    {
        public Task Consume(ConsumeContext<IRegisterCustomer> context)
        {
            IRegisterCustomer newCustomer = context.Message;
            Console.WriteLine("Consumer : A new customer has signed up, it's time to register it. Details: ");
            Console.WriteLine(newCustomer.Id);
            Console.WriteLine(newCustomer.Name);
            Console.WriteLine(newCustomer.Address);
            Console.WriteLine(newCustomer.Preferred);
            
            return Task.FromResult(context.Message);
        }
    }
    public class RegisterCustomerFaultConsumer : IConsumer<Fault<IRegisterCustomer>>
    {
        public Task Consume(ConsumeContext<Fault<IRegisterCustomer>> context)
        {
            IRegisterCustomer originalFault = context.Message.Message;
            ExceptionInfo[] exceptions = context.Message.Exceptions;
            Debug.WriteLine("${"+originalFault+"}");
            Debug.WriteLine("${" + exceptions + "}");
            return Task.FromResult(originalFault);
        }
    }
}
