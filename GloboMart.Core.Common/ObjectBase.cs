using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Core.Common
{
    public abstract class ObjectBase
    {
        public static CompositionContainer Container { get; set; }
    }
}
