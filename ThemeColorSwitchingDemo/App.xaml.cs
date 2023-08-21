using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ThemeColorSwitchingDemo.Properties;

namespace ThemeColorSwitchingDemo {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application {
        //public static bool IsDarkThemeSelected { get; set; }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            //检测设置是否为暗色主题，如果是则应用暗色主题
            if (Settings.Default.IsDarkThemeSelected) {
                var darkTheme = new ResourceDictionary() {
                    Source = new Uri("pack://application:,,,/ThemeColorSwitchingDemo;component/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute)
                };
                Resources.MergedDictionaries[0] = darkTheme;
                Settings.Default.ThemeIndex = 1;
            } else {
                var darkTheme = new ResourceDictionary() {
                    Source = new Uri("pack://application:,,,/ThemeColorSwitchingDemo;component/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute)
                };
                Resources.MergedDictionaries[0] = darkTheme;
                Settings.Default.ThemeIndex = 0;
            }


        }

        protected override void OnExit(ExitEventArgs e) {
            Settings.Default.Save();
            base.OnExit(e);
        }
    }
}
