using Project.Core.GenericRepository;
using Project.DAL.IRepository;
using Project.Model;
using Project.Model.Database;
using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository
{
    public class InvoiceRepository : EFRepository<Invoice_Header, int>, IInvoiceRepository
    {
        public InvoiceRepository(IProjectSampleUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Invoice_Header> GetInvoices()
        {
            return Get();
        }
        //navigators
        private static FostanyEntities db = new FostanyEntities();

        public  int? Previous(int id)
        {
            var per = db.GetPerInvoiceId(id).FirstOrDefault();
            return per;
        }
        public  int? Next(int id)
        {
            int? next =  db.GetNextInvoiceId(id).FirstOrDefault();
            return next;
        }
        public int GetMaxId()
        {
            return Get().Max(a => a.Id);
        }

    }
}
