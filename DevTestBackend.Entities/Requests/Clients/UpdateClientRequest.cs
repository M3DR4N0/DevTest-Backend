#nullable disable

namespace DevTestBackend.Entities.Requests.Clients
{
    public class UpdateClientRequest 
    {
        public int ClientId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
