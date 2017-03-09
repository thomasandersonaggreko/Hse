namespace Business.Events
{
    using Business.Commands;

    using HSEModel;

    /// <summary>
    /// The close high potential incident event.
    /// </summary>
    public class CloseHighPotentialIncidentEvent : BusinessEvent<HighPotentialIncident>
    {
    }
}