using AttributeInjection.Lib.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AttributeInjection.Lib.Services.IoCContainerServices
{
    public interface IIoCContainerService
    {
        void AddDependenciesToIoCContainer(IServiceCollection services, List<Dependecy> dependecies);
    }
}
