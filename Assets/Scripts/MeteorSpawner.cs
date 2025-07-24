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
            var meteor = Instantiate(meteorPrefab, spawnPoint, Quaternion.identity);
            meteor.GetComponent<Meteor>().OnDestroyed += (_, _) => Debug.Log("Meteor destroyed");

            if (spawnRate >= 1)
                spawnRate -= Time.deltaTime * 5;

            if (spawnRate < 1)
                spawnRate = 1f;
            
            timeSinceLastSpawn = spawnRate;
        }
    }
}
