using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Wave {
    public int numEnemies { get; private set; }
    public Enemy[] enemyOptions { get; private set; }
    public float minSpawnDelay { get; private set; }
    public float maxSpawnDelay { get; private set; }
    // If you kill all enemies, how long to wait before starting next wave
    public float pauseBeforeNextWave { get; private set; }
    // Length of time to wait between when last enemy in wave spawned, and when you start spawning the next wave as well
    // If you do not pass this in, game will wait until all enemies are dead to start next wave
    public float maxWaveTime { get; private set; }

    public SpawnerEnum spawnFrom { get; private set; }
    public bool useSpecifiedSpawner { get; private set; }


    public Wave(int numEnemies, Enemy[] enemyOptions, float minSpawnDelay, float maxSpawnDelay, float pauseBeforeNextWave) {
        this.numEnemies = numEnemies;
        this.enemyOptions = enemyOptions;
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;

        this.pauseBeforeNextWave = pauseBeforeNextWave;
        maxWaveTime = -1f;
        spawnFrom = SpawnerEnum.Top;
        useSpecifiedSpawner = false;

        
    }

    public Wave(int numEnemies, Enemy[] enemyOptions, float minSpawnDelay, float maxSpawnDelay, float pauseBeforeNextWave, float maxWaveTime) {
        this.numEnemies = numEnemies;
        this.enemyOptions = enemyOptions;
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;
        this.pauseBeforeNextWave = pauseBeforeNextWave;
        this.maxWaveTime = maxWaveTime;
        spawnFrom = SpawnerEnum.Top;
        useSpecifiedSpawner = false;
    }

    public Wave(int numEnemies, Enemy[] enemyOptions, float minSpawnDelay, float maxSpawnDelay, float pauseBeforeNextWave, SpawnerEnum spawnFrom) {
        this.numEnemies = numEnemies;
        this.enemyOptions = enemyOptions;
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;

        this.pauseBeforeNextWave = pauseBeforeNextWave;
        maxWaveTime = -1f;
        this.spawnFrom = spawnFrom;
        useSpecifiedSpawner = true;


    }

    public Wave(int numEnemies, Enemy[] enemyOptions, float minSpawnDelay, float maxSpawnDelay, float pauseBeforeNextWave, float maxWaveTime, SpawnerEnum spawnFrom) {
        this.numEnemies = numEnemies;
        this.enemyOptions = enemyOptions;
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;
        this.pauseBeforeNextWave = pauseBeforeNextWave;
        this.maxWaveTime = maxWaveTime;
        this.spawnFrom = spawnFrom;
        useSpecifiedSpawner = true;
    }
}
