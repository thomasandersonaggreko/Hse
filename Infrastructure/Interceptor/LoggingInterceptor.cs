namespace Infrastructure.Interceptor
{
    using System.Diagnostics;

    using Infrastructure.Logging;

    using LightInject.Interception;

    using Newtonsoft.Json;

    public class LoggingInterceptor : IInterceptor
    {
        public object Invoke(IInvocationInfo invocationInfo)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ILogger logger = InfrastructureContext.LogManager.GetLogger(invocationInfo.Method.ReturnType);
            logger.Debug(() => $"Started [{invocationInfo.Method.Name}] with [{JsonConvert.SerializeObject(invocationInfo.Arguments)}]");
            var returnValue = invocationInfo.Proceed();
            sw.Stop();
            logger.Debug(() => $"Finished [{invocationInfo.Method.Name}] with [{JsonConvert.SerializeObject(returnValue)}] in [{sw.Elapsed}]");
            return returnValue;
        }
    }
}