using Project.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.IRepository
{
    public interface IInvoiceDetailsRepository : Core.GenericRepository.IRepository<Invoice_Details, int>
    {
        IEnumerable<Invoice_Details> GetInvoicesDetails(int id);
        void AddRange(List<Invoice_Details> detailslist);

    }
}
