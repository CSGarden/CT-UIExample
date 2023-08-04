using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Media;
using EffectExample.CustomShaowEffect.Common;
using System.Windows;

namespace EffectExample.CustomShaowEffect.EffectChange
{
    public class EffectChangeBoxTemplateSettings {
        public EffectChangeBoxTemplateSettings(Color color, double distance, double intensity, double blurRadius,
           EffectChangeShape shape, EffectChangeLightSource lightSource) {
            Background = CreateBackground(color, shape, lightSource);

            var darkColor = ColorHelper.ColorWithLuminance(color, intensity * -1);
            var lightColor = ColorHelper.ColorWithLuminance(color, intensity);

            var newDarkColor = new Color();
            newDarkColor.ScR = darkColor.R;
            newDarkColor.ScG = darkColor.G;
            newDarkColor.ScB = darkColor.B;

            var newLightColor = new Color();
            newLightColor.ScR = lightColor.R;
            newLightColor.ScG = lightColor.G;
            newLightColor.ScB = lightColor.B;

            double lightDirection = 0;
            switch (lightSource) {
                case EffectChangeLightSource.TopLeft:
                    lightDirection = 135;
                    break;

                case EffectChangeLightSource.BottomLeft:
                    lightDirection = 225;
                    break;

                case EffectChangeLightSource.BottomRight:
                    lightDirection = 315;
                    break;

                case EffectChangeLightSource.TopRight:
                    lightDirection = 90;
                    break;
            }

            var darkDirection = lightDirection - 180;

            LightShadowEffect = new DropShadowEffect {
                BlurRadius = blurRadius,
                Color = ConvertToSRGBColor(lightColor),
                Direction = lightDirection,
                ShadowDepth = distance
            };
            DarkShadowEffect = new DropShadowEffect {
                BlurRadius = blurRadius,
                Color = ConvertToSRGBColor(darkColor),
                Direction = darkDirection,
                ShadowDepth = distance
            };
        }

        public Brush Background { get; set; }
        public DropShadowEffect DarkShadowEffect { get; set; }
        public DropShadowEffect LightShadowEffect { get; set; }

        private Color ConvertToSRGBColor(Color color) {
            var newColor = new Color();
            newColor.ScR = (float)color.R / 255;
            newColor.ScG = (float)color.G / 255;
            newColor.ScB = (float)color.B / 255;

            return newColor;
        }
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }
        private Brush CreateBackground(Color color, EffectChangeShape shape, EffectChangeLightSource lightSource) {
            if (shape == EffectChangeShape.Flat || shape == EffectChangeShape.Pressed) {
                return new SolidColorBrush(color);
            }

            var firstGradientColor =
                ColorHelper.ColorWithLuminance(color, shape == EffectChangeShape.Convex ? 0.07 : -0.1);
            var secondGradientColor =
                ColorHelper.ColorWithLuminance(color, shape == EffectChangeShape.Concave ? 0.07 : -0.1);

            switch (lightSource) {
                case EffectChangeLightSource.TopLeft:
                    startPoint = new Point(0, 0);
                    endPoint = new Point(1, 1);
                    break;

                case EffectChangeLightSource.TopRight:
                    startPoint = new Point(1, 0);
                    endPoint = new Point(0, 1);
                    break;

                case EffectChangeLightSource.BottomLeft:
                    startPoint = new Point(0, 1);
                    endPoint = new Point(1, 0);
                    break;

                case EffectChangeLightSource.BottomRight:
                    startPoint = new Point(1, 1);
                    endPoint = new Point(0, 0);
                    break;
            }

            var result = new LinearGradientBrush { StartPoint = startPoint, EndPoint = endPoint };
            result.GradientStops.Add(new GradientStop(firstGradientColor, 0));
            result.GradientStops.Add(new GradientStop(secondGradientColor, 1));
            return result;
        }
    }
}
