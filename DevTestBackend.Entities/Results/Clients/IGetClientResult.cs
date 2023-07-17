using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.ViewModels.Clients;
using System.Collections;

#nullable disable

namespace DevTestBackend.Entities.Results.Clients
{
    public interface IGetClientResult { }

    public class GetClientResult : IGetClientResult
    {
        public abstract class Base<T> : GetClientResult where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public ClientViewModel Client { get; set; }
        }

        public sealed class ValidationError : Base<ValidationError>
        {
            public IEnumerable ValidationErrors { get; set; }
        }

        public sealed class Failed : Base<Failed>
        {
            public string Message { get; set; }
        }
    }
}
