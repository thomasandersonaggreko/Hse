namespace MessageBus
{
    using System.Security.Principal;

    /// <summary>
    /// Marker interface to represent a request with a void response
    /// </summary>
    public interface IRequest
    {
        IPrincipal ExecutingUser { get; set; }
    }

    /// <summary>
    /// Marker interface to represent a request with a response
    /// </summary>
    /// <typeparam name="TResponse">Response type</typeparam>
    public interface IRequest<out TResponse> : IRequest
    {
    }
}