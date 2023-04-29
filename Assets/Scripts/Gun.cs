using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet ammoType;


    public void Shoot() {
        Vector3 spawnPoint = transform.position + (1.05f * transform.up);
        print("Player UP: " + transform.parent.transform.up);
        print("Gun UP: " + transform.parent.transform.up);
        print("Gun POS: " + transform.position);
        print("Spawn Point: " + spawnPoint);
        Instantiate(ammoType, spawnPoint, transform.parent.transform.rotation);
    }
}
