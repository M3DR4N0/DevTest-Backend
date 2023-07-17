using DevTestBackend.Entities.Models;
using System.Collections;

#nullable disable

namespace DevTestBackend.Entities.Results.Clients
{
    public interface IDeleteClientResult { }

    public class DeleteClientResult : IDeleteClientResult
    {
        public abstract class Base<T> : DeleteClientResult where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public string Message { get; set; }
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
