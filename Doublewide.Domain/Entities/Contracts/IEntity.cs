namespace Doublewide.Domain.Entities.Contracts
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
