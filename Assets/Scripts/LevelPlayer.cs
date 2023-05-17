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
    int killedDuringWave = 0;
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
        killedDuringWave = 0;
        currentWaveIndex = 0;
        currentWave = waveConfig[0];
        StartCoroutine(WaitBetweenWaves(0.75f));
    }

    public void EnemyKilled(int killScore) {
        killedDuringWave++;
        if(killedDuringWave >= currentWave.numEnemies) {
            print("Killed during wave: " + killedDuringWave);
            if (currentWaveIndex >= waveConfig.Count-1) {
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
        print("I completed a wave!");
        killedDuringWave = 0;
        currentWaveIndex += 1;
        float pauseDuration = currentWave.pauseBeforeNextWave;
        currentWave = waveConfig[currentWaveIndex];
        StartCoroutine(WaitBetweenWaves(pauseDuration));
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
        print("I am in spawn wave.  Will spawn " + wave.numEnemies + " enemies");
        while (spawned < wave.numEnemies) {
            delay = Random.Range(wave.minSpawnDelay, wave.maxSpawnDelay);
            yield return new WaitForSeconds(delay);
            spawnerDirection = (SpawnerEnum)Random.Range(0, 3);
            enemy = wave.enemyOptions[Random.Range(0, wave.enemyOptions.Length)];
            spawnerController.Spawn(spawnerDirection, enemy);
            spawned++;
        }
    }

    private void FinishLevel(int day) {
        player.SetInActiveLevel(false);
        inGameUI.SetInActiveLevel(false);
        if (OnLevelComplete != null) {
            OnLevelComplete.Invoke(day);
        }
    }
    


}
