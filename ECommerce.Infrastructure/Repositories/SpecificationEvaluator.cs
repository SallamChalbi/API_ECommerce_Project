using ECommerce.Domain.Common;
using ECommerce.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositories
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> InputQuery, 
            ISpecifications<TEntity,TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var query = InputQuery;

            if (specifications.IncludeExpressions.Count > 0)
                query = specifications.IncludeExpressions.Aggregate(query, (current, expression) => current.Include(expression));

            if(specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);

            return query;
        }
    }
}
