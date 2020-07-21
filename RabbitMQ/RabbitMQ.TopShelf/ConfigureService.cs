using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace RabbitMQ.TopShelf
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            var rc = HostFactory.Run(configure =>
            {
                configure.Service<MyService>(service =>
                {
                    service.ConstructUsing(s => new MyService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("RabbitMQ_TopShelf");
                configure.SetDisplayName("RabbitMQ_TopShelf");
                configure.SetDescription("This .Net windows service using Topshelf");
            });
            HostFactory.New(x => {

            });
            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
