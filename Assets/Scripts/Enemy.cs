using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health;
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
            Destroy(gameObject);
        }
    }


}
