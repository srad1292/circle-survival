using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Action<int> OnEnemyKilled;

    [SerializeField] int health;
    [SerializeField] int killScore;
    public Player player;

    public void SetPlayer(Player player) {
        this.player = player;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bullet") {
            TakeDamage(other);
            Destroy(other.gameObject);
        }

    }

    private void TakeDamage(Collider2D other) {
        health -= other.gameObject.GetComponent<Bullet>().damage;
        if (health <= 0) {
            if(OnEnemyKilled != null) {
                OnEnemyKilled.Invoke(killScore);
            }
            Destroy(gameObject);
        }
    }


}
