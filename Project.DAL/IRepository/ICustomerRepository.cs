using Project.Model.Database;
using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.IRepository
{
    public interface ICustomerRepository :Core.GenericRepository.IRepository<Customer, int>
    {

       
    }
}
