using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Repository
{
    public interface IStateRepository : IGenericRepository<State>
    {
        State GetById(int id);
    }


}
