using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectExample.Infrastructure {
    public class ExampleDefinitionItem {
        public ExampleDefinitionItem(string name,Type control) {
            Name = name;
            Control = control;
        }
        public Type Control { get; set; }
        public string Name { get; set; }
    }
}
