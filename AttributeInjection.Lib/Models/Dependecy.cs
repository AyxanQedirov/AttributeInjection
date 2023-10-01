using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Models
{
    public class Dependecy
    {
        public Type Abstract { get; set; }
        public Type Concrete { get; set; }

        public Dependecy()
        {
                
        }

        public Dependecy(Type @abstract)
        {
            Abstract = @abstract;
        }
    }
}
