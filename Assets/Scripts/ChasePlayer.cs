using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] float minSpeed = 250f;
    [SerializeField] float maxSpeed = 500f;
    [SerializeField] Player player;

    private Rigidbody2D myRigidBody;
    private Enemy enemy;

    private float speed;

    private void Start() {
        speed = Random.Range(minSpeed, maxSpeed);
        myRigidBody = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate() {
        if(player == null) {
            player = enemy.player;
        } else {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            myRigidBody.velocity = direction * speed * Time.fixedDeltaTime;
        }
        
    }


}
