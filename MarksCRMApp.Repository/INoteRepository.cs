using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Repository
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        Note GetById(long id);
        IEnumerable<Note> GetByCustomerId(long id);
    }
}
