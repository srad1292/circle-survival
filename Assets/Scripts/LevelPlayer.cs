using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayer : MonoBehaviour
{
    public System.Action<int> OnLevelComplete;

    [SerializeField] SpawnerController spawnerController;
    [SerializeField] InGameUI inGameUI;
    [SerializeField] Player player;
    [SerializeField] Transform playerBulletContainer;

    int day;
    int numberOfEnemiesAlive = 0;
    Wave currentWave;
    List<Wave> waveConfig;
    int currentWaveIndex = 0;

    public void PlayLevel(int day, List<Wave> waveConfig) {
        player.SetInActiveLevel(true);
        inGameUI.SetInActiveLevel(true);
        inGameUI.HandleLevelStarted();
        this.day = day;
        this.waveConfig = new List<Wave>();
        this.waveConfig.AddRange(waveConfig);
        numberOfEnemiesAlive = 0;
        currentWaveIndex = 0;
        currentWave = waveConfig[0];
        StartCoroutine(WaitBetweenWaves(0.75f));
    }

    IEnumerator WaitBetweenWaves(float duration) {
        yield return new WaitForSeconds(duration);
        StartCoroutine(SpawnWave(currentWave));
    }

    IEnumerator SpawnWave(Wave wave) {
        float delay;
        SpawnerEnum spawnerDirection;
        Enemy enemy;
        int spawned = 0;
        numberOfEnemiesAlive = wave.numEnemies;
        
        while (spawned < wave.numEnemies) {
            delay = Random.Range(wave.minSpawnDelay, wave.maxSpawnDelay);
            yield return new WaitForSeconds(delay);
            
            if(wave.useSpecifiedSpawner) {
                spawnerDirection = wave.spawnFrom;
            } else {
                spawnerDirection = (SpawnerEnum)Random.Range(0, 3);
            }

            enemy = wave.enemyOptions[Random.Range(0, wave.enemyOptions.Length)];
            spawnerController.Spawn(spawnerDirection, enemy);
            spawned++;
        }

        print("Wave completely spawned");
        if(wave.maxWaveTime >= 0f) {
            StartCoroutine(SpawnAfterMaxWaveTime(wave.maxWaveTime));
        }

    }
    

    /** I see a potential issue with this
    * 1 - Wave A spawns and has a max wave time of say 3 seconds
    * 2 - You kill wave A, which spawns wave B
    * 3 - While wave B is alive, this timer finishes, causing wave C to spawn due to Wave A timer
    * 
    * I need a way to turn off this if all enemies from this wave&before have been killed
    */
    IEnumerator SpawnAfterMaxWaveTime(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        if(numberOfEnemiesAlive > 0 && currentWaveIndex < waveConfig.Count-1) {
            MoveToNextWave();
        }
    }

    public void EnemyKilled(int killScore) {
        numberOfEnemiesAlive--;
        if (numberOfEnemiesAlive == 0) {
            if (currentWaveIndex >= waveConfig.Count - 1) {
                FinishLevel(day);
            }
            else {
                foreach (Transform bullet in playerBulletContainer) {
                    Destroy(bullet.gameObject);
                }
                MoveToNextWave();
            }
        }
    }

    private void MoveToNextWave() {
        currentWaveIndex += 1;
        float pauseDuration = currentWave.pauseBeforeNextWave;
        currentWave = waveConfig[currentWaveIndex];
        StartCoroutine(WaitBetweenWaves(pauseDuration));
    }

    private void FinishLevel(int day) {
        player.SetInActiveLevel(false);
        inGameUI.SetInActiveLevel(false);
        if (OnLevelComplete != null) {
            OnLevelComplete.Invoke(day);
        }
    }
    


}
