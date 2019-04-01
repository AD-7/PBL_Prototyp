using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3; // The enemy prefab to be spawned.
    public float spawnTime = 3f;
    public float spawnTime2 = 1f;
    public float spawnTime3 = 6f;// How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int maxAnimal = 30;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        InvokeRepeating("Spawn2", spawnTime2, spawnTime2);
        InvokeRepeating("Spawn3", spawnTime3, spawnTime3);
    }

    public void StartP()
    {
        Start();
    }


    void Spawn()
    {
        if (GameObject.FindGameObjectsWithTag("Animal").Length > maxAnimal)
        {
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
    void Spawn2()
    {
        if (GameObject.FindGameObjectsWithTag("Animal").Length > maxAnimal)
        {
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
    void Spawn3()
    {
        if (GameObject.FindGameObjectsWithTag("Animal").Length > maxAnimal)
        {
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy3, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}