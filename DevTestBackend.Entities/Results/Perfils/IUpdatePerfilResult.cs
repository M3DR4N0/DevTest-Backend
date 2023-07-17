#nullable disable

namespace DevTestBackend.Entities.Results.Perfils
{
    public interface IUpdatePerfilResult { }

    public class UpdatePerfilResult : IUpdatePerfilResult
    {
        public abstract class Base<T> : UpdatePerfilResult where T : new()
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
