using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform playerBulletContainer;
    [SerializeField] float fireDelay = 0.4f;
    [SerializeField] GunSO gunData;

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
        if(gunData == null) { return; }
        Vector3 spawnPoint = transform.position + (1.05f * transform.up);
        Bullet bullet = Instantiate(gunData.bullet, spawnPoint, transform.parent.transform.rotation);
        bullet.transform.parent = playerBulletContainer;
        StatisticsManager.Instance.HandleBulletFired();

    }

    public void SetIsFiring(bool isFiring) {
        this.isFiring = isFiring;
    }

    public void ChangeGunData(GunSO gunSO) {
        gunData = gunSO;
        fireDelay = 0.8f / (1.2f * gunSO.fireRate);
        timer = 0f;
    }
}
