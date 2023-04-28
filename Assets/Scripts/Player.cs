using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 400f;

    private Vector2 movementInput = Vector2.zero;
    private Rigidbody2D myRigidbody2D;

    void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        MovePlayer();
    }

    void OnMove(InputValue value) {
        movementInput = value.Get<Vector2>();
    }

    void MovePlayer() {
        myRigidbody2D.velocity = movementInput * playerSpeed * Time.fixedDeltaTime;
        
        float distance = Vector3.Distance(transform.position, Vector3.zero);
        float radius = 8.0f;
        
        if(distance > radius) {
            print("Distance: " + distance);
            Vector3 playerToCenter = transform.position - Vector3.zero;
            print("Player to Center: " + playerToCenter);
            Vector3 maxLocation = playerToCenter * radius / distance;
            print("Max location: " + maxLocation);
            transform.position = Vector3.zero + maxLocation;
        }
    }
}
