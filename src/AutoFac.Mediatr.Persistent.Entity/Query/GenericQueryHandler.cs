using AutoFac.Mediatr.Core;
using AutoFac.Mediatr.Core.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoFac.Mediatr.Persistent.Entity.Query
{
    public sealed class GenericQueryHandler<TEntity> :
       IAsyncRequestHandler<GenericQuery<TEntity>, IEnumerable<TEntity>>
       where TEntity : BaseEntity
    {
        public async Task<IEnumerable<TEntity>> Handle(GenericQuery<TEntity> message)
        {
            return await GetDataAsync().ConfigureAwait(false);
        }

        private Task<IEnumerable<TEntity>> GetDataAsync()
        {
            return Task.Run(() =>
            {
                IEnumerable<TEntity> list = new List<TEntity>(new[]
                {
                    Activator.CreateInstance<TEntity>()
                });
                return list;
            });
        }
    }
}