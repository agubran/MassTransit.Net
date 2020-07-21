using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Domain
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
    }
}
