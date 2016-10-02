using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<Customer> GetAll()
        {
            return _entities.Set<Customer>().Include(x => x.State).AsEnumerable();
        }

        public Customer GetById(long id)
        {
            return _dbset.Include(x => x.State).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
