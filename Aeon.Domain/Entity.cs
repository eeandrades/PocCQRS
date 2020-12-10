namespace Aeon.Domain
{
    public abstract class Entity<TID>
    {
        public TID Id { get; init; }
    }
}
