using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class ShoppingCartItem : BaseDomainModel {
    public string? Product {get; set;}

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price {get; set;}

    public int Amount {get; set;}

    public string? Image{get; set;}
    public string? Category {get; set;}

    public Guid? ShoppingCartMasterId {get; set;}

    public int ShoppingCarId {get; set;}
    public virtual ShoppingCart? ShoppingCart {get; set;}
    public int ProductId {get; set;}
    public int Stock { get; set; }
}