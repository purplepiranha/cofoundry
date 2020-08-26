using System;
using System.Collections.Generic;
using System.Text;

namespace Cofoundry.Domain
{
    public class ContentAdminModuleMenuCategory : IAdminModuleMenuCategory
    {
        //public string MenuCode => "COFCON";

        public string Title => "Content";

        public string IconCssClass => "fa fa-pencil";

        public int Order => 100;
    }
}
