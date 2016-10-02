using MarksCRMApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Repository
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<Note> GetAll()
        {
            return _entities.Set<Note>().AsEnumerable();
        }

        public Note GetById(long id)
        {
            //return FindBy(x => x.Id == id).FirstOrDefault();
            return this.GetAll().Where(item => item.Id.Equals(id)).SingleOrDefault();
        }
        public IEnumerable<Note> GetByCustomerId(long id)
        {
            return this.GetAll().Where(item => item.CustomerId.Equals(id)).AsEnumerable();
        }

    }
}
