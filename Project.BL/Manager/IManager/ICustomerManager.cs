using Project.Model.Database;
using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Manager.IManager
{
   public interface ICustomerManager
    {
        void Delete(int custId);
        void AddCustomer(CustomerVM custvm);
        Customer GetCustomer(int custId);
        void SaveCustomerAfterEditing(CustomerVM custVm);
        IEnumerable<CustomerVM> GetCustomers();

    }
}
