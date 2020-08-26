using System;
using System.Collections.Generic;
using System.Text;

namespace Cofoundry.Domain
{
    public class SettingsAdminModuleMenuCategory : IAdminModuleMenuCategory
    {
        //public string MenuCode => "COFSET";

        public string Title => "Settings";

        public string IconCssClass => "fa fa-cog";

        public int Order => 200;
    }
}
