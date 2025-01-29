using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 5;
    public float spawnDelay = 1f;
    public float activationDistance = 20f;

    private bool isPlayerNear = false;

    //make a validation that when spawned it will not spawn again when player entered an area
    //probably make it a collider and will spawn an enemy but counts them when they die.
    //also put a wall when they spawn so player cannot leave until they kill it

    void Update()
    {
        if (isPlayerNear)
        {
            StartCoroutine(SpawnEnemies());
            isPlayerNear = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered");
            isPlayerNear = true;
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}