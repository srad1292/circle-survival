using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    [SerializeField] float moveSpeed = 100f;


    Rigidbody2D myRigidBody;
    private bool hasCountedAsHit = false;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        myRigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Shredders") {
            Destroy(gameObject);
        } else if(other.gameObject.tag == "Enemy" && !hasCountedAsHit) {
            hasCountedAsHit = true;
            StatisticsManager.Instance.HandleBulletHit();
        }
    }
}
