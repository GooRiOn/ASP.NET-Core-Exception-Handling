using System;
namespace ExceptionHandling.IoC
{
    public interface ICustomDependencyResolver
    {
        TResolved Resolve<TResolved>();
    }
}
