namespace DevTestBackend.Entities.ViewModels.Addresses
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string ClientName { get; set; } = null!;
    }
}
