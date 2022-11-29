using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> condition)
        {
            Condition = condition;
        }

        public Expression<Func<T, bool>> Condition { get; }

        public List<Expression<Func<T, object>>> Values { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Values.Add(include);
        }
    }
}
