using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Service
{
    public class StateService : EntityService<State>, IStateService
    {
        IUnitOfWork _unitOfWork;
        IStateRepository _stateRepository;

        public StateService(IUnitOfWork unitOfWork, IStateRepository stateRepository)
            : base(unitOfWork, stateRepository)
        {
            _unitOfWork = unitOfWork;
            _stateRepository = stateRepository;
        }


        public State GetById(int Id)
        {
            return _stateRepository.GetById(Id);
        }
    }


}
