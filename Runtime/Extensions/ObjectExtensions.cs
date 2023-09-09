namespace SimpleMan.Utilities
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns true if object is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool NotExist(this object value)
        {
            return value == null;
        }

        /// <summary>
        /// Returns true if object is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool NotExist(this UnityEngine.Object value)
        {
            return !value;
        }

        /// <summary>
        /// Returns true if object is not null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Exist(this object value)
        {
            return value != null;
        }

        /// <summary>
        /// Returns true if object is not null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Exist(this UnityEngine.Object value)
        {
            return value;
        }
    }
}