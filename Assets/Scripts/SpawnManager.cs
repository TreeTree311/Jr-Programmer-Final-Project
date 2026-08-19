using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    GameObject player;

    float spawnDistanceX = 16f;
    float spawnDistanceZ = 11f;
    float spawnPointY = 0.5f;
    int initialEnemies = 3;
    int increaseEenemyCount = 2;
    float timeBetweenWaves = 10f;
    float timeToAddBetweenWaves = 10f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        SpawnEnemyWave(initialEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeBetweenWaves)
        {
            initialEnemies += increaseEenemyCount;
            timeBetweenWaves += timeToAddBetweenWaves;
            SpawnEnemyWave(initialEnemies);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        
        Vector3 randomPositiveZ = new Vector3 (Random.Range((player.transform.position.x - spawnDistanceX),(player.transform.position.x + spawnDistanceX)),
            player.transform.position.y + spawnPointY, player.transform.position.z + spawnDistanceZ);
        Vector3 randomNegativeZ = new Vector3(Random.Range(player.transform.position.x - spawnDistanceX, player.transform.position.x + spawnDistanceX),
            player.transform.position.y + spawnPointY, player.transform.position.z - spawnDistanceZ);
        Vector3 randomPositiveX = new Vector3(player.transform.position.x + spawnDistanceX,
            player.transform.position.y + spawnPointY, Random.Range(player.transform.position.z - spawnDistanceZ, player.transform.position.z + spawnDistanceZ));
        Vector3 randomNegativeX = new Vector3(player.transform.position.x - spawnDistanceX,
           player.transform.position.y + spawnPointY, Random.Range(player.transform.position.z - spawnDistanceZ, player.transform.position.z + spawnDistanceZ));

        Vector3[] spawnposition = {randomPositiveZ,randomNegativeZ,randomPositiveX,randomNegativeX};
        int randomSpawn = Random.Range(0, spawnposition.Length);
        return spawnposition[randomSpawn];

    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int whichEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[whichEnemy], GenerateSpawnPosition(), enemies[whichEnemy].transform.rotation);
        }
    }
}
