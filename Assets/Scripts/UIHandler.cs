using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UIHandler : Singleton<UIHandler>
{
    [SerializeField] string StartSceneName = "StartScene";
    [SerializeField]
    RectTransform goblinUIParent;
    [SerializeField]
    GameObject goblinUIPrefab;

    [Header("Scores")]
    [SerializeField]
    GameObject scoreSection;

    [SerializeField]
    TextMeshProUGUI totalScore;

    [SerializeField]
    TextMeshProUGUI bombsDescription, bombsScore;
    [SerializeField]
    TextMeshProUGUI goblinDescription, goblinScore;
    [SerializeField]
    TextMeshProUGUI blocksDescription, blocksScore;
    [SerializeField]
    TextMeshProUGUI timeDescription, timeScore;

    private void Start()
    {
        BombsAndGoblinsTracker.Instance.OutOfBombs += OnEnd;
        BombsAndGoblinsTracker.Instance.CollectedAllGoblins += OnEnd;
        BombsAndGoblinsTracker.Instance.GoblinAdded += OnGoblinAdded;

        gameObject.SetActive(true);
        scoreSection.SetActive(false);
        UpdateGoblinUI(0, BombsAndGoblinsTracker.Instance.TotalGoblins);
    }

    private void OnGoblinAdded()
    {
        int collectedGoblins = BombsAndGoblinsTracker.Instance.CollectedGoblins;
        int totalGoblins = BombsAndGoblinsTracker.Instance.TotalGoblins;
        UpdateGoblinUI(collectedGoblins, totalGoblins);
    }

    private void OnEnd()
    {
        //This should not be called in the UI
        Score.Instance.OnLevelEnd();

        var bombs = GameObject.FindObjectsOfType<Bomb>();
        int collectedGoblins = BombsAndGoblinsTracker.Instance.CollectedGoblins;
        int totalGoblins = BombsAndGoblinsTracker.Instance.TotalGoblins;
        ShowFinalScore(collectedGoblins, totalGoblins, bombs.Length);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenue();
        }
    }

    void UpdateGoblinUI(int found, int max)
    {
        for (int i = goblinUIParent.childCount - 1; i >= 0; i--)
        {
            Transform child = goblinUIParent.GetChild(i);
            if (child != null)
                Destroy(child.gameObject);
        }

        for (int i = 0; i < max; i++)
        {
            GameObject goblin = Instantiate(goblinUIPrefab, goblinUIParent);
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

    public void ShowFinalScore(int gnomesCollected, int gnomesMax, int bombsLeft)
    {
        scoreSection.SetActive(true);
        goblinDescription.text = gnomesCollected + " / " + gnomesMax + " Gnomes saved";
        bombsDescription.text = bombsLeft + " bombs left";
        timeDescription.text = $"in {Score.Instance.TotalTime.ToString("0")} Seconds";
        blocksDescription.text = "Destroyed x blocks";

        UpdateScore(ScoreType.Goblin, goblinScore);
        UpdateScore(ScoreType.Bomb, bombsScore);
        UpdateScore(ScoreType.Time, timeScore);
        UpdateScore(ScoreType.Bookshelf, blocksScore);

        totalScore.text = Score.Instance.TotalScore.ToString();
    }

    private void UpdateScore(ScoreType type, TMPro.TMP_Text text)
    {
        int score = Score.Instance.GetScoreFor(type);
        if (score < 0)
        {
            text.color = Color.red;
        }
        text.text = score.ToString();
    }

    public void ReturnToMenue()
    {
        SceneManager.LoadScene(StartSceneName);
    }

    public void NextScene()
    {
        Debug.Log("TRYING TO LOAD NEXT SCENE");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

