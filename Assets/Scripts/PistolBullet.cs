using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public int damage = 10;
    [SerializeField] float moveSpeed = 350f;


    Rigidbody2D myRigidBody;

    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().HitByBullet(damage);
            Destroy(gameObject);
        }
    }
}
