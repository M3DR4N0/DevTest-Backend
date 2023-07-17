namespace DevTestBackend.Entities.ViewModels.Clients
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
