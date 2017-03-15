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

    using Newtonsoft.Json;

    public class LoggingAsyncInterceptor : AsyncInterceptor
    {
        public LoggingAsyncInterceptor(IInterceptor targetInterceptor) : base(targetInterceptor)
        {
        }

        protected override async Task InvokeAsync(IInvocationInfo invocationInfo)
        {
            Stopwatch sw =Stopwatch.StartNew();
            ILogger logger = InfrastructureContext.LogManager.GetLogger(invocationInfo.Proxy.Target.GetType());

            logger.Debug(() => $"Started [{invocationInfo.Method.Name}] with [{JsonConvert.SerializeObject(invocationInfo.Arguments)}]");

            await base.InvokeAsync(invocationInfo).ConfigureAwait(false);
            // After method invocation
            sw.Stop();
            logger.Debug(() => $"Finished [{invocationInfo.Method.Name}] in [{sw.Elapsed}]");
        }

        protected override async Task<T> InvokeAsync<T>(IInvocationInfo invocationInfo)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ILogger logger = InfrastructureContext.LogManager.GetLogger(invocationInfo.Proxy.Target.GetType());
            
            logger.Debug(() => $"Started [{invocationInfo.Method.Name}] with [{JsonConvert.SerializeObject(invocationInfo.Arguments)}]");

            var value = await base.InvokeAsync<T>(invocationInfo).ConfigureAwait(false);
    
            sw.Stop();

            logger.Debug(() => $"Finished [{invocationInfo.Method.Name}] with [{JsonConvert.SerializeObject(value)}] in [{sw.Elapsed}]");
            return value;
        }
    }
}
