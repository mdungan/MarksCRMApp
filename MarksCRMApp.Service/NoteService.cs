using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Service
{
    public class NoteService : EntityService<Note>, INoteService
    {
        IUnitOfWork _unitOfWork;
        INoteRepository _noteRepository;

        public NoteService(IUnitOfWork unitOfWork, INoteRepository noteRepository)
            : base(unitOfWork, noteRepository)
        {
            _unitOfWork = unitOfWork;
            _noteRepository = noteRepository;
        }


        public Note GetById(long Id)
        {
            return _noteRepository.GetById(Id);
        }

        public IEnumerable<Note> GetByCustomerId(long Id)
        {
            return _noteRepository.GetByCustomerId(Id);
        }

    }
}
