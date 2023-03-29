using Project.BL.Manager.IManager;
using Project.DAL.IRepository;
using Project.Model.Database;
using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<CustomerVM> GetCustomers()
        {
            return _customerRepository.Get().Select(a => new CustomerVM()
            {
                Id = a.Id,
                Mobile = a.Mobile,
                Name = a.Name,
                Address = a.Address
            });
           
      
        }
        //edit
        public void AddCustomer(CustomerVM custObj)
        {
            Customer cust = new Customer()
            {
                Id = custObj.Id,
                Name = custObj.Name,
                Mobile = custObj.Mobile,
                Address = custObj.Address,
            };
            _customerRepository.Add(cust);
            _customerRepository.SaveChanges();
        }
        /// <summary>
        /// Method To Edit supplier  by catching the id by method called GetId ....this is step 1  
        /// this method to show the record with a specific id (get id) 
        /// get data from database 
        /// /// </summary>

        public Customer GetCustomer(int CustomerId)
        {
            return _customerRepository.GetByID(CustomerId);
        }
        /// <summary>
        /// after editing the record i will save the editing record in the database
        /// </summary>
        public void SaveCustomerAfterEditing(CustomerVM custVM)
        {

            var custModel = _customerRepository.GetByID(custVM.Id);
            custModel.Name = custVM.Name.Trim();
            custModel.Mobile = custVM.Mobile;
            custModel.Address = custVM.Address;

            _customerRepository.SaveChanges();
        }

        //delete 
        public void Delete(int CustomerId)
        {
            _customerRepository.DeleteByID(CustomerId);
            _customerRepository.SaveChanges();
        }



    }
}
