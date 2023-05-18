using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopUI : MonoBehaviour
{
    [SerializeField] ShopItem[] inventory;
    [SerializeField] WeaponMasterData weaponMasterData;
    [SerializeField] ItemPreview itemPreview;
    [SerializeField] LayerMask shopItemLayer;

    GunSO previewing;

    private void OnEnable() {
        itemPreview.gameObject.SetActive(false);
        DeterminePurchaseableItems();
    }

    private void OnDisable() {
        previewing = null;
    }

    public void DeterminePurchaseableItems() {
        List<GunSO> owned = weaponMasterData.GetOwnedGuns();
        for (int index = 0; index < inventory.Length; index++) {
            bool ownsGun = false;

            foreach (GunSO gunSO in owned) {
                if (gunSO.gunName == inventory[index].gunSO.gunName) {
                    ownsGun = true;
                }
            }


            if (ownsGun || GameManager.killScore < inventory[index].gunSO.cost) {
                inventory[index].SetPurchaseable(false);
            }
            else {
                inventory[index].SetPurchaseable(true);
            }
        }
        
    }

    public void TurnOnPreview(GunSO gunSO) {
        previewing = gunSO;
        itemPreview.SetPreviewItem(gunSO);
        itemPreview.gameObject.SetActive(true);
    }

    public void TurnOffPreview() {
        previewing = null;
        StartCoroutine(DelayHidingPreview());
    }

    IEnumerator DelayHidingPreview() {
        yield return new WaitForSeconds(0.15f);
        if(previewing == null) {
            itemPreview.gameObject.SetActive(false);
        }
    }

}
