using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeInjection.Lib.Proxies
{

    public class AttributeInterceptor : Attribute, IInterceptor
    {
        private int _priority;
        public int Priority { get { return _priority; } set { _priority = value; } }

        public AttributeInterceptor(int priority) { 
            Priority= priority; 
        }
        public virtual void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
