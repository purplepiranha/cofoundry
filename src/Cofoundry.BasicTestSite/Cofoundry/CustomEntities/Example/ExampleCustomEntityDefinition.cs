﻿using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cofoundry.BasicTestSite
{
    /// <summary>
    /// Each custom entity requires a definition class which provides settings
    /// describing the entity and how it should behave.
    /// </summary>
    public class ExampleCustomEntityDefinition 
        : ICustomEntityDefinition<ExampleDataModel>
        , ISortedCustomEntityDefinition
        , IOrderableCustomEntityDefinition
    {
        /// <summary>
        /// This constant is a convention that allows us to reference this definition code 
        /// in other parts of the application (e.g. querying)
        /// </summary>
        public const string DefinitionCode = "SIMEXA";

        /// <summary>
        /// Unique 6 letter code representing the entity (the convention is to use uppercase)
        /// </summary>
        public string CustomEntityDefinitionCode => DefinitionCode;

        /// <summary>
        /// Singlar name of the entity
        /// </summary>
        public string Name => "Example";

        /// <summary>
        /// Plural name of the entity
        /// </summary>
        public string NamePlural => "Examples";

        /// <summary>
        /// A short description that shows up as a tooltip for the admin 
        /// module.
        /// </summary>
        public string Description => "Example data.";

        /// <summary>
        /// Indicates whether the UrlSlug property should be treated
        /// as a unique property and be validated as such.
        /// </summary>
        public bool ForceUrlSlugUniqueness => true;

        /// <summary>
        /// Indicates whether the url slug should be autogenerated. If this
        /// is selected then the user will not be shown the UrlSlug property
        /// and it will be auto-generated based on the title.
        /// </summary>
        public bool AutoGenerateUrlSlug => true;

        /// <summary>
        /// Indicates whether this custom entity should always be published when 
        /// saved, provided the user has permissions to do so. Useful if this isn't
        /// the sort of entity that needs a draft state workflow
        /// </summary>
        public bool AutoPublish => true;

        /// <summary>
        /// Indicates whether the entities are partitioned by locale
        /// </summary>
        public bool HasLocale => false;

        public CustomEntityQuerySortType DefaultSortType => CustomEntityQuerySortType.Title;

        public SortDirection DefaultSortDirection => SortDirection.Reversed;

        public CustomEntityOrdering Ordering => CustomEntityOrdering.Full;

        public Type AdminModuleMenuCategoryType => typeof(ContentAdminModuleMenuCategory);
    }
}