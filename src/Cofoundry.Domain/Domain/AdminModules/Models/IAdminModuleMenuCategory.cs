using System;
using System.Collections.Generic;
using System.Text;

namespace Cofoundry.Domain
{
    public interface IAdminModuleMenuCategory
    {

        /// <summary>
        /// Title of the menu
        /// </summary>
        string Title { get; }

        /// <summary>
        /// CSS Class for the icon
        /// </summary>
        string IconCssClass { get; }

        /// <summary>
        /// The order in which the menu appears within the admin area
        /// </summary>
        int Order { get; }
    }
}
