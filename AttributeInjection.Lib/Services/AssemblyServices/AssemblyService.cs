using AttributeInjection.Lib.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Services.AssemblyServices
{
    public class AssemblyService:IAssemblyService
    {
        public List<Assembly> AssemblyRegistratorToAssembly(List<AssemblyRegistrator> assemblyRegistrators)
        {
            List<Assembly> result = new();

            foreach (var ar in assemblyRegistrators)
            {
                result.Add(ar.GetAssembly());
            }

            return result;
        }
    }
}
