using System.Runtime.Serialization;

namespace Ecommerce.Domain;

public enum OrderStatus {
    [EnumMember(Value = "Pending")]
    Pending,

    [EnumMember(Value = "Payment received")]
    Completed,

    [EnumMember(Value = "Sent to customer")]
    Send,
    [EnumMember(Value = "Payment Error")]
    Error
}