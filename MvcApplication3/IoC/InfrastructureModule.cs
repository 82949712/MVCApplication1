using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Infrastrusture.Logging;
using Infrastrusture.MVC;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;

namespace IoC
{
    public class InfrastructureModule : NinjectModule 
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger>();
            this.BindFilter<LoggingFilter>(System.Web.Mvc.FilterScope.Global, 0); //Register LoggingFilter as a global filter
        }
    }
}
