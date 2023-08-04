using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectExample.Infrastructure {
    public class ExampleDefinition {
        public ExampleDefinition(string name, params ExampleDefinitionItem[] items) {
            ItemsName = name;
            Items = items;
        }
        public IEnumerable<ExampleDefinitionItem> Items { get; set; }
        public string ItemsName { get; set; }
        public override string ToString() {
            return ItemsName;
        }
    }
}
