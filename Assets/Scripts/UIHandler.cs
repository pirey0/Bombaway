using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] string StartSceneName = "StartScene";
    [SerializeField]
    RectTransform goblinUIParent;
    [SerializeField]
    GameObject goblinUIPrefab;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenue();
        }
    }

    void UpdateGoblinUI(int found, int max)
    {
        for (int i = goblinUIParent.childCount-1;  i >= 0; i--)
        {
            Transform child = goblinUIParent.GetChild(i);
            if (child != null)
                Destroy(child);
        }

        for (int i = 0; i < max; i++)
        {
            GameObject goblin = Instantiate(goblinUIPrefab,goblinUIParent);
            goblin.transform.localPosition = (Vector3.right * 60 * i);

            if (i >= found)
            {
                Image image = goblin.GetComponent<Image>();
                if (image != null)
                {
                    image.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                }
            }
        }
    }

    public void ReturnToMenue()
    {
        SceneManager.LoadScene(StartSceneName);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
