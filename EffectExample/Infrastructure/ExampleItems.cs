using EffectExample.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectExample.Infrastructure {
    public class ExampleItems {
        public static List<ExampleDefinition> Examples { get; set; } = new List<ExampleDefinition> {
            new ExampleDefinition("WPF中自带阴影效果",
                new ExampleDefinitionItem("单独的Blur效果",typeof(SimpleBlurPage)),
                new ExampleDefinitionItem("DropShadow效果",typeof(SimpleDropShadowEffectPage))
                ),
            new ExampleDefinition("自定义阴影效果",
                new ExampleDefinitionItem("自定义阴影效果",typeof(EffectChangePanel)))
        };
    }
}
