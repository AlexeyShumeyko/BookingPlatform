namespace BookingPlatform.Core.Contract
{
    public class Entity<TIdentifier> : IEntity
    {
        public TIdentifier? Id { get; set; }
    }
}
