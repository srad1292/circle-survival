using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet ammoType;
    [SerializeField] float fireDelay = 0.4f;

    private bool isFiring = false;
    private float timer = 0f;

    private void Update() {
        if(isFiring) {
            timer += Time.deltaTime;
            if(timer >= fireDelay) {
                Shoot();
                timer = 0f;
            }
        } else if(timer != 0f) {
            timer = 0f;
        }
    }


    public void Shoot() {
        Vector3 spawnPoint = transform.position + (1.05f * transform.up);
        Instantiate(ammoType, spawnPoint, transform.parent.transform.rotation);
    }

    public void SetIsFiring(bool isFiring) {
        this.isFiring = isFiring;
        if(isFiring) {
            Shoot();
        }
    }
}
