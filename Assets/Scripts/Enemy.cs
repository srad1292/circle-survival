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
        if(other.gameObject.tag == "Bullet") {
            TakeDamage(other);
            Destroy(other.gameObject);
        } else if(other.gameObject.tag == "ShieldGenerator") {
            if(shield == null) {
                shield = Shield.Create(transform);
            }
            shieldHealth = 20;
        }

    }

    private void TakeDamage(Collider2D other) {
        // I added this line thinking I will have damage carry over if shield is destroyed, but now I'm thinking not
        //int shieldBeforeDamage = shieldHealth;

        int damage = other.gameObject.GetComponent<Bullet>().damage;
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
