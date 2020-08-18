﻿using Cofoundry.Domain.Extendable;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain.Internal
{
    public class ContentRepositoryCustomEntityRepository
            : IContentRepositoryCustomEntityRepository
            , IExtendableContentRepositoryPart
    {
        private readonly ICustomEntityDefinitionRepository _customEntityDefinitionRepository;

        public ContentRepositoryCustomEntityRepository(
            IExtendableContentRepository contentRepository
            )
        {
            ExtendableContentRepository = contentRepository;
            _customEntityDefinitionRepository = contentRepository.ServiceProvider.GetRequiredService<ICustomEntityDefinitionRepository>();
        }

        public IExtendableContentRepository ExtendableContentRepository { get; }

        #region queries

        public IContentRepositoryCustomEntityGetByDefinitionQueryBuilder GetByDefinitionCode(string customEntityDefinitionCode)
        {
            return new ContentRepositoryCustomEntityGetByDefinitionQueryBuilder(ExtendableContentRepository, customEntityDefinitionCode);
        }

        public IContentRepositoryCustomEntityGetByDefinitionQueryBuilder GetByDefinition<TDefinition>() where TDefinition : ICustomEntityDefinition
        {
            var customEntityDefinition = _customEntityDefinitionRepository.Get<TDefinition>();

            if (customEntityDefinition == null)
            {
                throw new Exception("Custom Entity Definition not returned from ICustomEntityDefinitionRepository: " + typeof(TDefinition).FullName);
            }

            return new ContentRepositoryCustomEntityGetByDefinitionQueryBuilder(ExtendableContentRepository, customEntityDefinition.CustomEntityDefinitionCode);
        }

        public IContentRepositoryCustomEntityByIdQueryBuilder GetById(int customEntityId)
        {
            return new ContentRepositoryCustomEntityByIdQueryBuilder(ExtendableContentRepository, customEntityId);
        }

        public IContentRepositoryCustomEntityByIdRangeQueryBuilder GetByIdRange(IEnumerable<int> pageIds)
        {
            return new ContentRepositoryCustomEntityByIdRangeQueryBuilder(ExtendableContentRepository, pageIds);
        }

        public IContentRepositoryCustomEntitySearchQueryBuilder Search()
        {
            return new ContentRepositoryCustomEntitySearchQueryBuilder(ExtendableContentRepository);
        }
        
        #endregion

        #region child entities

        /// <summary>
        /// Custom entity definitions are used to define the identity and
        /// behavior of a custom entity type. This includes meta data such
        /// as the name and description, but also the configuration of
        /// features such as whether the identity can contain a locale
        /// and whether versioning (i.e. auto-publish) is enabled.
        /// </summary>
        public IContentRepositoryCustomEntityDefinitionsRepository Definitions()
        {
            return new ContentRepositoryCustomEntityDefinitionsRepository(ExtendableContentRepository);
        }

        #endregion
    }
}
