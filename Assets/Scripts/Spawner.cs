using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] items;
    public float spawnRate = 1.0f;
    public float xRange = 8.0f;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, items.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), transform.position.y, 0);
        Instantiate(items[randomIndex], spawnPos, Quaternion.identity);
    }
}
