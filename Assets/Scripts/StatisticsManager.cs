using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{

    public static StatisticsManager Instance;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;

            Instance.enemiesKilled = 0;
            Instance.enemyKilledByType = new Dictionary<string, int>();
            Instance.bulletsFired = 0;
            Instance.bulletsHit = 0;
            Instance.totalKillScore = 0;
        }
    }

    public int enemiesKilled { get; private set; }
    public Dictionary<string, int> enemyKilledByType { get; private set; }
    public int bulletsFired { get; private set; }
    public int bulletsHit { get; private set; }
    public int totalKillScore { get; private set; }

    public void HandleEnemyKilled(string name, int killScore) {
        if(Instance.enemyKilledByType.ContainsKey(name)) {
            Instance.enemyKilledByType[name] += 1;
        } else {
            Instance.enemyKilledByType.Add(name, 1);
        }

        Instance.enemiesKilled++;
        Instance.totalKillScore += killScore;
    }

    public void HandleBulletFired() {
        Instance.bulletsFired++;
    }

    public void HandleBulletHit() {
        Instance.bulletsHit++;
    }

    public float GetAccuracy() {
        return Instance.bulletsFired == 0 ? 0f : Instance.bulletsHit / (Instance.bulletsFired * 1f) * 100f;
    }

   

}
