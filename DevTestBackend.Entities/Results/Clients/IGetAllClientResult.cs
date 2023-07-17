using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.ViewModels.Clients;

#nullable disable

namespace DevTestBackend.Entities.Results.Clients
{
    public interface IGetAllClientResult { }

    public class GetAllClientResult : IGetAllClientResult
    {
        public abstract class Base<T> : GetAllClientResult where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public IEnumerable<ClientViewModel> Clients { get; set; }
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
