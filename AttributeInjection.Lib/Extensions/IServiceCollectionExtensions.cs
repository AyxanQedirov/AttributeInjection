using AttributeInjection.Lib.Tools;
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

        public static IServiceCollection AddAttributeInjection(this IServiceCollection services)
        {
            AssemblyTool assemblyTool= new AssemblyTool();
            List<Assembly> assemblies= assemblyTool.GetAllProjectAssemblies();

            return services;
        }
    }
}
