using System;
using ExceptionHandling.Common;
using ExceptionHandling.Exceptions;
using ExceptionHandling.IoC;
using System.Reflection;
using ExceptionHandling.ExceptionHandlers;

namespace ExceptionHandling.Executors
{
	public class ExceptionHandlerExecutor : IExceptionHandlerExecutor
	{
		private readonly ICustomDependencyResolver _customDependencyResolver;

		public ExceptionHandlerExecutor(ICustomDependencyResolver customDependencyResolver)
		{
			_customDependencyResolver = customDependencyResolver;
		}

		public IErrorResult Execute<TException>(TException exception) where TException : MyCustomException
			=> _customDependencyResolver.Resolve<IExceptionHandler<TException>>().Handle(exception);
	}
}
