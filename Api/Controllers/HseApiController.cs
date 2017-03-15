namespace Api.Controllers
{
    using System.Linq;
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
            command.ExecutingUser = this.User;
            CommandResult commandResult = await InfrastructureContext.Bus.RequestAsync<T, CommandResult>(command).ConfigureAwait(false);

            switch (commandResult.CommandResultReason)
            {
                case CommandResultReason.Successful:
                    return this.Ok();
                case CommandResultReason.NotAuthorised:
                    return this.Unauthorized();
                case CommandResultReason.ValidationErrors:
                    return this.BadRequest(commandResult.ValidationErrors.ToJson());
                default:
                    return this.InternalServerError();
            }
        }

        /// <summary>
        /// Executes the query single.
        /// </summary>
        /// <typeparam name="T">The query type</typeparam>
        /// <typeparam name="TR">The type of the r.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The HTTP action result
        /// </returns>
        protected Task<IHttpActionResult> ExecuteQueryList<T, TR>(T query) where T : IRequest, IRequest<QueryResult<TR>>
        {
            return this.ExecuteQuery<T, TR>(query, true);
        }

        /// <summary>
        /// Executes the query single.
        /// </summary>
        /// <typeparam name="T">The query type</typeparam>
        /// <typeparam name="TR">The type of the r.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>
        /// The HTTP action result
        /// </returns>
        protected Task<IHttpActionResult> ExecuteQuerySingle<T, TR>(T query) where T : IRequest, IRequest<QueryResult<TR>>
        {
            return this.ExecuteQuery<T, TR>(query, false);
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T">the type of query</typeparam>
        /// <typeparam name="TR">The type of the r.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="list">if set to <c>true</c> [list].</param>
        /// <returns>The HTTP action result</returns>
        private async Task<IHttpActionResult> ExecuteQuery<T, TR>(T query, bool list) where T : IRequest, IRequest<QueryResult<TR>>
        {
            query.ExecutingUser = this.User;
            QueryResult<TR> queryResult = await InfrastructureContext.Bus.RequestAsync<T, QueryResult<TR>>(query).ConfigureAwait(false);

            switch (queryResult.QueryResultReason)
            {
                case QueryResultReason.Successful:
                    if (list)
                    {
                        return this.Ok(queryResult.List);
                    }

                    return this.Ok(queryResult.List.FirstOrDefault());
                case QueryResultReason.NotAuthorised:
                    return this.Unauthorized();
                default:
                    return this.InternalServerError();
            }
        }
    }
}