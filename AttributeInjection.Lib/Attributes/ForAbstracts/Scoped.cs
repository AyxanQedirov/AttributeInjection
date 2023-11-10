using AttributeInjection.Lib.Attributes.Commons;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Attributes.ForAbstracts
{
    public class Scoped : BaseInjector
    {
        public override void Add(IServiceCollection services, Type @abstract, Type concrete)
            => services.AddScoped(@abstract, concrete);
    }
}
