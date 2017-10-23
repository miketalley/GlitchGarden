using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public Text tryAgain;
    public Text quit;
    public float timer;
    public string timedLevelToLoad;

    private float currentTimer;
    private bool timedLevelExists = false;

    public void Start()
    {
        ResetLoadLevelTimer();
    }

    public void Update()
    {
        UpdateLoadLevelTimer();   
    }

    private void ResetLoadLevelTimer()
    {
        timedLevelExists = timedLevelToLoad.Length > 0;
        if (timer > 0 && timedLevelExists)
        {
            currentTimer = timer;
        }
    }

    private void UpdateLoadLevelTimer()
    {
        if (currentTimer > 0 && timedLevelExists)
        {
            currentTimer -= Time.deltaTime;
        }
        else if (currentTimer <= 0 && timedLevelExists)
        {
            LoadLevel(timedLevelToLoad);
        }
    }

    public void LoadLevel(string scene)
    {
        ClearText();
        SceneManager.LoadScene(scene);
    }

    public void LoadScene (string scene)
    {
        ClearText();
        SceneManager.LoadScene(scene);
    }

    public void StartNewGame ()
    {
        LoadLevel("Game");
    }

    public void RestartLevel()
    {
        LoadLevel("Game");
    }

    public void GameOver()
    {
        tryAgain.text = "try again";
        quit.text = "quit";
    }

    public void Quit ()
    {
        Application.Quit();
    }

    public void ClearText()
    {
        if (tryAgain)
        {
            tryAgain.text = "";
        }
        if (quit)
        {
            quit.text = "";
        }
    }
}
