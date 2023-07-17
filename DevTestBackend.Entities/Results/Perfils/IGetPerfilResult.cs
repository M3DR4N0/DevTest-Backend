using DevTestBackend.Entities.Models;
using DevTestBackend.Entities.ViewModels.Perfils;

#nullable disable

namespace DevTestBackend.Entities.Results.Perfils
{
    public interface IGetPerfilResult {}

    public class GetPerfilResult : IGetPerfilResult
    {
        public abstract class Base<T> : GetPerfilResult where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success> 
        {
            public PerfilViewModel Perfil { get; set; } 
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
