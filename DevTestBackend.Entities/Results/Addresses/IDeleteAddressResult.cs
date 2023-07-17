using DevTestBackend.Entities.Models;

#nullable disable

namespace DevTestBackend.Entities.Results.Addresses
{
    public interface IDeleteAddressResult { }

    public class DeleteAddressResult : IDeleteAddressResult
    {
        public abstract class Base<T> : DeleteAddressResult where T : new()
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
