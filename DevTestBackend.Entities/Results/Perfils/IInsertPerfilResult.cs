using DevTestBackend.Entities.Models;

#nullable disable

namespace DevTestBackend.Entities.Results.Perfils
{
    public interface IInsertPerfilResult { }

    public class InsertPerfilResult : IInsertPerfilResult
    {
        public abstract class Base<T> : InsertPerfilResult where T : new()
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
