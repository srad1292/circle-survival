using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Action<int> OnEnemyKilled;

    [SerializeField] int health;
    [SerializeField] int killScore;
    [SerializeField] string enemyName;
    public Player player;
    public SpawnerEnum spawnedFrom;


    private int shieldHealth = 0;
    private GameObject shield;

    public void SetPlayer(Player player) {
        this.player = player;
    }

    public void SetSpawnedFrom(SpawnerEnum spawner) {
        this.spawnedFrom = spawner;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "ShieldGenerator") {
            if(shield == null) {
                shield = Shield.Create(transform);
            }
            shieldHealth = 20;
        }

    }

    public void HitByBullet(int damage) {
        TakeDamage(damage);
    }

    private void TakeDamage(int damage) {
        // I added this line thinking I will have damage carry over if shield is destroyed, but now I'm thinking not
        //int shieldBeforeDamage = shieldHealth;

        if (shieldHealth > 0) {
            shieldHealth -= damage;
            if(shieldHealth <= 0) {
                if(shield != null) {
                    Destroy(shield);
                }
                shield = null;
            }
        } else {
            health -= damage;
            if (health <= 0) {
                StatisticsManager.Instance.HandleEnemyKilled(enemyName, killScore);
                if (OnEnemyKilled != null) {
                    OnEnemyKilled.Invoke(killScore);
                }
                Destroy(gameObject);
            }
        }

        
    }


}
