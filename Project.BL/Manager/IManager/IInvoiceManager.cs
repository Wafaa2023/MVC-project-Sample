using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Manager.IManager
{
    public interface IInvoiceManager
    {
        IEnumerable<InvoiceVM> GetInvoices();
        void AddInvoice(InvoiceVM model);
        void EditInvoice(InvoiceVM model);
        int? Next(int id);
        int? Previous(int id);
    }
}