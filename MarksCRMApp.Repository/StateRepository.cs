using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Repository
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(DbContext context)
              : base(context)
        {

        }
        public State GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }

}
