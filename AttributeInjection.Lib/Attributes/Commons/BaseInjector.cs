using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Attributes.Commons
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class BaseInjector : Attribute
    {
    }
}
