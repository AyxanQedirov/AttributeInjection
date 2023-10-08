using Application;
using AttributeInjection.Lib.Attributes.ForConretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TestService : ITestService
    {
        public string GetName()
        {
            return "TestService";
        }
    }
}
