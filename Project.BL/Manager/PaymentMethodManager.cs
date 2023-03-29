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
    public class PaymentMethodManager : IPaymentMethodManager
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public PaymentMethodManager(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }
        public IEnumerable<PaymentMethodVM> GetPaymentMethods()
        {

            return _paymentMethodRepository.Get().Select(a => new PaymentMethodVM()
            {
                Id = a.Id,
                Name = a.Name
            });
        }
    }
} 
