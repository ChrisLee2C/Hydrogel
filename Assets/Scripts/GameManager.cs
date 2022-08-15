using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public float remainingTime = 120f;
    public float delay = 5f;
    public RestartCanvas restartCanvas;
    public bool isGameStart = false;
    public Score score;
    public Spawner spawner;

    public void GameStart()
    {
        isGameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
        {
            return;
        }
        CountDown();
    }

    void CountDown()
    {
        remainingTime -= 1f * Time.deltaTime;
        if (remainingTime <= 0)
        {
            remainingTime = 0f;
            isGameStart = false;
            spawner.DestroyAll();
            StartCoroutine(RestartGame(isGameStart));
        }
    }

    IEnumerator RestartGame(bool restartGame)
    {
        while (restartGame == false)
        {
            yield return new WaitForSeconds(GameManager.instance.delay);
            restartCanvas.ShowResult();
        }
    }
}
