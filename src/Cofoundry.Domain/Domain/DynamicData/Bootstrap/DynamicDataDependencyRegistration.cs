﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.DependencyInjection;
using Cofoundry.Domain.Internal;

namespace Cofoundry.Domain.DependencyRegistration
{
    public class DynamicDataDependencyRegistration : IDependencyRegistration
    {
        public void Register(IContainerRegister container)
        {
            container
                .RegisterSingleton<INestedDataModelTypeRepository, NestedDataModelTypeRepository>()
                .Register<IDynamicDataModelSchemaMapper, DynamicDataModelSchemaMapper>()
                .RegisterAll<INestedDataModel>()
                ;
        }
    }
}
