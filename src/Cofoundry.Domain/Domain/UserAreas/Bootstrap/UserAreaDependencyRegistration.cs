﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.DependencyInjection;
using Cofoundry.Domain.Internal;

namespace Cofoundry.Domain.DependencyRegistration
{
    public class UserAreaDependencyRegistration : IDependencyRegistration
    {
        public void Register(IContainerRegister container)
        {
            container
                .Register<UserAuthenticationHelper, UserAuthenticationHelper>()
                .Register<UserCommandPermissionsHelper, UserCommandPermissionsHelper>();
        }
    }
}
