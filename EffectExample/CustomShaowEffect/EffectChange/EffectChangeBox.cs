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

namespace EffectExample.CustomShaowEffect.EffectChange
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EffectExample.CustomShaowEffect.EffectChange"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EffectExample.CustomShaowEffect.EffectChange;assembly=EffectExample.CustomShaowEffect.EffectChange"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:EffectChangeBox/>
    ///
    /// </summary>
    public class EffectChangeBox : ContentControl {
        public EffectChangeBox() {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(EffectChangeBox), new FrameworkPropertyMetadata(typeof(EffectChangeBox)));
            DefaultStyleKey = typeof(EffectChangeBox);
        }
        public double Blur {
            get { return (double)GetValue(BlurProperty); }
            set { SetValue(BlurProperty, value); }
        }
        public Color Color {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public CornerRadius CornerRadius {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public double Distance {
            get { return (double)GetValue(DistanceProperty); }
            set { SetValue(DistanceProperty, value); }
        }
        public double Intensity {
            get { return (double)GetValue(IntensityProperty); }
            set { SetValue(IntensityProperty, value); }
        }
        public EffectChangeLightSource LightSource {
            get { return (EffectChangeLightSource)GetValue(LightSourceProperty); }
            set { SetValue(LightSourceProperty, value); }
        }
        public EffectChangeShape Shape {
            get { return (EffectChangeShape)GetValue(ShapeProperty); }
            set { SetValue(ShapeProperty, value); }
        }
        public EffectChangeBoxTemplateSettings TemplateSettings {
            get { return (EffectChangeBoxTemplateSettings)GetValue(TemplateSettingsProperty); }
            set { SetValue(TemplateSettingsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TemplateSettings.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TemplateSettingsProperty =
            DependencyProperty.Register("TemplateSettings", typeof(EffectChangeBoxTemplateSettings), typeof(EffectChangeBox), new PropertyMetadata(null));


        // Using a DependencyProperty as the backing store for Shape.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShapeProperty =
            DependencyProperty.Register("Shape", typeof(EffectChangeShape), typeof(EffectChangeBox), new PropertyMetadata(EffectChangeShape.Flat, OnShapeChanged));


        // Using a DependencyProperty as the backing store for LightSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LightSourceProperty =
            DependencyProperty.Register("LightSource", typeof(EffectChangeLightSource), typeof(EffectChangeBox), new PropertyMetadata(default(EffectChangeLightSource), OnLightSourceChanged));


        // Using a DependencyProperty as the backing store for Intensity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IntensityProperty =
            DependencyProperty.Register("Intensity", typeof(double), typeof(EffectChangeBox), new PropertyMetadata(0.15d, OnIntensityChanged));


        // Using a DependencyProperty as the backing store for Distance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DistanceProperty =
            DependencyProperty.Register("Distance", typeof(double), typeof(EffectChangeBox), new PropertyMetadata(20d, OnDistanceChanged));


        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(EffectChangeBox), new PropertyMetadata(new CornerRadius(50)));


        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(EffectChangeBox), new PropertyMetadata(default(Color), OnColorChanged));


        // Using a DependencyProperty as the backing store for Blur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlurProperty =
            DependencyProperty.Register("Blur", typeof(double), typeof(EffectChangeBox), new PropertyMetadata(60d, OnBlurChanged));

        private bool _hasApplyTemplate;
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            _hasApplyTemplate = true;
            UpdateTemplateSettings();
        }

        /// <summary>
        ///     Blur 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Blur 属性的旧值。</param>
        /// <param name="newValue">Blur 属性的新值。</param>
        protected virtual void OnBlurChanged(double oldValue, double newValue) => UpdateTemplateSettings();

        /// <summary>
        ///     Color 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Color 属性的旧值。</param>
        /// <param name="newValue">Color 属性的新值。</param>
        protected virtual void OnColorChanged(Color oldValue, Color newValue) => UpdateTemplateSettings();

        /// <summary>
        ///     Distance 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Distance 属性的旧值。</param>
        /// <param name="newValue">Distance 属性的新值。</param>
        protected virtual void OnDistanceChanged(double oldValue, double newValue) => UpdateTemplateSettings();

        /// <summary>
        ///     Intensity 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Intensity 属性的旧值。</param>
        /// <param name="newValue">Intensity 属性的新值。</param>
        protected virtual void OnIntensityChanged(double oldValue, double newValue) => UpdateTemplateSettings();

        /// <summary>
        ///     LightSource 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">LightSource 属性的旧值。</param>
        /// <param name="newValue">LightSource 属性的新值。</param>
        protected virtual void
            OnLightSourceChanged(EffectChangeLightSource oldValue, EffectChangeLightSource newValue) =>
            UpdateTemplateSettings();

        /// <summary>
        ///     Shape 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">Shape 属性的旧值。</param>
        /// <param name="newValue">Shape 属性的新值。</param>
        protected virtual void OnShapeChanged(EffectChangeShape oldValue, EffectChangeShape newValue) =>
            UpdateTemplateSettings();

        private static void OnBlurChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var target = obj as EffectChangeBox;
            target?.OnBlurChanged((double)args.OldValue, (double)args.NewValue);
        }

        private static void OnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var target = obj as EffectChangeBox;
            target?.OnColorChanged((Color)args.OldValue, (Color)args.NewValue);
        }

        private static void OnDistanceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var target = obj as EffectChangeBox;
            target?.OnDistanceChanged((double)args.OldValue, (double)args.NewValue);
        }

        private static void OnIntensityChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var target = obj as EffectChangeBox;
            target?.OnIntensityChanged((double)args.OldValue, (double)args.NewValue);
        }

        private static void OnLightSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var target = obj as EffectChangeBox;
            target?.OnLightSourceChanged((EffectChangeLightSource)args.OldValue,
                (EffectChangeLightSource)args.NewValue);
        }

        private static void OnShapeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var target = obj as EffectChangeBox;
            target?.OnShapeChanged((EffectChangeShape)args.OldValue, (EffectChangeShape)args.NewValue);
        }

        private void UpdateTemplateSettings() {
            if (_hasApplyTemplate == false) {
                return;
            }

            TemplateSettings =
                new EffectChangeBoxTemplateSettings(Color, Distance, Intensity, Blur, Shape, LightSource);
        }
    }
}
