using AttributeInjection.Lib.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Services.IoCContainerServices
{
    public class MicrosoftIoCContainerService:IIoCContainerService
    {
        public void AddDependenciesToIoCContainer(IServiceCollection services, List<Dependecy> dependecies)
        {

            foreach (Dependecy dependency in dependecies)
                services.AddScoped(dependency.Abstract, dependency.Concrete);
        }
    }
}
