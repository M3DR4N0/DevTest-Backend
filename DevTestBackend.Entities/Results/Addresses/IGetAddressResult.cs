using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.ViewModels.Addresses;

#nullable disable

namespace DevTestBackend.Entities.Results.Addresses
{
    public interface IGetAddressResult { }

    public class GetAddressResult : IGetAddressResult
    {
        public abstract class Base<T> : GetAddressResult where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public AddressViewModel Address { get; set; }
        }

        public sealed class ValidationError : Base<ValidationError>
        {
            public IDictionary<string, string> ValidationErrors { get; set; }
        }

        public sealed class Failed : Base<Failed>
        {
            public string Message { get; set; }
        }
    }
}
