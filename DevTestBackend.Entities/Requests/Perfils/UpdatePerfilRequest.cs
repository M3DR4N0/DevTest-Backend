#nullable disable

namespace DevTestBackend.Entities.Requests.Perfils
{
    public class UpdatePerfilRequest 
    {
        public int PerfilId { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }
    }
}
