using AttributeInjection.Lib.Markers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApplicationAR:AssemblyRegistrator
    {
        public override void AddDependenciesManually(IServiceCollection services)
        {
            services.AddScoped<IManualService, ManualService>();
        }
    }
}
