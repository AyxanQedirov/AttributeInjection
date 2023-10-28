using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Attributes.Commons
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public abstract class BaseInjector : Attribute
    {
        public abstract  void Add(IServiceCollection services,Type @abstract,Type concrete);
    }
}
