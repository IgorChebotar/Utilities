using System.Globalization;
using System.Text;
using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class BaseTypesExtensions
    {
        /// <summary>
        /// Returns true if object is null
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool NotExist(this object target)
        {
            return target == null;
        }

        /// <summary>
        /// Returns true if object is null
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool NotExist(this UnityEngine.Object target)
        {
            return !target;
        }

        /// <summary>
        /// Returns true if object is not null
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool Exist(this object target)
        {
            return target != null;
        }

        /// <summary>
        /// Returns true if object is not null
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool Exist(this UnityEngine.Object target)
        {
            return target;
        }

        /// <summary>
        /// sad but true -> Sad but true
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// 
        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new System.ArgumentNullException(nameof(input));


            return input[0].ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// SadButTrue -> Sad But True
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSplitPascalCase(this string input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            StringBuilder stringBuilder = new StringBuilder(input.Length);
            if (char.IsLetter(input[0]))
            {
                stringBuilder.Append(char.ToUpper(input[0]));
            }
            else
            {
                stringBuilder.Append(input[0]);
            }

            for (int i = 1; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsUpper(c) && !char.IsUpper(input[i - 1]))
                {
                    stringBuilder.Append(' ');
                }

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sad But True -> SadButTrue
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string WithoutSpaces(this string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == ' ' && i + 1 < input.Length)
                {
                    char c2 = input[i + 1];
                    if (char.IsLower(c2))
                    {
                        c2 = char.ToUpper(c2, CultureInfo.InvariantCulture);
                    }

                    stringBuilder.Append(c2);
                    i++;
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// ObjectName -> Prefix_ObjectName
        /// FirstPrefix_ObjectName -> SecondPrefix_ObjectName
        /// </summary>
        /// <param name="source"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string WithUnderscorePrefix(this string source, string prefix)
        {
            return prefix + '_' + source;
        }

        /// <summary>
        /// Prefix_ObjectName -> ObjectName
        /// </summary>
        /// <param name="source"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string WithoutUnderscorePrefix(this string source)
        {
            int underscoreCharIndex = source.IndexOf('_');
            return source.Substring(underscoreCharIndex + 1);
        }

        /// <summary>
        /// ObjectName -> [Prefix]ObjectName
        /// </summary>
        /// <param name="source"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string WithSquarePrefix(this string source, string prefix)
        {
            if (source == null)
                return $"[{prefix}]";

            string[] separatedName = source.Split(']');

            if (separatedName.Length == 2)
                source = $"[{prefix}]{separatedName[1]}";

            else if (separatedName.Length == 1)
                source = $"[{prefix}]{source}";


            return source;
        }

        /// <summary>
        /// [Prefix]ObjectName -> ObjectName
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string WithoutSquarePrefix(this string source)
        {
            if (source == null)
                return string.Empty;

            string[] separatedName = source.Split(']');

            if (separatedName.Length == 2)
                return separatedName[1];

            else
                return source;
        }

        /// <summary>
        /// Assets/Data/File.Asset -> File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ExctractFileNameFromPath(this string path)
        {
            int lastSlashIndex = path.LastIndexOf('/');
            path = path.Substring(lastSlashIndex + 1);

            int lastDotIndex = path.LastIndexOf('.');
            path = path.Substring(0, lastDotIndex);

            return path;
        }

        /// <summary>
        /// SomeObject (Clone) -> SomeObject
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveClone(this string source)
        {
            if (!source.Contains("("))
                return source;

            int index = source.IndexOf('(');
            return source.Substring(0, index);
        }

        public static float Clamp(this float value, float min, float max)
        {
            return Mathf.Clamp(value, min, max);
        }

        public static int Clamp(this int value, float min, float max)
        {
            return Mathf.RoundToInt(Mathf.Clamp(value, min, max));
        }

        /// <summary>
        /// From 0 to infinity
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ClampPositive(this float value)
        {
            return Mathf.Clamp(value, 0, float.PositiveInfinity);
        }

        /// <summary>
        /// From 0 to max value (2147483647)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ClampPositive(this int value)
        {
            return Mathf.Clamp(value, 0, int.MaxValue);
        }

        /// <summary>
        /// From 0 to 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Clamp01(this float value)
        {
            return Mathf.Clamp01(value);
        }

        /// <summary>
        /// From -1 to 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ClampAsAxis(this float value)
        {
            return Mathf.Clamp(value, -1, 1);
        }

        public static int RoundToInt(this float value)
        {
            return Mathf.RoundToInt(value);
        }

        public static float Round(this float value)
        {
            return Mathf.Round(value);
        }

        public static int FloorToInt(this float value)
        {
            return Mathf.FloorToInt(value);
        }

        public static float Floor(this float value)
        {
            return Mathf.Floor(value);
        }

        public static int CeilToInt(this float value)
        {
            return Mathf.CeilToInt(value);
        }

        public static float Ceil(this float value)
        {
            return Mathf.Ceil(value);
        }

        public static int Abs(this int value)
        {
            return Mathf.Abs(value);
        }

        public static float Abs(this float value)
        {
            return Mathf.Abs(value);
        }

        public static bool InRange(this float value, float min, float max)
        {
            return value >= min && value <= max;
        }

        public static bool InRange(this int value, float min, float max)
        {
            return value >= min && value <= max;
        }

        public static bool OutOfRange(this float value, float min, float max)
        {
            return value < min || value > max;
        }

        public static bool OutOfRange(this int value, float min, float max)
        {
            return value < min || value > max;
        }

        public static Vector3 XY2XZ(this Vector2 target)
        {
            return new Vector3(target.x, 0, target.y);
        }

        public static Vector2 XZ2XY(this Vector3 target)
        {
            return new Vector2(target.x, target.z);
        }

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

        public static Quaternion ExtractRotation(this Matrix4x4 matrix)
        {
            Vector3 forward;
            forward.x = matrix.m02;
            forward.y = matrix.m12;
            forward.z = matrix.m22;

            Vector3 upwards;
            upwards.x = matrix.m01;
            upwards.y = matrix.m11;
            upwards.z = matrix.m21;

            return Quaternion.LookRotation(forward, upwards);
        }

        public static Vector3 ExtractPosition(this Matrix4x4 matrix)
        {
            Vector3 position;
            position.x = matrix.m03;
            position.y = matrix.m13;
            position.z = matrix.m23;
            return position;
        }

        public static Vector3 ExtractScale(this Matrix4x4 matrix)
        {
            Vector3 scale;
            scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
            scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
            scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
            return scale;
        }
    }
}