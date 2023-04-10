using System.Runtime.Serialization;

namespace Core.Entities.OrderAggregates
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived,
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed,
        [EnumMember(Value = "OrderShipped")]
        OrderShipped,
        [EnumMember(Value = "OrderCancelled")]
        OrderCancelled
    }
}
