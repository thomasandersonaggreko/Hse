namespace Business.Commands
{
    /// <summary>
    /// The CommandFactory interface.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <typeparam name="T">The command type</typeparam>
        /// <returns>The command</returns>
        T GetCommand<T>() where T : Command;
    }
}