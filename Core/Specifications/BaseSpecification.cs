using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        // checks against the criteria
        public Expression<Func<T, bool>> Criteria {get; } 

        // checks for all includes appended
        public List<Expression<Func<T, object>>> Includes {get; } = 
            new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        // method to add the includes
        protected void AddInclude(Expression<Func<T, object>> includeExpresion)
        {
            Includes.Add(includeExpresion);
        }

        // methods for sorting
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }
}