using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercerBullet : MonoBehaviour
{
    public int damage = 20;
    [SerializeField] float moveSpeed = 480f;


    Rigidbody2D myRigidBody;
    private int numEnemiesHit;

    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        numEnemiesHit = 0;
    }

    private void FixedUpdate() {
        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().HitByBullet(damage);
            numEnemiesHit++;
            if (numEnemiesHit >= 3) {
                Destroy(gameObject);
            }
        }
    }
}
