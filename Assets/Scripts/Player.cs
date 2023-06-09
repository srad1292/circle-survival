using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 400f;
    [SerializeField] Gun playerGun;
    [SerializeField] WeaponMasterData weaponMasterData;
    
    private Vector2 movementInput = Vector2.zero;
    private Rigidbody2D myRigidbody2D;

    private bool inActiveLevel = false;
    private List<GunSO> ownedGuns;

    void Start() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        weaponMasterData.onGunSelected += HandleWeaponSelected;
        ownedGuns = weaponMasterData.GetOwnedGuns();
        playerGun.ChangeGunData(ownedGuns[0]);
    }

    private void OnDisable() {
        movementInput = Vector2.zero;
    }

    void FixedUpdate() {
        if(inActiveLevel) {
            MovePlayer();
            FaceMouse();
        } 
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
        playerGun.SetIsFiring(value.isPressed && inActiveLevel);
    }

    void OnHoldFire(InputValue value) {
        playerGun.SetIsFiring(value.isPressed && inActiveLevel);
    }

    void HandleWeaponSelected(GunSO gunSO) {
        playerGun.ChangeGunData(gunSO);
    }

    public void SetInActiveLevel(bool inActiveLevel) {
        this.inActiveLevel = inActiveLevel;
        if(inActiveLevel == false) {
            playerGun.SetIsFiring(false);
            myRigidbody2D.velocity = Vector2.zero;
            myRigidbody2D.SetRotation(Quaternion.identity);
        }
    }

    void OnPause(InputValue value) {
        if(inActiveLevel) {
            PauseMenu.Instance.TogglePauseState();
        }
    }

    void OnSelectWeapon1(InputValue value) {
        if(inActiveLevel)
            weaponMasterData.SelectWeapon(0);
    }
    void OnSelectWeapon2(InputValue value) {
        if(inActiveLevel)
            weaponMasterData.SelectWeapon(1);
    }
    void OnSelectWeapon3(InputValue value) {
        if(inActiveLevel)
            weaponMasterData.SelectWeapon(2);
    }
    void OnSelectWeapon4(InputValue value) {
        if(inActiveLevel)
            weaponMasterData.SelectWeapon(3);
    }


}
