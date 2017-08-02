using System;
using Autofac;

namespace ExceptionHandling.IoC
{
    public class CustomDependencyResolver : ICustomDependencyResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CustomDependencyResolver(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public TResolved Resolve<TResolved>()
            => _lifetimeScope.Resolve<TResolved>();
    }
}
