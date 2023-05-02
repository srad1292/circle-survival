using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Wave {
    public int numEnemies { get; private set; }
    public Enemy[] enemyOptions { get; private set; }
    public float minSpawnDelay { get; private set; }
    public float maxSpawnDelay { get; private set; }
    public float pauseBeforeNextWave { get; private set; }
    public float maxWaveTime { get; private set; }


    public Wave(int numEnemies, Enemy[] enemyOptions, float minSpawnDelay, float maxSpawnDelay, float pauseBeforeNextWave) {
        this.numEnemies = numEnemies;
        this.enemyOptions = enemyOptions;
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;
        this.pauseBeforeNextWave = pauseBeforeNextWave;
        maxWaveTime = -1f;
    }

    public Wave(int numEnemies, Enemy[] enemyOptions, float minSpawnDelay, float maxSpawnDelay, float pauseBeforeNextWave, float maxWaveTime) {
        this.numEnemies = numEnemies;
        this.enemyOptions = enemyOptions;
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;
        this.pauseBeforeNextWave = pauseBeforeNextWave;
        this.maxWaveTime = maxWaveTime;
    }
}
