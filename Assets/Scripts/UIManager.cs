using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameManager gameManager;
    GameObject[] pauseObjects;
    Text myText;
    public Text currentTime, score, bestScore, monks, currentMonks;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //Pause controls
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }
	
	// Update is called once per frame
	void Update () {
        //Shows the relative texts
        score.text = "Score: " + gameManager.score;
        monks.text = "Monks rescued: " + gameManager.monks;
        currentMonks.text = "Monks Onboard: " + gameManager.curentMonks;
        currentTime.text = "Time: " + gameManager.currentTime;
        bestScore.text = "Best Score: " + gameManager.bestScore;

        //Pause control
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
        //If time = 0 then load the game over screen
        if (gameManager.currentTime > 300)
        {
            SceneManager.LoadScene("gameover");
        }
}

    public void Reload()
    {
        SceneManager.LoadScene("Lvl1");
    }

    public void pauseControl()
    //Determines if the game is paused or not
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }
    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void preface()
    {
        SceneManager.LoadScene("Preface");
    }
    public void quit()
    {
        Application.Quit();
    }
}
