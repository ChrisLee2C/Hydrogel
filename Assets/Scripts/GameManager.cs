using System.Collections;
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
    public float delay = 2f;
    public RestartCanvas restartCanvas;
    public Slider slider;
    public Spawner spawner;
    public Score score;
    public bool isGameStart = false;

    public void GameStart() { isGameStart = true; }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
        {
            slider.interactable = false;
            return;
        }
        slider.interactable = true;
        CountDown();
        if (spawner.maxNum <= 0)
        {
            isGameStart = false; 
            StartCoroutine(RestartGame(isGameStart));
            score.CheckScore();
        }
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
            score.CheckScore();
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
