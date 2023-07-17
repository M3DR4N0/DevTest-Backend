#nullable disable

using DevTestBackend;

namespace DevTestBackend.Entities.Results.Clients
{
    public interface IUpdateClientResult { }

    public class UpdateClientResult : IUpdateClientResult
    {
        public abstract class Base<T> : UpdateClientResult where T : new()
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
