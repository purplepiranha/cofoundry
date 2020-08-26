using Cofoundry.Core;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Cofoundry.Web.Admin
{
    public class AdminMenuViewComponent : ViewComponent
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IEnumerable<IAdminModuleMenuCategory> _adminModuleMenuCaterories;

        public AdminMenuViewComponent(
            IQueryExecutor queryExecutor,
            IEnumerable<IAdminModuleMenuCategory> adminModuleMenuCaterories
            )
        {
            _queryExecutor = queryExecutor;
            _adminModuleMenuCaterories = adminModuleMenuCaterories;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuItems = await _queryExecutor.ExecuteAsync(new GetPermittedAdminModulesQuery());

            var menuCategories = _adminModuleMenuCaterories
                .OrderBy(c => c.Order)
                .ToList();

            var vm = new AdminMenuViewModel();
            var categories = new List<AdminMenuCategoryViewModel>();

            foreach (var menuCategory in menuCategories)
            {

                var cvm = new AdminMenuCategoryViewModel();
                cvm.Category = menuCategory;

                cvm.Modules = menuItems
                    .Where(m => m.MenuCategoryType == menuCategory.GetType())
                    .SetStandardOrdering()
                    .ToList();

                // only add the category if there are items to display
                if (cvm.Modules.Count() > 0)
                    categories.Add(cvm);
            }

            vm.Categories = categories;

            var selectedItem = menuItems
                   .Select(m => new {
                       Module = m,
                       Link = m.GetMenuLinkByPath(Request.Path),
                       CategoryType = m.MenuCategoryType
                   })
                   .Where(m => m.Link != null)
                   .FirstOrDefault();

            var categoryType = selectedItem.CategoryType;

            if (selectedItem != null)
            {
                vm.SelectedCategory = menuCategories.Where(c => c.GetType() == categoryType).FirstOrDefault();
                vm.SelectedModule = selectedItem.Module;
            }

            var viewPath = ViewPathFormatter.View("Shared", "Components/AdminMenu");

            return View(viewPath, vm);
        }
    }
}
