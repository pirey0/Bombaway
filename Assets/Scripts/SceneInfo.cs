using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    [SerializeField] SceneType sceneType;


    public SceneType GetSceneType()
    {
        return sceneType;
    }

}

public enum SceneType
{
    MainMenu,
    GameScene
}