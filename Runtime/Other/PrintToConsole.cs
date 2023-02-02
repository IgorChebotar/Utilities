using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class PrintToConsole
    {
        public static void Info(string sender, string message)
        {
            Debug.Log($"<b>{sender}</b>: {message}");
        }

        public static void Info(object sender, string message)
        {
            Debug.Log($"<b>{sender.GetType().Name}</b>: {message}");
        }

        public static void Warning(string sender, string message)
        {
            Debug.LogWarning($"<b>{sender}</b>: {message}");
        }

        public static void Warning(object sender, string message)
        {
            Debug.LogWarning($"<b>{sender.GetType().Name}</b>: {message}");
        }

        public static void Error(string sender, string message)
        {
            Debug.LogError($"<b>{sender}</b>: {message}");
        }

        public static void Error(object sender, string message)
        {
            Debug.LogError($"<b>{sender.GetType().Name}</b>: {message}");
        }
    }
}