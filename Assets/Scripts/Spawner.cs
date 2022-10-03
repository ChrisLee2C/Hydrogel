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
    private float offset = 150f;

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

    private Vector3 WaterSpawnRange() => new Vector3(Random.Range(0 + offset, canvas.transform.position.x*2 - offset), Random.Range(0 + offset, canvas.transform.position.y - offset), 0);

    private Vector3 OilSpawnRange() => new Vector3(Random.Range(0 + offset, canvas.transform.position.x*2 - offset), Random.Range(canvas.transform.position.y + offset, canvas.transform.position.y*2 - offset), 0);

    private void SpawnWater()
    {
        Vector3 waterSpawnRange = WaterSpawnRange();
        waterList.Add(Instantiate(water, waterSpawnRange, Quaternion.identity, canvas.transform));
    }

    private void SpawnOil()
    {
        Vector3 oilSpawnRange = OilSpawnRange();
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
    //    text.text = "canvas transform: " + canvas.transform.position + "\ncanvas local transform: " + canvas.transform.localPosition; 
    //}
}
