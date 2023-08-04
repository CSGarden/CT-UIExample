using System.Windows;
using System.Windows.Controls;

namespace EffectExample.Infrastructure {
    public class DemoPage : HeaderedContentControl {
        public DemoPage() {
            DefaultStyleKey = typeof(DemoPage);
            Style = App.Current.FindResource(DefaultStyleKey) as Style;
        }
    }
}
