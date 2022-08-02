using UnityEditor;


namespace SimpleMan.Utilities.Editor
{
    [InitializeOnLoad]
    internal static class Installer
    {
        //------FIELDS
        public static string MAIN_FOLDER_PATH = "Assets/Plugins/SimpleMan/Utilities";
        public static string MAIN_PACKAGE_PATH = "Assets/Plugins/SimpleMan/Utilities/Editor/Installer/MainPackage.unitypackage";
        public static string ODIN_INSPECTOR_PATH = "Assets/Plugins/Sirenix/Odin Inspector";




        //------METHODS
        static Installer()
        {
            if(!IsAssetAlreadyImported())
                InstallerWindowLegacy.Init();
        }

        public static void Install()
        {
            AssetDatabase.ImportPackage(MAIN_PACKAGE_PATH, true);
        }

        public static bool IsAssetAlreadyImported()
        {
            string[] subfolders = AssetDatabase.GetSubFolders(MAIN_FOLDER_PATH);
            return subfolders.Length > 1;
        }

        public static bool IsOdinExist()
        {
            string[] subfolders = AssetDatabase.GetSubFolders(ODIN_INSPECTOR_PATH);
            return subfolders.Length > 0;
        }
    }
}