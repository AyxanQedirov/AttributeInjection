using AttributeInjection.Lib.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Services.AssemblyServices
{
    public interface IAssemblyService
    {
        List<Assembly> AssemblyRegistratorToAssembly(List<AssemblyRegistrator> assemblyRegistrators);
    }
}
