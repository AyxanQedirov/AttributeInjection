using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Tools
{
    public class AssemblyTool
    {
        public List<Assembly> GetAllAssembliesWhichUseThisLib()
        {
            List<Assembly> assemblies = new List<Assembly>();

            string libraryAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            Assembly[] allAssemblies=AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in allAssemblies)
            {
                AssemblyName[] referencedAssemblies=assembly.GetReferencedAssemblies();

                if (referencedAssemblies.Any(r => r.Name == libraryAssemblyName) is false)
                    continue;

                assemblies.Add(assembly);

            }

            return assemblies;
        }

    }
}
