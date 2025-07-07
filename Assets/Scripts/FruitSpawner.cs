using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public LogicManager logic;
    public Camera mainCam;
    public List<GameObject> fruits;

    private List<float> spawnTimers;
    public float minX, maxX;
    private float halfHeight, halfWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        halfHeight = mainCam.orthographicSize;
        halfWidth = halfHeight * mainCam.aspect;

        spawnTimers = new List<float>(fruits.Count);
        for (int i = 0; i < fruits.Count; i++)
        {
            spawnTimers.Add(0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.isGameOver == false)
        {
            if (Time.time - logic.gameStartTime < 10)
            {
                SpawnMultis(fruits, fruits.Count - 2);
            }
            else
            {
                SpawnMultis(fruits, fruits.Count);
            }
        }
    }

    void Spawn(GameObject obj)
    {
        if (Random.value <= obj.GetComponent<Fruit>().spawnChance)
        {
            float halfFruit = obj.GetComponent<SpriteRenderer>().bounds.extents.x;
            minX = mainCam.transform.position.x - halfWidth + halfFruit;
            maxX = mainCam.transform.position.x + halfWidth - halfFruit;
            Instantiate(obj, new Vector3(Random.Range(minX, maxX), 
                Random.Range(transform.position.y + 3, transform.position.y + 6), 0), transform.rotation);
        }
    }

    // Spawn multiple objects to an extent of a list
    void SpawnMultis(List<GameObject> list, int extent)
    {
        for (int i = 0; i < extent; i++)
        {
            spawnTimers[i] += Time.deltaTime;
            Fruit fruit = list[i].GetComponent<Fruit>();
            if (spawnTimers[i] >= fruit.spawnRate)
            {
                Spawn(list[i]);
                spawnTimers[i] = 0;
            }
        }
    }
}
