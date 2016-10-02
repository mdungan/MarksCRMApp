using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Service
{
    public interface IStateService : IEntityService<State>
    {
        State GetById(int Id);
    }


}
