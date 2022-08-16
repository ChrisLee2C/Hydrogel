using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject textGameObject;
    public GameObject scoreGameObject;
    private int targetScore = 5;
    private bool pass;
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(2);
        if (pass)
        {
            textGameObject.GetComponent<Text>().color = Color.green;
            textGameObject.GetComponent<Text>().text = "Congratulations!";
        }
        else
        {
            textGameObject.GetComponent<Text>().color = Color.black;
            textGameObject.GetComponent<Text>().text = "Keep Trying!";
        }
    }

    public void CheckScore()
    {
        textGameObject.SetActive(true);
        if (score < targetScore)
        {
            pass = false;
        }
        else
        {
            pass = true;
        }
        StartCoroutine(endGame());
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Current Score: " + score;
    }
}