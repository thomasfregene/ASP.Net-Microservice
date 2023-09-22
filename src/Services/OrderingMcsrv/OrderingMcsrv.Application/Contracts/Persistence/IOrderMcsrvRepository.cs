using OrderingMcsrv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingMcsrv.Application.Contracts.Persistence
{
    public interface IOrderMcsrvRepository : IAsyncRepository<OrderMcsrv>
    {
        Task<IEnumerable<OrderMcsrv>> GetOrdersByUsername(string username);
    }
}
