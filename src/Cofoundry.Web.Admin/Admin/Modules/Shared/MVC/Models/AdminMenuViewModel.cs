using System;
using System.Collections.Generic;
using System.Linq;
using Cofoundry.Domain;

namespace Cofoundry.Web.Admin
{
    public class AdminMenuViewModel
    {
        public IEnumerable<AdminMenuCategoryViewModel> Categories { get; set; }

        public IAdminModuleMenuCategory SelectedCategory { get; set; }

        public AdminModule SelectedModule { get; set; }
    }
}