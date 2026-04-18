using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] items;
    public float spawnRate = 1.0f;
    public float xRange = 8.0f;
    public static float damping = 1.0f;

    void Start()
    {
        damping = 1.0f;
        InvokeRepeating("Spawn", 1f, spawnRate);
    }

    void Spawn()
    {
        int randomIndex = Random.Range(0, items.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), transform.position.y, 0);
        GameObject newItem = Instantiate(items[randomIndex], spawnPos, Quaternion.identity);

        Rigidbody2D rb = newItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = damping;
        }
    }
}
