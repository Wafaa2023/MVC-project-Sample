using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Database;
using Project.Core.GenericRepository;
using Project.DAL.IRepository;
using Project.Model;

namespace Project.DAL.Repository
{
   
       public class InvoiceDetailsRepository : EFRepository<Invoice_Details, int>, IInvoiceDetailsRepository
    {

        public InvoiceDetailsRepository(IProjectSampleUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Invoice_Details> GetInvoicesDetails(int id)
        {
            return Get().Where(a=>a.Invoice_Header_Id==id).ToList();
        }
     
        

    }
}
