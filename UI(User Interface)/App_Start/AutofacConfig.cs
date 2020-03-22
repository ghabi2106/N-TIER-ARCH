using Autofac;
using Autofac.Integration.Mvc;
using BLL_Business_Logic_Layer_;
using BLL_Business_Logic_Layer_.Constants;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using UI_User_Interface_.Autofac;
using UI_User_Interface_.Controllers;

namespace UI_User_Interface_
{
    public class AutofacConfig
    {
        /*Quelques soit le container utilisé(container natif ou Autofac), il faut privilégier l’injection par 
         * le constructeur de façon à ce que les dépendances d’une classe soient facilement visibles.*/

        public static void Run()
        {
            var builder = new ContainerBuilder();
            RegisterDependencies(builder);
        }

        public static void RegisterDependencies(ContainerBuilder builder)
        {

            // Register the web controller (defined in Autofac.Integration.Mvc)
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(EquipmentsController).Assembly);

            builder.RegisterType<CompanyEquipModel>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EquipmentRepository).Assembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EquipmentService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerRequest();

            //builder.RegisterType<ApplicationUserStore<User>>().AsSelf().InstancePerRequest();
            //builder.RegisterType<UserManager<User>>().AsSelf().InstancePerRequest();

            // Register the modules
            builder.RegisterModule(new ApplicationNameModule(ApplicationConstants.CompanyEquip));

            // Resolve the container
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}