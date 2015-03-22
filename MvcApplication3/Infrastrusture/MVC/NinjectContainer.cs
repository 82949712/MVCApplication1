using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Infrastrusture.MVC
{
    public interface IContainer
    {
        T Resolve<T>();
    }

    public class NinjectContainer : IContainer
    {
        private readonly IKernel kernel;
        public NinjectContainer(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }

    public static class ContextAccessor
    {
        public static IContainer CurrentContext { get; set; }
    }
}
