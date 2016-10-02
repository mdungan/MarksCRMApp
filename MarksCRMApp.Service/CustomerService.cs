using MarksCRMApp.Model;
using MarksCRMApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksCRMApp.Service
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        IUnitOfWork _unitOfWork;
        ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
            : base(unitOfWork, customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }


        public Customer GetById(long Id)
        {
            return _customerRepository.GetById(Id);
        }
    }

}
