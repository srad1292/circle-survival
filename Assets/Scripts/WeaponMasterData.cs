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
        List<GunSO> copyOf = new List<GunSO>();
        copyOf.AddRange(ownedGuns);
        return copyOf;
    }

    public void GunPurchased(GunSO gunSO) {
        ownedGuns.Add(gunSO);
    }



}
