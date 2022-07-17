using UnityEditor;
using static SimpleMan.Utilities.Editor.EditorConstants;

namespace SimpleMan.Utilities.Editor
{
    [InitializeOnLoad]
    internal static class Installer
    {
        //------METHODS
        static Installer()
        {
            //IsOdinExist();
        }

        public static void Install()
        {
            if (!IsMainPackageExist())
            {
                throw new System.NullReferenceException(
                    "<b>Utilities:</b> Main package don't exist. Reimport plugin manually.");
            }

            var asset = AssetDatabase.LoadAssetAtPath<DefaultAsset>(MAIN_PACKAGE_PATH);
            AssetDatabase.ImportPackage(MAIN_PACKAGE_PATH, true);
        }

        public static bool IsMainPackageExist()
        {
            var asset = AssetDatabase.LoadAssetAtPath<DefaultAsset>(MAIN_PACKAGE_PATH);
            return asset == null;
        }

        public static bool IsOdinExist()
        {
            string[] subfolders = AssetDatabase.GetSubFolders(ODIN_INSPECTOR_PATH);
            return subfolders.Length > 0;
        }
    }
}