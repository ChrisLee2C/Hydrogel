using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrogel : MonoBehaviour
{
    public Score score;
    private bool isOil = false;
    private bool isWater = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOil && isWater == true)
        {
            score.score += 1;
            isOil = false;
            isWater = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isOil == false)
        {
            if (collision.gameObject.CompareTag("Oil") == true)
            {
                isOil = true;
                Destroy(collision.gameObject);
            }
        }
        if(isWater == false)
        {
            if (collision.gameObject.CompareTag("Water") == true)
            {
                isWater = true;
                Destroy(collision.gameObject);
            }
        }
    }
}
