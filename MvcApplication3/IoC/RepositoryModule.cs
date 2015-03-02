using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Web.Core;
using Ninject.Web.Common;

namespace IoC
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentRepository>().To<MockStudentRepository>().InRequestScope();
        }
    }
}
