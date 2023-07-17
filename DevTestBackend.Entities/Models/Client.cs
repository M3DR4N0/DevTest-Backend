using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTestBackend.Entities.Models;

[Table("Client")]
public class Client
{
    [Key]
    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Perfil> Perfils { get; set; } = new List<Perfil>();
}
