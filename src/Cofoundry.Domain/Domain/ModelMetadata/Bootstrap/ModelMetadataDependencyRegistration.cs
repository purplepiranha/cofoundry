﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.DependencyInjection;
using Cofoundry.Domain.Internal;

namespace Cofoundry.Domain.DependencyRegistration
{
    public class ModelMetadataDependencyRegistration : IDependencyRegistration
    {
        public void Register(IContainerRegister container)
        {
            container
                .RegisterSingleton<CofoundryDisplayMetadataProvider>()
                .RegisterAll<IModelMetadataDecorator>(RegistrationOptions.SingletonScope())
                ;
        }
    }
}
