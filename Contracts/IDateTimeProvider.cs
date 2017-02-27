namespace Contracts
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}