namespace SimpleMan.Utilities
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Returns reflected value. Ex. true -> false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Mirror(this bool value)
        {
            return !value;
        }

        /// <summary>
        /// Returns reflected value. Ex. true -> false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void MirrorRef(ref this bool value)
        {
            value = !value;
        }
    }
}