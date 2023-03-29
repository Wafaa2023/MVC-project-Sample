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
    public class InvoiceDetailsManager : IInvoiceDetailsManager
    {
        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceDetailsManager(IInvoiceDetailsRepository invoiceDetailsRepository, IInvoiceRepository invoiceRepository)
        {
            _invoiceDetailsRepository = invoiceDetailsRepository;
            _invoiceRepository = invoiceRepository;
        }
        public void AddInvoice(InvoiceVM model)
        {

            List<Invoice_Details> Detailslist = new List<Invoice_Details>();

            foreach (var item in model.InvoiceDetails)
            {
                Invoice_Details invoiceObj = new Invoice_Details()
                {
                    Id = item.Id,
                    Invoice_Header_Id = _invoiceRepository.GetMaxId(),
                    Item_Id = item.Item_Id,
                    Price = item.Price,
                    Qty = item.Qty,
                    Total = item.Total
                };
                Detailslist.Add(invoiceObj);
            }

            _invoiceDetailsRepository.AddRange(Detailslist);
            _invoiceDetailsRepository.SaveChanges();


        }
        //edit
        public void EditInvoice(InvoiceVM model)
        {
            List<Invoice_Details> Detailslist = new List<Invoice_Details>();

            foreach (var item in model.InvoiceDetails)
            {
                Invoice_Details invoiceObj = new Invoice_Details()
                {
                    Id = item.Id,
                    Invoice_Header_Id = _invoiceRepository.GetByID(model.MainId).Id,
                    Item_Id = item.Item_Id,
                    Price = item.Price,
                    Qty = item.Qty,
                    Total=item.Total
                };
                Detailslist.Add(invoiceObj);
            }
            var oldDetails = _invoiceDetailsRepository.GetInvoicesDetails(model.MainId).ToList();
            _invoiceDetailsRepository.DeleteList(oldDetails);
            _invoiceDetailsRepository.AddRange(Detailslist);

            _invoiceDetailsRepository.SaveChanges();

        }

    }
}
