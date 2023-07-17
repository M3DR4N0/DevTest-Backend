using DevTestBackend.Entities;
using DevTestBackend.Repository;
using DevTestBackend.Service.Clients;
using Microsoft.AspNetCore.Builder;

namespace DevTestBackend.Utils
{
    public static class WebApplicationExtension
    {
        public static void AddDecorators(this IServiceCollection services)
        {
            foreach (var repoType in typeof(GenericRepository<>).Assembly.ExportedTypes.Where(x => !x.IsGenericType))
            {
                var implementationType = repoType.GetInterfaces().FirstOrDefault(x => !x.IsGenericType);
                services.AddScoped(implementationType!, repoType);
            }

            foreach (var item in DecoratorService())
            {
                services.AddScoped(item.ImplemetedServices.Inner);
                services.AddScoped(item.ContractService, provider =>
                {
                    var inner = provider.GetService(item.ImplemetedServices.Inner)!;

                    // Validation
                    var toInvokeValidation = new List<object>() { inner };
                    var validationConstructor = item.ImplemetedServices.Validation.GetConstructors().FirstOrDefault();

                    foreach (var parameter in validationConstructor!.GetParameters())
                    {
                        if (parameter.ParameterType == item.ContractService) continue;
                        toInvokeValidation.Add(provider.GetService(parameter.ParameterType)!);
                    }

                    var validation = validationConstructor?.Invoke(toInvokeValidation.ToArray());

                    // Error
                    var toInvokeError = new List<object>() { validation! };
                    var errorConstructor = item.ImplemetedServices.Error.GetConstructors().FirstOrDefault();

                    foreach (var parameter in errorConstructor!.GetParameters())
                    {
                        if (parameter.ParameterType == item.ContractService) continue;
                        toInvokeError.Add(provider.GetService(parameter.ParameterType)!);
                    }

                    return errorConstructor?.Invoke(toInvokeError.ToArray())!;
                });
            }
        }

        private static IEnumerable<DecoratorStruct> DecoratorService()
        {
            var groups = typeof(ClientInnerService).Assembly.ExportedTypes.GroupBy(x => x.GetInterfaces()[0]);

            foreach (var group in groups)
            {
                yield return new DecoratorStruct
                {
                    ContractService = group.FirstOrDefault()?.GetInterfaces()[0]!,
                    ImplemetedServices = new ImplemetedServices
                    {
                        Inner = group.FirstOrDefault(p => p.Name.Contains("Inner"))!,
                        Validation = group.FirstOrDefault(p => p.Name.Contains("Validation"))!,
                        Error = group.FirstOrDefault(p => p.Name.Contains("Error"))!,
                    },
                };
            }
        }
    }
}
