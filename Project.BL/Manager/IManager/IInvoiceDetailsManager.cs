using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Manager.IManager
{
    public interface IInvoiceDetailsManager
    {
        void EditInvoice(InvoiceVM model);
        void AddInvoice(InvoiceVM model);
    }
}