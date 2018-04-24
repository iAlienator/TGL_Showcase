#if (UNITY_EDITOR)
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class EditorShortcuts : ScriptableObject
{
    // New editor shortcut for F5, binding it to the Edit/Play Menu Item.
    [MenuItem("Edit/Run _F5")]
    static void PlayGame()
    {
        // Saves the scene before executing the command.
        if (!Application.isPlaying)
            EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), "", false);

        EditorApplication.ExecuteMenuItem("Edit/Play");
    }
}
#endif