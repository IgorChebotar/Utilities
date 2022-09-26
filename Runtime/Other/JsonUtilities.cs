

using System;
using UnityEngine;

namespace SimpleMan.Utilities
{
    public static class JsonUtilities
    {
        public static T[] GetArrayFromJson<T>(string jsonText)
        {
            string decoratedJsonText = "{ \"array\": " + jsonText + "}";
            JsonWrapper<T> wrapper = JsonUtility.FromJson<JsonWrapper<T>>(decoratedJsonText);
            return wrapper.array;
        }

        public static string ToJson<T>(this T[] array, bool prettyPrint = true)
        {
            return ArrayToJson(array, prettyPrint);
        }

        public static string ArrayToJson<T>(T[] array, bool prettyPrint = true)
        {
            JsonWrapper<T> wrapper = new JsonWrapper<T>(array);
            string jsonText = JsonUtility.ToJson(wrapper, prettyPrint);


            var pos = jsonText.IndexOf(":");
            jsonText = jsonText.Substring(pos + 1);


            pos = jsonText.LastIndexOf('}');
            jsonText = jsonText.Substring(0, pos - 1);


            return jsonText;
        }

        [Serializable]
        private struct JsonWrapper<T>
        {
            //------FIELDS
            public T[] array;




            //------CONSTRUCTORS
            public JsonWrapper(T[] array)
            {
                this.array = array;
            }
        }
    }
}