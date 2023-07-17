﻿using DevTestBackend.Entities.Models;

#nullable disable

namespace DevTestBackend.Entities.Results.Perfils
{
    public interface IDeletePerfilResult { }

    public class DeletePerfilResult : IDeletePerfilResult
    {
        public abstract class Base<T> : DeletePerfilResult where T : new()
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
