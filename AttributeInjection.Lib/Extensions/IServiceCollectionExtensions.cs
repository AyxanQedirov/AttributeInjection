using AttributeInjection.Lib.Attributes.Commons;
using AttributeInjection.Lib.Attributes.ForAbstracts;
using AttributeInjection.Lib.Attributes.ForConretes;
using AttributeInjection.Lib.Markers;
using AttributeInjection.Lib.Models;
using AttributeInjection.Lib.Services.AssemblyServices;
using AttributeInjection.Lib.Services.DependencyServices;
using AttributeInjection.Lib.Services.IoCContainerServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace AttributeInjection.Lib.Extensions
{
    public static class IServiceCollectionExtensions
    {
        
        public static IServiceCollection AddAttributeInjection(this IServiceCollection services, params AssemblyRegistrator[] assemblyRegistrators)
        {
            IAssemblyService assemblyService=new AssemblyService();
            IDependencyService dependencyService =new DependencyServices();
            IIoCContainerService iocContainerService = new MicrosoftIoCContainerService();

            List<Assembly> assemblies = assemblyService.AssemblyRegistratorToAssembly(assemblyRegistrators.ToList());
            List<Dependecy> dependecies = dependencyService.FindDependenciesConcretesFromAssemblies(dependencyService.CollectAllAbstractsFromAssemblies(assemblies).ToList(), assemblies).ToList();
            iocContainerService
                .AddDependenciesToIoCContainer(services,dependecies)
                .AddDependenciesToIoCContainerFromAssemblyRegistratorRange(services,assemblyRegistrators);
            

            return services;
        }

        
        
     
        
    }
}
