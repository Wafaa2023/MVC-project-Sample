﻿
using Project.Model.Database;
using SampleProject.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Manager.IManager
    {
        public interface IPaymentMethodManager
        {
            IEnumerable<PaymentMethodVM> GetPaymentMethods();
        }
    }

