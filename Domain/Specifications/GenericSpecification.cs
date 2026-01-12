using Ardalis.Specification;
using System.Linq.Expressions;

namespace SiniestrosVialesOpitech.Domain.Specifications
{
    public class GenericSpecification<TEntity> : Specification<TEntity> where TEntity : class
    {
        public GenericSpecification(Expression<Func<TEntity, bool>> condicionWhere)
        {
            Query.Where(condicionWhere);
        }

        // Método para incluir una relación
        public GenericSpecification<TEntity> AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Query.Include(includeExpression);
            return this;
        }

        // Método para incluir una relación de una relación
        public GenericSpecification<TEntity> AddThenInclude<TProperty, TThenProperty>(
            Expression<Func<TEntity, IEnumerable<TProperty>>> includeExpression,
            Expression<Func<TProperty, TThenProperty>> thenIncludeExpression)
        {
            Query.Include(includeExpression).ThenInclude(thenIncludeExpression);
            return this;
        }


        // Método único para ordenar por string y dirección
        public GenericSpecification<TEntity> OrderBy(string propertyName, string direction = "desc")
        {
            Query.OrderBy(propertyName, direction);
            return this;
        }
    }
}