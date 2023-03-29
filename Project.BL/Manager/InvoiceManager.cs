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
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailsManager _invoiceDetailsManager;
        public InvoiceManager(IInvoiceRepository invoiceRepository, IInvoiceDetailsManager invoiceDetailsManager)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailsManager = invoiceDetailsManager;
        }
        public IEnumerable<InvoiceVM> GetInvoices()
        {

            return _invoiceRepository.GetInvoices().Select(a => new InvoiceVM()
            {
                MainId = a.Id,
                Number = a.Number,
                Date = a.Date,
                CustomerName = a.Customer.Name
            });
        }
        //navigators
        public  int? Previous(int id)
        {
            var per = _invoiceRepository.Previous(id);
            return per;
        }
        public  int? Next(int id)
        {
            var next = _invoiceRepository.Next(id);
            return next;
        }
        //edit
        public void AddInvoice(InvoiceVM model)
        {
                Invoice_Header invoiceObj = new Invoice_Header()
                {
                    Number = model.Number,
                    Payment_Method_Id = model.PaymentMethodId,
                    Date = model.Date,
                    Customer_Id = model.CustomerId,
                    Total = model.Total,
                    DiscountPercentage = model.Discount,
                    NetTotal = model.NetTotal,

                };
                _invoiceRepository.Add(invoiceObj);
                _invoiceRepository.SaveChanges();
               _invoiceDetailsManager.AddInvoice(model);
               _invoiceRepository.SaveChanges();
        }
    public void EditInvoice(InvoiceVM model)
    {
            Invoice_Header invoiceObj = _invoiceRepository.GetByID(model.MainId);

            invoiceObj.Number = model.Number;
            invoiceObj.Payment_Method_Id = model.PaymentMethodId;
            invoiceObj.Date = model.Date;
            invoiceObj.Customer_Id = model.CustomerId;
            invoiceObj.Total = model.Total;
            invoiceObj.DiscountPercentage = model.Discount;
            invoiceObj.NetTotal = model.NetTotal;


            _invoiceRepository.Update(invoiceObj);
            _invoiceRepository.SaveChanges();
            _invoiceDetailsManager.EditInvoice(model);


        }
    }
}
