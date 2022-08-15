using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> waterList;
    public List<GameObject> oilList;
    public int maxNum = 10;
    [SerializeField] private GameObject oil;
    [SerializeField] private GameObject water;
    [SerializeField] private RectTransform spawner;
    private float spawnerWidth;
    private float spawnerHeight;
    private float offset = 100f;

    private void Awake()
    {
        spawnerWidth = spawner.rect.width;
        spawnerHeight = spawner.rect.height;
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
        Vector3 waterSpawnRange = new Vector3(Random.Range(0 + offset, spawnerWidth - offset), Random.Range(0 + offset, spawnerHeight / 2 - offset), 0);
        waterList.Add(Instantiate(water, waterSpawnRange, Quaternion.identity, this.gameObject.transform));
    }

    private void SpawnOil()
    {
        Vector3 oilSpawnRange = new Vector3(Random.Range(0 + offset, spawnerWidth - offset), Random.Range(spawnerHeight / 2 + offset, spawnerHeight - offset), 0);
        oilList.Add(Instantiate(oil, oilSpawnRange, Quaternion.identity, this.gameObject.transform));
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
}
