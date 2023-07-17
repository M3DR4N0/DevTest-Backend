#nullable disable

namespace DevTestBackend.Entities.Requests.Addresses
{
    public class UpdateAddressRequest 
    {
        public int AddressId { get; set; }

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public int ClientId { get; set; }
    }
}
