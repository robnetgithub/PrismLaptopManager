using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismLaptopManager.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]

    public class RibbonTabAttribute : Attribute
    {
        public Type Type { get; private set; }

        public RibbonTabAttribute(Type ribbonType)
        {
            Type = ribbonType;
        }
    }
}
