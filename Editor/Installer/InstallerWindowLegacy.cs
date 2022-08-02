using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace SimpleMan.Utilities.Editor
{
    internal class InstallerWindowLegacy : EditorWindow
    {
        //------METHODS
        [MenuItem("Tools/Simple Man/Utilities/Installer")]
        public static void Init()
        {
            InstallerWindowLegacy window = (InstallerWindowLegacy)EditorWindow.GetWindow(typeof(InstallerWindowLegacy));
            window.Show();
        }

        private void OnGUI()
        {
            bool isOdinExist = Installer.IsOdinExist();
            bool allright = isOdinExist;

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
                        "Import and install the dependencies first", MessageType.Error);
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

    public class InstallWindow : EditorWindow
    {
        //------FIELDS
        private const string DEPENDENCIES_JSON_PATH = "/Assets/Plugins/SimpleMan/Utilities/Editor/Installer/Dependencies.json";
        private static InstallerTab[] _tabs = System.Array.Empty<InstallerTab>();
        private static FTabData[] _tabDatas = System.Array.Empty<FTabData>();




        //------PROPERTIES
        public static IReadOnlyList<InstallerTab> Tabs => _tabs;
        public static int CurrentTabIndex { get; private set; } = 0;




        //------METHODS
        [MenuItem("Tools/Simple Man/Utilities/TEST")]
        public static void Init()
        {
            InstallWindow window = (InstallWindow)EditorWindow.GetWindow(typeof(InstallWindow));
            window.Show();

            _tabDatas = new FTabData[]
            {
                new FTabData(
                    "Tab1",
                    new FDependencyData("name1", "path1", "url1"),
                    new FDependencyData("name2", "path2", "url2")),

                new FTabData(
                    "Tab2",
                    new FDependencyData("name1", "path1", "url1"),
                    new FDependencyData("name2", "path2", "url2"))
            };

            string jsonText = JsonConvert.SerializeObject(_tabDatas);

            //string jsonData = File.ReadAllText(Application.dataPath + DEPENDENCIES_JSON_PATH);
            //Debug.Log(jsonData);

            File.WriteAllText(Application.dataPath + DEPENDENCIES_JSON_PATH, jsonText);
            //JsonUtility.FromJson(DEPENDENCIES_JSON_PATH, )

        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            for (int i = 0; i < _tabs.Length; i++)
            {
                if (GUILayout.Button(_tabs[i].Name))
                {

                }
            }
            GUILayout.EndVertical();

            GUILayout.BeginVertical();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            //tab.OnGUI();
        }
    }

    public class InstallerTab
    {
        public InstallerTab(string name, params FDependencyData[] dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }




        //------PROPERTIES
        public string Name { get; set; } = "Default name";
        public FDependencyData[] Dependencies { get; set; } = new FDependencyData[8];




        //------METHODS
        public void OnGUI()
        {
            bool[] dependenciesExistState = GetDependenciesInstalledState();
            bool allright = dependenciesExistState.All(x => x == true);

            void DrawLabel()
            {
                GUILayout.Label(Name.ToUpper(), EditorStyles.boldLabel);
                GUILayout.Space(10);
                GUILayout.Label("Dependencies:");
            }
            DrawLabel();

            void DrawDependencies()
            {
                
                for (int i = 0; i < Dependencies.Length; i++)
                {
                    GUILayout.BeginHorizontal();

                    GUI.enabled = false;
                    EditorGUILayout.Toggle($" - {Dependencies[i].name}", dependenciesExistState[i]);
                    GUI.enabled = true;

                    if (GUILayout.Button("URL"))
                    {
                        Application.OpenURL(Dependencies[i].url);
                    }
                    GUILayout.EndHorizontal();
                }
            }
            DrawDependencies();

            void DrawInstallButton()
            {
                if (!allright)
                {
                    GUI.enabled = false;
                    EditorGUILayout.HelpBox(
                        "One or more of dependencies was not found. " +
                        "Import and install the dependencies first", MessageType.Error);
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

        protected bool[] GetDependenciesInstalledState()
        {
            bool[] result = new bool[Dependencies.Length];
            for (int i = 0; i < Dependencies.Length; i++)
            {
                result[i] = IsDependencyExist(Dependencies[i].path);
            }

            return result.ToArray();
        }

        protected bool IsDependencyExist(string path)
        {
            string[] subfolders = AssetDatabase.GetSubFolders(path);
            return subfolders.Length > 1;
        }
    }

    public struct FTabData
    {
        public string name;
        public FDependencyData[] dependencies;

        public FTabData(string name, params FDependencyData[] dependencies)
        {
            this.name = name;
            this.dependencies = dependencies;
        }
    }

    public struct FDependencyData
    {
        public string name;
        public string path;
        public string url;

        public FDependencyData(string name, string path, string url)
        {
            this.name = name;
            this.path = path;
            this.url = url;
        }
    }
}