using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDeployer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minTravelDistance;
    [SerializeField] float maxTravelDistance;
    [SerializeField] GameObject shield;

    private Rigidbody2D myRigidBody;
    private Enemy enemy;
    private float travelDistance;
    private float distanceTravelled;
    private Vector3 lastPosition;
    private bool deployedShields;

    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        travelDistance = Random.Range(minTravelDistance, maxTravelDistance);
        distanceTravelled = 0f;
        lastPosition = transform.position;
        deployedShields = false;
    }

    private void FixedUpdate() {
        if(distanceTravelled < travelDistance) {
            Vector3 direction = (Vector3.zero - transform.position).normalized;
            myRigidBody.velocity = direction * speed * Time.fixedDeltaTime;
            distanceTravelled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;
        } else {
            myRigidBody.velocity = Vector3.zero;
            if(!deployedShields) {
                DeployShields();
                deployedShields = true;
            }
        }
    }

    private void DeployShields() {
        print("Will deploy shields");
        Vector3 scale = CalculateScale();
        Vector3 offset = CalculateOffset();

        Vector3 position = transform.position + offset;
        GameObject shieldInstance = Instantiate(shield, position, Quaternion.identity);
        shieldInstance.transform.localScale = scale;
        
    }

    private Vector3 CalculateScale() {
        if (enemy.spawnedFrom == SpawnerEnum.Top || enemy.spawnedFrom == SpawnerEnum.Bottom) {
            return new Vector3(Camera.main.pixelWidth, 1f, 1f);
        }
        else {
            return new Vector3(1f, Camera.main.pixelHeight, 1f);
        }
    }

    private Vector2 CalculateOffset() {
        if(enemy.spawnedFrom == SpawnerEnum.Top || enemy.spawnedFrom == SpawnerEnum.Bottom) {
            int signer = transform.position.x < Camera.main.pixelWidth / 2 ? 1 : -1;
            return new Vector2(Mathf.Abs(transform.position.x) - (Camera.main.pixelWidth/2), 0f) * signer;
        } else {
            int signer = transform.position.y < Camera.main.pixelHeight / 2 ? 1 : -1;
            return new Vector2(0f, Mathf.Abs(transform.position.y) - (Camera.main.pixelHeight / 2)) * signer;
        }
    }
}
