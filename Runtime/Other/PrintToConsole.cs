using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class PrintToConsole
    {
        /// <summary>
        /// Use <b>Sender: Message</b> pattern to print your messages 
        /// to the Unity console.
        /// Example: PrintToConsole.Info("Player: Got 5 damage points from zombie") -> 
        /// <b>Player: </b> Got 5 damage points from zombie.
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Debug.Log(PrepareToPrint(message));
        }

        /// <summary>
        /// Use <b>Sender: Message</b> pattern to print your messages 
        /// to the Unity console.
        /// Example: PrintToConsole.Info("Player: Got 5 damage points from zombie") -> 
        /// <b>Player: </b> Got 5 damage points from zombie.
        /// </summary>
        /// <param name="message"></param>
        public static void Warning(string message)
        {
            Debug.LogWarning(PrepareToPrint(message));
        }

        /// <summary>
        /// Use <b>Sender: Message</b> pattern to print your messages 
        /// to the Unity console.
        /// Example: PrintToConsole.Info("Player: Got 5 damage points from zombie") -> 
        /// <b>Player: </b> Got 5 damage points from zombie.
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Debug.LogError(PrepareToPrint(message));
        }

        private static string PrepareToPrint(string source)
        {
            if(string.IsNullOrEmpty(source))
                return source;

            string[] splitted = source.Split(':', 2);
            if (splitted.Length != 2)
            {
                return source;
            }
            else
            {
#if UNITY_EDITOR
                return $"{splitted[0].Bold()}: {splitted[1]}";
#else
                return source;
#endif
            }
        }
    }
}