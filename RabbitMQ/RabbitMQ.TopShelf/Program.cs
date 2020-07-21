
namespace RabbitMQ.TopShelf
{
    class Program
    {
        //To install it in winService control 
        //Run this command in cmd in same service direction [RabbitMQ.TopShelf.exe install]
        static void Main(string[] args)
        {
            ConfigureService.Configure();
        }
    }
}
