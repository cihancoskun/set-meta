﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using SetMeta.Web.Services;

namespace SetMeta.Web
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404,
                    string.Format("The controller for path '{0}' could not be found.",
                        requestContext.HttpContext.Request.Path));
            }

            return (IController) _kernel.Resolve(controllerType);
        }
    }

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn<IController>()
                                      .Unless(x => x.Name == "BaseController")
                                      .LifestyleTransient());
        }
    }

    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IFormsAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifestylePerWebRequest(),
                Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest(),
                Component.For<IAppService>().ImplementedBy<AppService>().LifestylePerWebRequest(),
                Component.For<IMetaDataService>().ImplementedBy<MetaDataService>().LifestylePerWebRequest(),
                Component.For<IFeedbackService>().ImplementedBy<FeedbackService>().LifestylePerWebRequest());
        }
    }
}