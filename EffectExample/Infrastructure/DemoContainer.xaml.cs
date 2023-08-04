using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EffectExample.Infrastructure {
    /// <summary>
    /// DemoContainer.xaml 的交互逻辑
    /// </summary>
    public partial class DemoContainer : UserControl {
        public DemoContainer(ExampleDefinition exampleDefinition) {
            InitializeComponent();
            ExampleDefinition = exampleDefinition;
            TitleElement.Text = exampleDefinition.ItemsName;
            DemoItemsElement.ItemsSource = exampleDefinition.Items;
            DemoItemsElement.SelectedItem = exampleDefinition.Items.FirstOrDefault();
        }
        public ExampleDefinition ExampleDefinition { get; }
        private void DemoItemsElement_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (DemoItemsElement.SelectedItem is ExampleDefinitionItem) {
                var exampleDefinitionItem = DemoItemsElement.SelectedItem as ExampleDefinitionItem;
                var demoItem = Activator.CreateInstance(exampleDefinitionItem.Control);
                ContentControl.Content = demoItem;
            }
        }
    }
}
