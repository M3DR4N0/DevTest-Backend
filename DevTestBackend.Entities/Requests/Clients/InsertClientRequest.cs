#nullable disable

namespace DevTestBackend.Entities.Requests.Clients
{
    public class InsertClientRequest
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
