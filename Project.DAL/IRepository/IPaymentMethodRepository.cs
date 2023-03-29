using Project.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.IRepository
{
 
        public interface IPaymentMethodRepository : Core.GenericRepository.IRepository<PaymentMethod, int>
        {


        }
    
}
