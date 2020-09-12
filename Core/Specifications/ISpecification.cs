using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
         Expression<Func<T, bool>> Criteria {get; } // checks against the criteria
         List<Expression<Func<T, object>>> Includes {get; } // checks for all includes appended

         // for sorting
         Expression<Func<T, object>> OrderBy {get; }
         Expression<Func<T, object>> OrderByDescending {get; }

         // for pagination
         int Take {get;}
         int Skip {get;}
         bool IsPagingEnabled {get;}
    }
}