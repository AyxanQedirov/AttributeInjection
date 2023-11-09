using AttributeInjection.Lib.Attributes.ForConretes;
using AttributeInjection.Lib.Extensions;
using AttributeInjection.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Services.DependencyServices
{
    public class DependencyServices:IDependencyService
    {
        public  IEnumerable<Dependecy> CollectAllAbstractsFromAssemblies(List<Assembly> assemblies)
        {
            List<Dependecy> dependencies= new List<Dependecy>();

            foreach (Assembly assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {

                    if (type.IsInterface is false)
                        continue;

                    if (type.DoesTypeHaveInjectorAttribute() is false)
                        continue;

                    dependencies.Add(new Dependecy(type));
                }
            }
            return dependencies;
        }
        public  IEnumerable<Dependecy> FindDependenciesConcretesFromAssemblies(List<Dependecy> dependecies, List<Assembly> assemblies)
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
