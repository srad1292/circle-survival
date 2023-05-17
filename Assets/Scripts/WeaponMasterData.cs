using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponMasterData : MonoBehaviour
{
    [SerializeField] GunSO[] allGuns;
    [SerializeField] List<GunSO> ownedGuns;

    public Action<GunSO> onGunSelected;
    public int selectedIndex { get; private set; }

    private void Start() {
        selectedIndex = 0;
        print("Number of guns owned: " + ownedGuns.Count);
    }

    private void Update() {
    }

    public void SelectWeapon(int index) {
        if(index < ownedGuns.Count && onGunSelected != null) {
            selectedIndex = index;
            onGunSelected.Invoke(ownedGuns[index]);
        }
    }

    public List<GunSO> GetOwnedGuns() {
        print("Getting copy of owned guns.  Count should be: " + ownedGuns.Count);
        List<GunSO> copyOf = new List<GunSO>();
        copyOf.AddRange(ownedGuns);
        return copyOf;
    }

    public void GunPurchased(GunSO gunSO) {
        print("I am adding " + gunSO.gunName + " to owned guns");
        ownedGuns.Add(gunSO);
    }



}
