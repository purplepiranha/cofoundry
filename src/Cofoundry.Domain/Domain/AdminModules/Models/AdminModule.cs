using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    public abstract class AdminModule
    {
        /// <remarks>
        /// Uniquely identifies the module
        /// </remarks>
        public string AdminModuleCode { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public abstract Type MenuCategoryType { get; }

        /// <summary>
        /// A primary ordering that is used to partition
        /// menu item ordering in a meaningful way before a more ambiguous
        /// secondary ordering is used.
        /// </summary>
        public AdminModuleMenuPrimaryOrdering PrimaryOrdering { get; set; }

        /// <summary>
        /// The ordering that is applied after primary ordering when constructing the admin
        /// menu in the GUI.
        /// </summary>
        public int SecondaryOrdering { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// The IPermission to check to see if the user is allowed to 
        /// view this module.
        /// </summary>
        public IPermission RestrictedToPermission { get; set; }

        public string GetMenuLinkByPath(string path)
        {
            if (Url != null && Url.StartsWith(path, StringComparison.OrdinalIgnoreCase))
            {
                return Url;
            }

            return null;
        }
    }

    /// <summary>
    /// Defines an AdminModule.
    /// This should be used for admin modules that are hidden from the menu.
    /// </summary>
    public class HiddenAdminModule : AdminModule
    {
        public override Type MenuCategoryType => null;
    }


    /// <summary>
    /// Defines an AdminModule.
    /// This should be used for admin modules that are displayed in the menu.
    /// Use HiddenAdminModule to hide from the menu.
    /// </summary>
    /// <typeparam name="T">The top level menu defined by implementing IAdminModuleMenuCategory</typeparam>
    public class AdminModule<T> : AdminModule where T : IAdminModuleMenuCategory
    {
        public override Type MenuCategoryType => typeof(T);
    }
}
