using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Project.Core.UnitOfWorks;
using Project.DAL.Repository;
using Project.DAL.IRepository;
using Project.BL.Manager;
using Project.BL.Manager.IManager;
using Project.Model;

namespace Project.Utilities.DIService
{
    public class ServiceRegistry : Module
    {
        public static ContainerBuilder Register(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectSampleUnitOfWork>().As<IProjectSampleUnitOfWork>().InstancePerLifetimeScope();


            //-----------------CustomerRepository------------------------------------------
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();

            //-----------------CustomerManager---------------------------------------------

            builder.RegisterType<CustomerManager>().As<ICustomerManager>().InstancePerLifetimeScope();
            //-----------------InvoiceRepository------------------------------------------
            builder.RegisterType<InvoiceRepository>().As<IInvoiceRepository>().InstancePerLifetimeScope();

            //-----------------InvoiceManager---------------------------------------------

            builder.RegisterType<InvoiceManager>().As<IInvoiceManager>().InstancePerLifetimeScope();
            //-----------------InvoiceDetailsRepository------------------------------------------
            builder.RegisterType<InvoiceDetailsRepository>().As<IInvoiceDetailsRepository>().InstancePerLifetimeScope();

            //-----------------InvoiceDetailsManager---------------------------------------------

            builder.RegisterType<InvoiceDetailsManager>().As<IInvoiceDetailsManager>().InstancePerLifetimeScope();

            //-----------------ItemRepository------------------------------------------
            builder.RegisterType<ItemRepository>().As<IItemRepository>().InstancePerLifetimeScope();

            //-----------------ItemManager---------------------------------------------

            builder.RegisterType<ItemManager>().As<IItemManager>().InstancePerLifetimeScope();
            //-----------------PaymentMethodRepository------------------------------------------
            builder.RegisterType<PaymentMethodRepository>().As<IPaymentMethodRepository>().InstancePerLifetimeScope();

            //-----------------InvoiceManager---------------------------------------------

            builder.RegisterType<PaymentMethodManager>().As<IPaymentMethodManager>().InstancePerLifetimeScope();
            return builder;

        }


    }
}
