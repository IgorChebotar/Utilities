using System.Globalization;
using System.Text;

namespace SimpleMan.Utilities
{
    public static class StringExtensions
    {
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

            lastSlashIndex = path.LastIndexOf('\\');
            path = path.Substring(lastSlashIndex + 1);

            int lastDotIndex = path.LastIndexOf('.');
            if (lastDotIndex != -1)
                path = path.Substring(0, lastDotIndex);

            return path;
        }

        /// <summary>
        /// SomeObjectName (Clone) -> SomeObjectName
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

        /// <summary>
        /// Marks your text as bold in Unity console.
        /// Your message text -> <b>Your message text</b>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Bold(this string source)
        {
            return $"<b>{source}</b>";
        }

        /// <summary>
        /// Marks your text as italic in Unity console.
        /// Example: Your message text -> <i>Your message text</i>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Italic(this string source)
        {
            return $"<i>{source}</i>";
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=colorCode>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColor(this string source, string colorCode)
        {
            return $"<color={colorCode}>{source}</color>";
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=red>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColorRed(this string source)
        {
            return source.SetColor("red");
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=green>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColorGreen(this string source)
        {
            return source.SetColor("green");
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=blue>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColorBlue(this string source)
        {
            return source.SetColor("blue");
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=yellow>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColorYellow(this string source)
        {
            return source.SetColor("yellow");
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=gray>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColorGray(this string source)
        {
            return source.SetColor("gray");
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=black>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColorBlack(this string source)
        {
            return source.SetColor("black");
        }

        /// <summary>
        /// Marks your text as colored in Unity console.
        /// Example: Your message text -> <color=white>Your message text</color>
        /// </summary>
        /// <returns></returns>
        public static string SetColorWhite(this string source)
        {
            return source.SetColor("white");
        }
    }
}