using AttributeInjection.Lib.Attributes.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Extensions
{
    public static class TypeExtensions
    {
        public static bool DoesTypeHaveInjectorAttribute(this Type type)
        {
            foreach (var attribute in type.CustomAttributes)
            {

                if (attribute.AttributeType.BaseType == typeof(BaseInjector))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
