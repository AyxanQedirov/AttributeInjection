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
        public static bool DoesTypeHaveInjectorAttribute(this Type type,out BaseInjector findedInector)
        {
            findedInector = null;
            foreach (var attribute in type.CustomAttributes)
            {

                if (attribute.AttributeType.BaseType == typeof(BaseInjector))
                {
                    
                    findedInector = Activator.CreateInstance(attribute.AttributeType) as BaseInjector;
                    return true;
                }
            }

            return false;
        }
    }
}
