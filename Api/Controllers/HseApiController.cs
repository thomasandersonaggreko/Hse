namespace Api.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Business.Sdk;

    using Contracts;

    using Infrastructure;
    using Infrastructure.MessageBus;

    /// <summary>
    /// The HSE API controller.
    /// </summary>
    public abstract class HseApiController : ApiController
    {
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <typeparam name="T">The type of command</typeparam>
        /// <param name="command">The command.</param>
        /// <returns>The HTTP action result</returns>
        protected async Task<IHttpActionResult> Execute<T>(T command) where T : IRequest, IRequest<CommandResult>
        {
            CommandResult commandResult = await InfrastructureContext.Bus.RequestAsync<T, CommandResult>(command).ConfigureAwait(false);

            switch (commandResult.CommandResultReason)
            {
                case CommandResultReason.Successful:
                    return this.Ok();
                case CommandResultReason.NotAuthorised:
                    return this.Unauthorized();
                case CommandResultReason.ValidationErrors:
                    return this.BadRequest(commandResult.ValidationErrors.ToJson());
                case CommandResultReason.UnexpectedError:
                    return this.InternalServerError();
                default:
                    return this.Ok();
            }
        }
    }
}