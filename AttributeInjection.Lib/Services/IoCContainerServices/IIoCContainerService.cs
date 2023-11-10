using AttributeInjection.Lib.Markers;
using AttributeInjection.Lib.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AttributeInjection.Lib.Services.IoCContainerServices
{
    internal interface IIoCContainerService
    {
        IIoCContainerService AddDependenciesToIoCContainer(IServiceCollection services, List<Dependecy> dependecies);
        IIoCContainerService AddDependenciesToIoCContainerFromAssemblyRegistratorRange(IServiceCollection services,IEnumerable<AssemblyRegistrator> assemblyRegistrators);
    }
}
