using AttributeInjection.Lib.Attributes.ForConretes;
using AttributeInjection.Lib.Models;
using System.Reflection;

namespace AttributeInjection.Lib.Services.DependencyServices
{
    public interface IDependencyService
    {
        IEnumerable<Dependecy> CollectAllAbstractsFromAssemblies(List<Assembly> assemblies);
        IEnumerable<Dependecy> FindDependenciesConcretesFromAssemblies(List<Dependecy> dependecies, List<Assembly> assemblies);
        
    }
}
