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
            if(!IsAssetAlreadyImported())
                InstallerWindow.Init();
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