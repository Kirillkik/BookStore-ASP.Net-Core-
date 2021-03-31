using System.Collections.Generic;

namespace Store.Contractors
{
    public interface IDeliveryService
    {
        string UniqueCode { get; }
        string Title { get; }
        Form CreateFrom(Order order);
        Form MoveNext(int orderId, int step, IReadOnlyDictionary<string, string> values);

    }
}
