using AttributeInjection.Lib.Attributes.ForConretes;
using AttributeInjection.Lib.Models;
using System.Reflection;

namespace AttributeInjection.Lib.Services.DependencyServices
{
    public interface IDependencyService
    {
        IEnumerable<Dependecy> CollectAllAbstractsFromAssemblies(List<Assembly> assemblies);
        IEnumerable<Dependecy> FindDependenciesConcretesFromAssemblies(List<Dependecy> dependecies, List<Assembly> assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {

                    if (type.IsInterface is true)
                        continue;

                    bool doesTypeHasUseThisAttribute = type.CustomAttributes.Any(c => c.AttributeType == typeof(UseThis));

                    foreach (Dependecy dependecy in dependecies)
                    {
                        if (!type.IsAssignableTo(dependecy.Abstract))
                            continue;


                        if (dependecy.IsConcreteSetted && !dependecy.DoesHaveUseThisAttribute && !doesTypeHasUseThisAttribute)
                            throw new Exception($"There are multiple options for {dependecy.Abstract.Name}, you can use 'UseThis' attribute to choose implementation.");

                        if (dependecy.IsConcreteSetted && dependecy.DoesHaveUseThisAttribute && doesTypeHasUseThisAttribute)
                            throw new Exception($"There are multiple options for {dependecy.Abstract.Name}, you must use only one 'UseThis' attribute");

                        if (dependecy.IsConcreteSetted && dependecy.DoesHaveUseThisAttribute)
                            continue;

                        dependecy.Concrete = type;
                    }
                }
            }

            return dependecies;
        }
    }
}
