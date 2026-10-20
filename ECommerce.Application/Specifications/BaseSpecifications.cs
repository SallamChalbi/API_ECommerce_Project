using ECommerce.Domain.Common;
using ECommerce.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Application.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; private set; } = [];
        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        protected BaseSpecifications(Expression<Func<TEntity, bool>> criteria = null!)
        {
            Criteria = criteria;
        }

        public void AddInclude(Expression<Func<TEntity, object>> expression)
        {
            IncludeExpressions.Add(expression);
        }

        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public void AddOrderBy(Expression<Func<TEntity, object>>? expression)
             => OrderBy = expression;

        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }
        public void AddOrderByDesc(Expression<Func<TEntity, object>>? expression)
             => OrderByDesc = expression;
    }
}
