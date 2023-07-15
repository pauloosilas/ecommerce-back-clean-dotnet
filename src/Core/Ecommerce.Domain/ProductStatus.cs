using System.Runtime.Serialization;

namespace Ecommerce.Domain;

public enum ProductStatus {
    [EnumMember(Value = "inactive product")]
    Inactive,

    [EnumMember(Value = "Active product")]
    Active
}