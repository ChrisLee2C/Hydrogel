using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text txt;
    
    // Update is called once per frame
    void Update()
    {
        txt.text = "Remaining Time: " + Convert.ToInt32(GameManager.instance.remainingTime);
    }
}
