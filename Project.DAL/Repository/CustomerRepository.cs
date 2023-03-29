using Project.Core.GenericRepository;
using Project.DAL.IRepository;
using Project.Model;
using Project.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleProject.DTO.ViewModel;

namespace Project.DAL.Repository
{
   
   public class CustomerRepository: EFRepository<Customer, int>, ICustomerRepository
    {
    
        public CustomerRepository(IProjectSampleUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
       
    }
}
