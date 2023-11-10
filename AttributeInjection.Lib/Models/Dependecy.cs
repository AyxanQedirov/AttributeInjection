using AttributeInjection.Lib.Attributes.Commons;
using AttributeInjection.Lib.Attributes.ForConretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Models
{
    public class Dependecy
    {
        public Type Abstract { get; set; }
        public Type Concrete { get; set; }
        public bool IsConcreteSetted
        {
            get
            {
                return Concrete is not null;
            }
        }
        public bool DoesHaveUseThisAttribute
        {
            get
            {
                return Concrete.CustomAttributes.Any(c => c.AttributeType == typeof(UseThis));
            }
        }
        public Action<IServiceCollection,Type,Type> AddDelegate { get; set; }
        public Dependecy()
        {

        }

        public Dependecy(Type @abstract, Action<IServiceCollection, Type, Type> addDelegate)
        {
            Abstract = @abstract;
            AddDelegate= addDelegate;
        }

    }
}
