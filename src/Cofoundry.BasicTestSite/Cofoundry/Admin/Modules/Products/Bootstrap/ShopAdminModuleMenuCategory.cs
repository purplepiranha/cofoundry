using Cofoundry.Domain;
using Cofoundry.Web.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.BasicTestSite
{
    public class ShopAdminModuleMenuCategory : IAdminModuleMenuCategory
    {
        public string Title => "Shop";

        public string IconCssClass => "fa fa-shopping-cart";

        public int Order => 150;
    }
}
