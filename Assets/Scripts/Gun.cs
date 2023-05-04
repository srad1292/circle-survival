using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform playerBulletContainer;
    [SerializeField] Bullet ammoType;
    [SerializeField] float fireDelay = 0.4f;

    private bool isFiring = false;
    private float timer = 0f;

    private void Start() {
        timer = fireDelay;
    }

    private void Update() {
        timer += Time.deltaTime;
        if (isFiring) {
            if(timer >= fireDelay) {
                Shoot();
                timer = 0f;
            }
        }
    }


    public void Shoot() {
        Vector3 spawnPoint = transform.position + (1.05f * transform.up);
        Bullet bullet = Instantiate(ammoType, spawnPoint, transform.parent.transform.rotation);
        bullet.transform.parent = playerBulletContainer;

    }

    public void SetIsFiring(bool isFiring) {
        this.isFiring = isFiring;
    }
}
