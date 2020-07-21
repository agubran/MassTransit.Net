using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace RabbitMQ.Messages
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            var bus= Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMqConstants.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMqConstants.UserName);
                    hst.Password(RabbitMqConstants.Password);
                    
                });
                registrationAction?.Invoke(cfg, host);
            });
            return bus;
        }
    }
}
