using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hydrogel : MonoBehaviour
{
    public Score score;
    public Spawner spawner;
    private bool isOil = false;
    private bool isWater = false;
    [SerializeField] private Image waterImage;
    [SerializeField] private Image oilImage;

    // Update is called once per frame
    void Update()
    {
        if(isOil && isWater == true)
        {
            score.score += 1;
            isOil = false;
            isWater = false;
            Invoke("DeleteColor", 0.2f);
            spawner.maxNum -= 1;
        }
    }

    void DeleteColor()
    {
        oilImage.color = new Color(255, 255, 255, 255);
        waterImage.color = new Color(255, 255, 255, 255);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isOil == false)
        {
            if (collision.gameObject.CompareTag("Oil") == true)
            {
                isOil = true;
                Destroy(collision.gameObject);
                oilImage.color = new Color32(254,241,137, 255);
            }
        }
        if(isWater == false)
        {
            if (collision.gameObject.CompareTag("Water") == true)
            {
                isWater = true;
                Destroy(collision.gameObject);
                waterImage.color = new Color32(134, 196, 247, 255);
            }
        }
    }
}
