using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private Vector2[] spawnPoints;

    private float timeSinceLastSpawn = 0;

    private void Update()
    {
        timeSinceLastSpawn -= Time.deltaTime;
        
        if (timeSinceLastSpawn <= 0f)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(meteorPrefab, spawnPoint, Quaternion.identity);

            if (spawnRate >= 0.5)
                spawnRate -= Time.deltaTime * 10;
            
            timeSinceLastSpawn = spawnRate;
        }
    }
}
