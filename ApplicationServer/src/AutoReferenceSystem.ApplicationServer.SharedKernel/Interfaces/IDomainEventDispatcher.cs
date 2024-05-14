namespace AutoReferenceSystem.ApplicationServer.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<IDomainObject> entities);
    }
}
