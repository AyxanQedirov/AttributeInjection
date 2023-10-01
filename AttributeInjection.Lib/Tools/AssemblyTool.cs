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

        public List<Assembly> GetAllProjectAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                string assemblyRootName = assembly.FullName.Split('.')[0];

                if (assemblyRootName == "System"
                    || assemblyRootName == "Microsoft"
                    || assemblyRootName == "Swashbuckle")
                    continue;

                assemblies.Add(assembly);
            }

            return assemblies;
        }
    }
}
