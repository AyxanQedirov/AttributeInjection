using AttributeInjection.Lib.Markers;
using AttributeInjection.Lib.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Services.IoCContainerServices
{
    internal class MicrosoftIoCContainerService : IIoCContainerService
    {
        public IIoCContainerService AddDependenciesToIoCContainer(IServiceCollection services, List<Dependecy> dependecies)
        {

            foreach (Dependecy dependency in dependecies)
                dependency.AddDelegate.Invoke(services, dependency.Abstract, dependency.Concrete);


            return this;

        }

        public IIoCContainerService AddDependenciesToIoCContainerFromAssemblyRegistratorRange(IServiceCollection services, IEnumerable<AssemblyRegistrator> assemblyRegistrators)
        {
            foreach (AssemblyRegistrator assemblyRegistrator in assemblyRegistrators)
                assemblyRegistrator.AddDependenciesManually(services);

            return this;
        }
    }
}
