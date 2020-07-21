using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using MassTransit;

using RabbitMQ.Messages;

namespace RabbitMQ.DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void SendBtn_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var bus = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + $"{RabbitMqConstants.NotificationServiceQueue}");
            Task<ISendEndpoint> sendEndpointTask = bus.GetSendEndpoint(sendToUri);
            var sendEndpoint = sendEndpointTask.Result;

            var sendTask = sendEndpoint.Send<IRegisterCustomer>(new
            {
                Id = Guid.NewGuid(),
                Name = "Send Data : " + random.Next(),
                Preferred = true,
                Address = "Test",
                RegisteredUtc = DateTime.UtcNow,
                Type = 1,
                DefaultDiscount = 0
            });
        }
        private void PublishBtn_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var bus = BusConfigurator.ConfigureBus();
            var publishTask = bus.Publish<IRegisterCustomer>(new
            {
                Id = Guid.NewGuid(),
                Name = "Publish Data : " + random.Next(),
                Preferred = true,
                Address = "Test",
                RegisteredUtc = DateTime.UtcNow,
                Type = 1,
                DefaultDiscount = 0
            });
        }
    }
}
