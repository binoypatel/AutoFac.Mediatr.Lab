using AutoFac.Mediatr.Core;
using AutoFac.Mediatr.Core.Query;
using MediatR;
using System;
using System.Collections.Generic;

namespace AutoFac.Mediatr.Persistent.Entity.Query
{
    public sealed class GenericQueryRequestHandler<TEntity> :
       IRequestHandler<GenericQuery<TEntity>, IEnumerable<TEntity>>
       where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> Handle(GenericQuery<TEntity> message)
        {
            return GetData();
        }

        private IEnumerable<TEntity> GetData()
        {
            IEnumerable<TEntity> list = new List<TEntity>(new[]
                {
                    Activator.CreateInstance<TEntity>()
                });
            return list;
        }
    }
}