using System;
using System.Collections.Generic;
using System.Linq;
using Cofoundry.Domain;

namespace Cofoundry.Web.Admin
{
    public class AdminMenuCategoryViewModel
    {
        public IAdminModuleMenuCategory Category { get; set; }

        public IEnumerable<AdminModule> Modules { get; set; }
    }
}