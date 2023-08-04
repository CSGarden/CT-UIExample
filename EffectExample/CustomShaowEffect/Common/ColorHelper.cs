using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EffectExample.CustomShaowEffect.Common
{
  public  class ColorHelper
    {
        /// <summary>
        /// 在每个颜色通道（红色、绿色、蓝色）上进行处理。
        /// </summary>
        /// <param name="color">颜色通道</param>
        /// <param name="luminance">亮度</param>
        /// <returns></returns>
        public static Color ColorWithLuminance(Color color, double luminance) {
            var result = color;
            var partWithLuminance = Clamp(result.R + result.R * luminance, 0, 255);
            var roundValue = (int)Math.Round(partWithLuminance);
            result.R = (byte)roundValue;

            partWithLuminance = Clamp(result.G + result.G * luminance, 0, 255);
            roundValue = (int)Math.Round(partWithLuminance);
            result.G = (byte)roundValue;

            partWithLuminance = Clamp(result.B + result.B * luminance, 0, 255);
            roundValue = (int)Math.Round(partWithLuminance);
            result.B = (byte)roundValue;
            return result;
        }
        /// <summary>
        /// 将经过调整的红色、绿色和蓝色通道值重新赋值给 result，并将其作为最终结果返回
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Clamp(double value, double min, double max) {
            if (min > max) {
                Math.Max(min, max);
            }
            if (value < min) {
                return min;
            } else if (value > max) {
                return max;
            }
            return value;

        }
    }
}
