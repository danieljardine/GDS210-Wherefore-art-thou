using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public UIManager uiManager;

    public int score = 0, monks = 0, curentMonks = 0;
    public float bestScore, currentTime;

	// Use this for initialization
	void Start () {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        currentTime = 0;
	}

	// Update is called once per frame
	void Update () {
        if (currentTime == 300)
            SceneManager.LoadScene("GameOver");
        currentTime += Time.deltaTime;
    }
}
