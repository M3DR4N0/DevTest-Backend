using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTestBackend.Entities.Models;

[Table("Address")]
public class Address
{
    [Key]
    public int AddressId { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
