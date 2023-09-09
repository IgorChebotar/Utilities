using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class ColorExtensions
    {
        public static Color Invert(this Color value)
        {
            return new Color(1 - value.r, 1 - value.g, 1 - value.b);
        }

        public static Color WithAlpha(this Color value, float alpha)
        {
            return new Color(
                    value.r,
                    value.g,
                    value.b,
                    Mathf.Clamp01(alpha));
        }

        public static Color MaxAlpha(this Color value)
        {
            return new Color(
                    value.r,
                    value.g,
                    value.b,
                    1);
        }

        public static Color MinAlpha(this Color value)
        {
            return new Color(
                    value.r,
                    value.g,
                    value.b,
                    0);
        }
    }
}