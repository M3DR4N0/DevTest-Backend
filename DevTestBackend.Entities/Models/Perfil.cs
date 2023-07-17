using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTestBackend.Entities.Models;

[Table("Perfil")]
public class Perfil
{
    [Key]
    public int PerfilId { get; set; }

    public string Description { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
