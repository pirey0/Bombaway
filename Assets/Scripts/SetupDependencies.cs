using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDependencies
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Setup()
    {
        Debug.Log("Setting up dependencies.");

        var sceneInfo = GameObject.FindObjectOfType<SceneInfo>();

        SceneType type = SceneType.GameScene;
        if (sceneInfo != null)
        {
            type = sceneInfo.GetSceneType();
        }
        var sceneSettings = Resources.Load<SceneSettings>("SceneSettings");
        if (sceneSettings != null)
        {
            GameObject prefab = sceneSettings.SceneInstanceHolder;
            if (type == SceneType.MainMenu)
            {
                prefab = sceneSettings.MainMenuInstanceHolder;
            }

            if (prefab != null)
            {
                var instance = GameObject.Instantiate(prefab);
                instance.hideFlags = HideFlags.NotEditable;
            }
        }
        else
        {
            Debug.LogError("Error: No scene settings found in Resources.");
            Debug.Break();
        }
    }
}
