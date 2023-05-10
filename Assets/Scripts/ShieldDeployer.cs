using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDeployer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minTravelDistance;
    [SerializeField] float maxTravelDistance;
    [SerializeField] GameObject shieldGenerator;

    private Rigidbody2D myRigidBody;
    private Enemy enemy;
    private float travelDistance;
    private float distanceTravelled;
    private Vector3 lastPosition;
    private bool deployedShields;
    private GameObject shieldGeneratorInstance;

    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        travelDistance = Random.Range(minTravelDistance, maxTravelDistance);
        distanceTravelled = 0f;
        lastPosition = transform.position;
        deployedShields = false;
    }

    private void OnDestroy() {
        if(shieldGeneratorInstance != null) {
            Destroy(shieldGeneratorInstance);
        }
    }

    private void FixedUpdate() {
        bool onScreen = transform.position.y >= -14 && transform.position.y <= 14 && transform.position.x >= -26 && transform.position.x <= 26;
        if(distanceTravelled < travelDistance || !onScreen) {
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
        Vector3 scale = CalculateScale();
        Vector3 position = CalculatePosition();
        shieldGeneratorInstance = Instantiate(shieldGenerator, position, Quaternion.identity);
        shieldGeneratorInstance.transform.localScale = scale;
        
    }

    private Vector3 CalculateScale() {
        // Current setup had these both print 1920/1080
        //print("Pixel Width: " + Camera.main.pixelWidth + " Pixel Height: " + Camera.main.pixelHeight);
        //print("Scaled Pixel Width: " + Camera.main.scaledPixelWidth + " Scaled Pixel Height: " + Camera.main.scaledPixelHeight);
        if (enemy.spawnedFrom == SpawnerEnum.Top || enemy.spawnedFrom == SpawnerEnum.Bottom) {
            return new Vector3(53f, 1f, 1f);
        }
        else {
            return new Vector3(1f, 30f, 1f);
        }
    }

    private Vector2 CalculatePosition() {
        if(enemy.spawnedFrom == SpawnerEnum.Top || enemy.spawnedFrom == SpawnerEnum.Bottom) {
            return new Vector2(0f, transform.position.y);
        } else {
            return new Vector2(transform.position.x, 0f);
        }
    }
}
