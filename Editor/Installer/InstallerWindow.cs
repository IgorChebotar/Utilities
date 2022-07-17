using UnityEditor;
using UnityEngine;

namespace SimpleMan.Utilities.Editor
{
    internal class InstallerWindow : EditorWindow
    {
        //------METHODS
        [MenuItem("Tools/Simple Man/Utilities/Installer")]
        public static void Init()
        {
            InstallerWindow window = (InstallerWindow)EditorWindow.GetWindow(typeof(InstallerWindow));
            window.Show();
        }

        private void OnGUI()
        {
            bool isOdinExist = Installer.IsOdinExist();
            bool allright = true;

            void DrawLabel()
            {
                GUILayout.Label("UTILITIES INSTALLER", EditorStyles.boldLabel);
                GUILayout.Space(10);
                GUILayout.Label("Dependencies:");
            }
            DrawLabel();

            void DrawDependencies()
            {
                GUI.enabled = false;
                EditorGUILayout.Toggle(" - Odin inspector", isOdinExist);
                GUI.enabled = true;
            }
            DrawDependencies();

            void DrawInstallButton()
            {
                if (!allright)
                {
                    GUI.enabled = false;
                    EditorGUILayout.HelpBox(
                        "One or more of dependencies was not found. " +
                        "Import and install the dependencies plugins first", MessageType.Error);
                }

                string buttonName = Installer.IsAssetAlreadyImported() ? "Reinstall" : "Install";
                if (GUILayout.Button(buttonName))
                {
                    Installer.Install();
                }

                GUI.enabled = true;
            }
            DrawInstallButton(); 
        }


    }
}