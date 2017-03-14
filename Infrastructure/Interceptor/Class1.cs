using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interceptor
{
    using System.Diagnostics;

    using Infrastructure.Logging;

    using LightInject.Interception;

    public class LoggingInterceptor : IInterceptor
    {
        public object Invoke(IInvocationInfo invocationInfo)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ILogger logger = InfrastructureContext.LogManager.GetLogger(invocationInfo.Method.ReturnType);
            // Perform logic before invoking the target method
            var returnValue = invocationInfo.Proceed();
            // Perform logic after invoking the target method
            sw.Stop();
            logger.Debug(() => sw.Elapsed.ToString());
            return returnValue;
        }
    }

    public class LoggingAsyncInterceptor : AsyncInterceptor
    {
        public LoggingAsyncInterceptor(IInterceptor targetInterceptor) : base(targetInterceptor)
        {
        }

        protected override async Task InvokeAsync(IInvocationInfo invocationInfo)
        {
            Stopwatch sw =Stopwatch.StartNew();
            ILogger logger = InfrastructureContext.LogManager.GetLogger(invocationInfo.Method.DeclaringType);
            // InterceptedTaskMethod = true;
            // Before method invocation
            await base.InvokeAsync(invocationInfo).ConfigureAwait(false);
            // After method invocation
            sw.Stop();
            logger.Debug(() => sw.Elapsed.ToString());
        }

        protected override async Task<T> InvokeAsync<T>(IInvocationInfo invocationInfo)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ILogger logger = InfrastructureContext.LogManager.GetLogger(invocationInfo.Method.ReturnType);
            // InterceptedTaskOfTMethod = true;
            // Before method invocation
            var value = await base.InvokeAsync<T>(invocationInfo).ConfigureAwait(false);
            // After method invocation     
            sw.Stop();
            logger.Debug(() => sw.Elapsed.ToString());
            return value;
        }
    }
}
