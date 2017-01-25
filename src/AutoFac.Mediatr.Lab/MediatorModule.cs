using Autofac;
using AutoFac.Mediatr.Core.Query;
using AutoFac.Mediatr.Persistent.Entity.Query;
using MediatR;
using System.Collections.Generic;
using System.Reflection;

namespace AutoFac.Mediatr.Lab
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GenericQuery<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequest<>))
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(GenericQuery<>)).As(typeof(IRequest<>));
            builder.RegisterGeneric(typeof(GenericQueryRequestHandler<>)).As(typeof(IRequestHandler<,>));
            builder.RegisterGeneric(typeof(GenericQueryHandler<>)).As(typeof(IAsyncRequestHandler<,>));

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t); ;
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });
        }
    }
}