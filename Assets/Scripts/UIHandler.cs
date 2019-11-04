using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] string StartSceneName = "StartScene";
    [SerializeField]
    RectTransform goblinUIParent;
    [SerializeField]
    GameObject goblinUIPrefab;

    [SerializeField]
    GameObject scoreSection;
    [SerializeField]
    TextMeshProUGUI scoreGnomes, scoreBombs, score; 

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

    public void ShowFinalScore (int gnomesCollected, int gnomesMax, int bombsLeft, int scoreFinal)
    {
        scoreSection.SetActive(true);
        scoreGnomes.text = gnomesCollected + " / " + gnomesMax + " Gnomes saved";
        scoreGnomes.text = bombsLeft + " Gnomes saved";
        score.text = scoreFinal.ToString();
    }

    public void ReturnToMenue()
    {
        SceneManager.LoadScene(StartSceneName);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
