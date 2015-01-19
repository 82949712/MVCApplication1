using CodeFirstFromDB;
using Core;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Infrastructure.IoC
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentRepository>().To<StudentRepository>().InRequestScope();
        }
    }
}
