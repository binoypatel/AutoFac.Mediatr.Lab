using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoFac.Mediatr.Core.Query
{
    public sealed class GenericQuery<TEntity> : IRequest<IEnumerable<TEntity>>
    {
        public Expression<Func<TEntity, object>>[] IncludeProperties { get; set; }
        public Expression<Func<TEntity, bool>> Predicate { get; set; }
    }
}