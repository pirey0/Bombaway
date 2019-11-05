using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ButtonBlock : MonoBehaviour, IEffectable
{

    [SerializeField] bool isExit;

    [HideIf("isExit")]
    [SerializeField] string sceneName;


    public void Explode(Bomb source)
    {
        Invoke("Effect", 1f);
    }


    private void Effect()
    {
        if (isExit)
        {
            Debug.Log("Application Quit");
            Application.Quit();
            Debug.Break();
        }
        else
        {
            Debug.Log("Loading scene: " + sceneName);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
   
}
