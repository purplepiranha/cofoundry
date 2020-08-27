using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cofoundry.Domain;
using Cofoundry.Core;

namespace Cofoundry.Web.Admin
{
    public class CustomEntitiesAdminModuleRegistration : IAdminModuleRegistration
    {
        private readonly IEnumerable<ICustomEntityDefinition> _customEntityDefinitions;
        private readonly IAdminRouteLibrary _adminRouteLibrary;

        public CustomEntitiesAdminModuleRegistration(
            IEnumerable<ICustomEntityDefinition> customEntityDefinitions,
            IAdminRouteLibrary adminRouteLibrary
            )
        {
            _customEntityDefinitions = customEntityDefinitions;
            _adminRouteLibrary = adminRouteLibrary;
        }

        public IEnumerable<AdminModule> GetModules()
        {
            var genericBase = typeof(AdminModule<>);

            foreach (var definition in _customEntityDefinitions)
            {
                dynamic module;

                if (definition.AdminModuleMenuCategoryType == null)
                {
                    module = new HiddenAdminModule();
                }
                else
                {
                    var combinedType = genericBase.MakeGenericType(new Type[] { definition.AdminModuleMenuCategoryType });
                    module = Activator.CreateInstance(combinedType);
                }

                module.AdminModuleCode = definition.CustomEntityDefinitionCode;
                module.Description = definition.Description;
                module.PrimaryOrdering = AdminModuleMenuPrimaryOrdering.Tertiary;
                module.Title = definition.NamePlural;
                module.Url = _adminRouteLibrary.CustomEntities.List(definition);
                module.RestrictedToPermission = new CustomEntityAdminModulePermission(definition);

                yield return module;
            }
        }
    }
}
