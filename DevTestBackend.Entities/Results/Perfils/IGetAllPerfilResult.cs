using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.ViewModels.Perfils;

#nullable disable

namespace DevTestBackend.Entities.Results.Perfils
{
    public interface IGetAllPerfilResult {}

    public class GetAllPerfilResult : IGetAllPerfilResult
    {
        public abstract class Base<T> : GetAllPerfilResult where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public IEnumerable<PerfilViewModel> Perfils { get; set; } 
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
