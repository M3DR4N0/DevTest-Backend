using DevTestBackend.Entities.Models;

#nullable disable

namespace DevTestBackend.Entities.Results.Clients
{
    public interface IInsertClientResult { }

    public class InsertClientResult : IInsertClientResult
    {
        public abstract class Base<T> : InsertClientResult where T : new()
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
