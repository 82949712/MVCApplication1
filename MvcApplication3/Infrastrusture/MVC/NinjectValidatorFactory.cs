using System;
using System.Collections.Generic;
using FluentValidation;
using Ninject;
using Ninject.Planning.Bindings;

namespace Infrastrusture.MVC
{
    /// <summary>
    /// Validation factory that uses ninject to create validators  
    /// </summary>
    public class NinjectValidatorFactory : ValidatorFactoryBase
    {

        private readonly IContainer _container;
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectValidatorFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectValidatorFactory(IContainer container)
        {
            _container = container;
        }


        /// <summary>
        /// Creates an instance of a validator with the given type using ninject.
        /// </summary>
        /// <param name="validatorType">Type of the validator.</param>
        /// <returns>The newly created validator</returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            //if (((IList<IBinding>) Kernel.GetBindings(validatorType)).Count == 0)
            //{
            //    return null;
            //}

            //return Kernel.Get(validatorType) as IValidator;
        }
    }
}
