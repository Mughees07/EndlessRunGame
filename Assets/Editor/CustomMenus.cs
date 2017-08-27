using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

#if UNITY_5_3
using UnityEditor.SceneManagement;
#endif

public class CustomMenus : MonoBehaviour
{


    static string plugin_Scene_Path = "Assets/GameScenes/Menu.unity";
    static string gameplay_Scene_Path = "Assets/GameScenes/Loading.unity";
    static string menuScene_Scene_Path = "Assets/GameScenes/Gameplay.unity";


    [MenuItem("Tapinator/Plugins _F1")]
    private static void PluginScene()
    {		
        if (!EditorApplication.isPlaying)
        {
            #if UNITY_5_3
            bool value = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            if (value)
            {
                EditorSceneManager.OpenScene(CustomMenus.plugin_Scene_Path);
            }
            #else
			bool value = EditorApplication.SaveCurrentSceneIfUserWantsTo();
			if(value)
			{
				EditorApplication.OpenScene(CustomMenus.plugin_Scene_Path);
			}
            #endif
        }
    }


    [MenuItem("Tapinator/Gameplay _F2")]
    private static void Gameplay()
    {		
        if (!EditorApplication.isPlaying)
        {
            #if UNITY_5_3
            bool value = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            if (value)
            {
                EditorSceneManager.OpenScene(CustomMenus.gameplay_Scene_Path);
            }
            #else

			bool value = EditorApplication.SaveCurrentSceneIfUserWantsTo();
			if(value)
			{
				EditorApplication.OpenScene(CustomMenus.gameplay_Scene_Path);
			}	
            #endif
        }
    }


    [MenuItem("Tapinator/MenuScene _F3")]
    private static void MenuScene()
    {
        if (!EditorApplication.isPlaying)
        {
            #if UNITY_5_3
            bool value = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            if (value)
            {
                EditorSceneManager.OpenScene(CustomMenus.menuScene_Scene_Path);
            }
            #else
			bool value = EditorApplication.SaveCurrentSceneIfUserWantsTo();
			if(value)
			{
				EditorApplication.OpenScene(CustomMenus.menuScene_Scene_Path);
			}
            #endif
        }
    }

    [MenuItem("Tapinator/Clear Console _F4")] 
    static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }


    [MenuItem("Tapinator/PlayStop _F5")]
    private static void PlayStopButton()
    {	
        if (!EditorApplication.isPlaying)
        {	
            #if UNITY_5_3
            bool value = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            if (value)
            {
                EditorSceneManager.OpenScene(CustomMenus.plugin_Scene_Path);
                EditorApplication.ExecuteMenuItem("Edit/Play");
            }
            #else
			bool value=EditorApplication.SaveCurrentSceneIfUserWantsTo();
			if(value)
			{
				EditorApplication.OpenScene(CustomMenus.plugin_Scene_Path);
				EditorApplication.ExecuteMenuItem("Edit/Play");
			}
            #endif
        }		

    }
//End of PlayStopButton


    [MenuItem("Tapinator/Pause _F6")]
    private static void PauseButton()
    {		
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExecuteMenuItem("Edit/Pause");
        }
    }
//End of PauseButton


    [MenuItem("Tapinator/Clear UserPrefs _F7")]
    private static void ClearUserPrefs()
    {

        if (!EditorApplication.isPlaying)
        {
            File.Delete(Application.persistentDataPath + "/" + "PlayerPrefs.txt");
            File.Delete(Application.persistentDataPath + "/" + "RewardPrefs.txt");
        }
    }

    [MenuItem("Window/Behaviour Designer &1")]
    private static void BehaviourDesignerShorcut()
    {
        EditorApplication.ExecuteMenuItem("Tools/Behavior Designer/Editor");
    }

    [MenuItem("Tapinator/Save Prefab _F8")]

    private static void savePrfab()
    {
        //EditorApplication.ExecuteMenuItem("GameObject/Apply Changes To Prefab");
        GameObject[] selectedObjects = Selection.gameObjects;
		
        foreach (GameObject obj in selectedObjects)
        {
            Object targetObject = PrefabUtility.GetPrefabParent(obj);
			
            PrefabUtility.ReplacePrefab(obj, targetObject, ReplacePrefabOptions.ConnectToPrefab);
        }
    }

    [MenuItem("Tapinator/Reset Tranform _F9")]
    private static void Reset()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (GameObject obj in selectedObjects)
        {
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
        }
    }


}
