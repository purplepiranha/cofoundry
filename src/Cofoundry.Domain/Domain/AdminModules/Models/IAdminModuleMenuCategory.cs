using System;
using System.Collections.Generic;
using System.Text;

namespace Cofoundry.Domain
{
    /// <summary>
    /// Implement this interface to create new top level admin menu categories
    /// </summary>
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
