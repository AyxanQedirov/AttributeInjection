using Application;
using AttributeInjection.Lib.Attributes.ForConretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    
    [UseThis]
    public class Test2Service : ITestService
    {
        public string GetName()
            => "Test2Service";
    }
}
