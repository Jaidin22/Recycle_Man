using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameManager : MonoBehaviour
{
    public Timer timer;
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    public ScoreUI score;
    public Text endMessage;
    public Text scoreText;
    public Canvas overlayCanvas;


    public void Start()
    {
        gameOverUI.SetActive(false);
        gameWonUI.SetActive(false);
        Cursor.visible = false;

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }
    public void Default()
    {
        StartCoroutine(Timer());
        //Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        timer.active = false;
        overlayCanvas.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        
        gameOverUI.SetActive(true);
        Default();
    }
    public void GameWon()
    {
        
        //finalTime = string.Format(@"mm\:ss");
        gameWonUI.SetActive(true);
        Default();
        scoreText.text = score.points.ToString();
        endMessage.text = "You made the park more sustainable in \n" + timer.currentTimeText.text; //timer.currentTime.ToString();
    }
}
