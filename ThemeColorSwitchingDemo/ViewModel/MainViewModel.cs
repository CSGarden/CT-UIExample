using GalaSoft.MvvmLight;
using System;
using System.Windows;
using ThemeColorSwitchingDemo.Properties;

namespace ThemeColorSwitchingDemo.ViewModel {
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {
            ThemIndex = Settings.Default.ThemeIndex;
        }

        private int themIndex;
        public int ThemIndex {
            get {
                return themIndex;
            }
            set {
                Set(ref themIndex, value);
                if (value == 1) {
                    Settings.Default.IsDarkThemeSelected = true;
                    ChangedTheme("Dark");
                } else if (value == 0) {
                    Settings.Default.IsDarkThemeSelected = false;
                    ChangedTheme("Light");
                }
            }
        }

        private void ChangedTheme(string themeName) {
            ResourceDictionary newTheme = new ResourceDictionary();
            var test = string.Format("{0}{1}{2}", "pack://application:,,,/ThemeColorSwitchingDemo;component/Themes/", themeName, "Theme.xaml");
            newTheme.Source = new Uri(test, UriKind.RelativeOrAbsolute);
            // 替换当前资源字典
            //ResourceDictionary oldTheme = Application.Current.Resources.MergedDictionaries[2];
            //Application.Current.Resources.MergedDictionaries.Remove(oldTheme);
            Application.Current.Resources.MergedDictionaries[0] = newTheme;
        }

    }
}