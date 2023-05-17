using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] ShopItem[] inventory;
    [SerializeField] WeaponMasterData weaponMasterData;

    private void OnEnable() {
        print("Shop UI owned count: " + weaponMasterData.GetOwnedGuns().Count);
        DeterminePurchaseableItems();
    }

    public void DeterminePurchaseableItems() {
        List<GunSO> owned = weaponMasterData.GetOwnedGuns();
        for (int index = 0; index < inventory.Length; index++) {
            bool ownsGun = false;

            foreach (GunSO gunSO in owned) {
                print("Owned Gun Name: " + gunSO.gunName);
                if (gunSO.gunName == inventory[index].gunSO.gunName) {
                    ownsGun = true;
                }
            }
            print(inventory[index].gunSO.gunName + " -- Already owned? " + ownsGun + " --- gmKS = " + GameManager.killScore + "  cost = " + inventory[index].gunSO.cost);


            if (ownsGun || GameManager.killScore < inventory[index].gunSO.cost) {
                inventory[index].SetPurchaseable(false);
            }
            else {
                inventory[index].SetPurchaseable(true);
            }
        }
        
    }

}
