using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject textGameObject;
    public GameObject scoreGameObject;
    private int targetScore = 10;
    private bool pass;
    private Text txt;
    private HTTPPost httpPost;

    private void Awake()
    {
        httpPost = FindObjectOfType<HTTPPost>();
    }

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
            textGameObject.GetComponent<Text>().color = Color.black;
            textGameObject.GetComponent<Text>().text = "過關了!\n你現在可以\n關閉這個分頁";
            httpPost.Post();
        }
        else
        {
            textGameObject.GetComponent<Text>().color = Color.black;
            textGameObject.GetComponent<Text>().text = "繼續努力!\n再嘗試一次？";
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