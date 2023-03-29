using Project.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.IRepository
{
    public interface IInvoiceRepository : Core.GenericRepository.IRepository<Invoice_Header, int>
    {
        IEnumerable<Invoice_Header> GetInvoices();
        int? Next(int id);
        int? Previous(int id);
        int GetMaxId();
   
    }
}
