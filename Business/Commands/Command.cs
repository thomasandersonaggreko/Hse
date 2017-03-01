namespace Business.Commands
{
    using System;
    using System.Security.Principal;

    using LightInject;

    public abstract class Command
    {
        public virtual bool IsAuthorised(IPrincipal user)
        {
            return true;
        }

        public abstract CommandResult Execute(IPrincipal user);
    }

    public interface IQueryFactory
    {
        T GetQuery<T>();
    }

    public class QueryFactory : IQueryFactory
    {
        private IServiceContainer container;

        public QueryFactory(IServiceContainer container)
        {
            this.container = container;
        }

        public T GetQuery<T>() 
        {
            return this.container.GetInstance<T>();
            //return (T)createCommand();
        }
    }

    public interface ICommandFactory
    {
        T GetCommand<T>() where T : Command;
    }

    public class CommandFactory : ICommandFactory
    {
      private IServiceContainer container;

        public CommandFactory(IServiceContainer container)
        {
            this.container = container;
        }

        public T GetCommand<T>() where T : Command
        {
            return this.container.GetInstance<T>();
            //return (T)createCommand();
        }
    }
}