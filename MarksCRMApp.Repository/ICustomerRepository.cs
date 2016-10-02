using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetById(long id);
    }

}
