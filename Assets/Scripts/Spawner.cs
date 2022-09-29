using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> waterList;
    public List<GameObject> oilList;
    public int maxNum = 10;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject oil;
    [SerializeField] private GameObject water;
    //[SerializeField] private Text text;
    private float offset = 250f;
    private float canvasWidth;
    private float canvasHeight;
    //private string waterSpawn;
    //private string oilSpawn;

    private void Awake()
    {
        canvasWidth = canvas.pixelRect.width;
        canvasHeight = canvas.pixelRect.height;
    }

    public void Spawn()
    {
        if (GameManager.instance.isGameStart == true)
        {
            for (int num = 0; num < maxNum; num++)
            {
                SpawnOil();
                SpawnWater();
            }
        }
    }

    private void SpawnWater()
    {
        Vector3 waterSpawnRange = new Vector3(Random.Range(0 + offset, canvasWidth - offset), Random.Range(0 + offset, canvasHeight / 2 - offset), 0);
        //waterSpawn += waterSpawnRange.ToString() + "\n";
        waterList.Add(Instantiate(water, waterSpawnRange, Quaternion.identity, canvas.transform));
    }

    private void SpawnOil()
    {
        Vector3 oilSpawnRange = new Vector3(Random.Range(0 + offset, canvasWidth - offset), Random.Range(canvasHeight / 2 + offset, canvasHeight - offset), 0);
        //oilSpawn += oilSpawnRange.ToString() + "\n";
        oilList.Add(Instantiate(oil, oilSpawnRange, Quaternion.identity, canvas.transform));
    }

    public void DestroyAll()
    {
        foreach (GameObject items in oilList)
        {
            Destroy(items);
        }
        foreach (GameObject items in waterList)
        {
            Destroy(items);
        }
    }

    //private void Update()
    //{
    //    text.text = "waterSpawnRange: \n" + waterSpawn + "oilSpawnRange: \n" + oilSpawn + "\nspawnerPos: " + gameObject.transform.position;
    //}
}
