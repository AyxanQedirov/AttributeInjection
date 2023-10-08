using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Markers
{
    public class AssemblyRegistrator
    {
        public Assembly GetAssembly()
            =>this.GetType().Assembly;
    }
}
