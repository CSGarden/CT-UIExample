using System.Windows;
using System.Windows.Media;

namespace EffectExample.CustomShaowEffect.Common {
    /// <summary>
    /// 创建具有指定圆角和尺寸的几何图形
    /// </summary>
    public class GeometryCreator : FrameworkElement {
        /// <summary>
        /// 图形的圆角半径
        /// </summary>
        public CornerRadius CornerRadius {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        /// <summary>
        /// 图形的宽度
        /// </summary>
        public double GeometryHeight {
            get { return (double)GetValue(GeometryHeightProperty); }
            set { SetValue(GeometryHeightProperty, value); }
        }
        /// <summary>
        /// 图形的宽度
        /// </summary>
        public double GeometryWidth {
            get { return (double)GetValue(GeometryWidthProperty); }
            set { SetValue(GeometryWidthProperty, value); }
        }
        /// <summary>
        /// 生成的几何图形
        /// </summary>
        public Geometry Result {
            get { return (Geometry)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Result.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(Geometry), typeof(GeometryCreator), new PropertyMetadata(default(Geometry)));

        // Using a DependencyProperty as the backing store for GeometryWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GeometryWidthProperty =
            DependencyProperty.Register("GeometryWidth", typeof(double), typeof(GeometryCreator), new PropertyMetadata(default(double), OnGeometryWidthChanged));


        // Using a DependencyProperty as the backing store for GeometryHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GeometryHeightProperty =
            DependencyProperty.Register("GeometryHeight", typeof(double), typeof(GeometryCreator), new PropertyMetadata(default(double), OnGeometryHeightChanged));


        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(GeometryCreator), new PropertyMetadata(default(CornerRadius), OnCornerRadiusChanged));


        #region 相关方法

        /// <summary>
        ///     CornerRadius 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">CornerRadius 属性的旧值。</param>
        /// <param name="newValue">CornerRadius 属性的新值。</param>
        protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue) => MakeGeometry();

        /// <summary>
        ///     GeometryHeight 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">GeometryHeight 属性的旧值。</param>
        /// <param name="newValue">GeometryHeight 属性的新值。</param>
        protected virtual void OnGeometryHeightChanged(double oldValue, double newValue) => MakeGeometry();

        /// <summary>
        ///     GeometryWidth 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">GeometryWidth 属性的旧值。</param>
        /// <param name="newValue">GeometryWidth 属性的新值。</param>
        protected virtual void OnGeometryWidthChanged(double oldValue, double newValue) => MakeGeometry();

        private static void OnCornerRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var oldValue = (CornerRadius)args.OldValue;
            var newValue = (CornerRadius)args.NewValue;
            if (oldValue == newValue) {
                return;
            }

            var target = obj as GeometryCreator;
            target?.OnCornerRadiusChanged(oldValue, newValue);
        }

        private static void OnGeometryHeightChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue) {
                return;
            }

            var target = obj as GeometryCreator;
            target?.OnGeometryHeightChanged(oldValue, newValue);
        }

        private static void OnGeometryWidthChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
            var oldValue = (double)args.OldValue;
            var newValue = (double)args.NewValue;
            if (oldValue == newValue) {
                return;
            }

            var target = obj as GeometryCreator;
            target?.OnGeometryWidthChanged(oldValue, newValue);
        }
        /// <summary>
        /// 创建一个圆弧段
        /// </summary>
        /// <param name="point"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private ArcSegment CreateArcSegment(Point point, double radius) => new ArcSegment {
            Point = point,
            Size = new Size(radius, radius),
            IsLargeArc = false,
            SweepDirection = SweepDirection.Clockwise
        };
        /// <summary>
        ///  <see cref="创建几个图形"/>
        /// 通过使用PathFigure以及ArcSegment和LineSegment来描述图形的轮廓。
        /// 当CornerRadius、GeometryHeight或GeometryWidth属性发生更改时，对应的事件处理方法将被调用，然后调用MakeGeometry()方法重新生成几何图形
        /// </summary>
        private void MakeGeometry() {
            var figure = new PathFigure { IsClosed = true, StartPoint = new Point(0, CornerRadius.TopLeft) };
            figure.Segments.Add(CreateArcSegment(new Point(CornerRadius.TopLeft, 0), CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment { Point = new Point(GeometryWidth - CornerRadius.TopRight, 0) });
            figure.Segments.Add(CreateArcSegment(new Point(GeometryWidth, CornerRadius.TopRight),
                CornerRadius.TopLeft));
            figure.Segments.Add(new LineSegment {
                Point = new Point(GeometryWidth, GeometryHeight - CornerRadius.TopRight)
            });
            figure.Segments.Add(CreateArcSegment(new Point(GeometryWidth - CornerRadius.BottomRight, GeometryHeight),
                CornerRadius.BottomRight));
            figure.Segments.Add(new LineSegment { Point = new Point(CornerRadius.BottomLeft, GeometryHeight) });
            figure.Segments.Add(CreateArcSegment(new Point(0, GeometryHeight - CornerRadius.BottomLeft),
                CornerRadius.BottomLeft));
            var pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(figure);
            Result = pathGeometry;
        }
        #endregion

    }
}
