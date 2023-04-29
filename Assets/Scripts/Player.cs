using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 400f;
    [SerializeField] Gun playerGun;

    private Vector2 movementInput = Vector2.zero;
    private Rigidbody2D myRigidbody2D;

    void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        
    }

    void FixedUpdate() {
        MovePlayer();
        FaceMouse();
    }

    void MovePlayer() {
        myRigidbody2D.velocity = movementInput * playerSpeed * Time.fixedDeltaTime;

        float distance = Vector3.Distance(transform.position, Vector3.zero);
        float radius = 8.0f;

        if (distance > radius) {
            Vector3 playerToCenter = transform.position - Vector3.zero;
            Vector3 maxLocation = playerToCenter * radius / distance;
            transform.position = Vector3.zero + maxLocation;
        }

    }

    private void FaceMouse() {
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 relativePos = new Vector3(mousePosition.x, mousePosition.y, 0) - targetPosition;

        var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }

    void OnMove(InputValue value) {
        movementInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value) {
        print("On Fire with value: " + value);
        playerGun.Shoot();
    }
}
