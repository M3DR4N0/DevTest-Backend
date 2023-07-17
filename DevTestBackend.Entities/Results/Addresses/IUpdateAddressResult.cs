#nullable disable

namespace DevTestBackend.Entities.Results.Addresses
{
    public interface IUpdateAddressResult { }

    public class UpdateAddressResult : IUpdateAddressResult
    {
        public abstract class Base<T> : UpdateAddressResult where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public string Message { get; set; }
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
