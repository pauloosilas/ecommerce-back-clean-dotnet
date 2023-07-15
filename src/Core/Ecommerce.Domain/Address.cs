using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Address: BaseDomainModel {
    
    public string? Location { get; set; }
    public string? City {get; set;}    
    public string? Departament {get; set;}    
    public string? PostalCode { get; set; }
    public string? Username {get; set;}
    public string? Country {get; set;}

}