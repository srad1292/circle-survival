using System.Collections;
using UnityEngine;

public class EndlessGame : MonoBehaviour
{
    [SerializeField] Enemy[] enemyPrefabs;
    [SerializeField] SpawnerController spawnerController;
    [SerializeField] float minDelay = 0.1f;
    [SerializeField] float maxDelay = 0.9f;
    

    private Coroutine endlessSpawning;

    private void Start() {
        TurnOnEndlessSpawning();
    }

    public void TurnOnEndlessSpawning() {
        if(endlessSpawning == null)
            endlessSpawning = StartCoroutine(delayedSpawn());
    }

    public void TurnOffEndlessSpawning() {
        if (endlessSpawning != null)
            StopCoroutine(endlessSpawning);
    }

    IEnumerator delayedSpawn() {
        float delay;
        SpawnerEnum spawnerDirection;
        Enemy enemy;
        while (true) {
            delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            spawnerDirection = (SpawnerEnum)Random.Range(0, 3);
            enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 1)];
            spawnerController.Spawn(spawnerDirection, enemy);
        }
    }
}
