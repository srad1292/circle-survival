using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] InventoryItem[] inventoryItems;
    [SerializeField] WeaponMasterData weaponMasterData;
    
    private bool inActiveLevel = false;
    private int currentlySelectedIndex;

    private void Start() {
        SetIventorySprites();
        currentlySelectedIndex = 0;
        inventoryItems[0].SelectItem();
        weaponMasterData.onGunSelected += HandleWeaponSelected;
    }

    private void SetIventorySprites() {
        List<GunSO> owned = weaponMasterData.GetOwnedGuns();
        for (int idx = 0; idx < inventoryItems.Length; idx++) {
            if (idx < owned.Count) {
                inventoryItems[idx].SetWeaponSprite(owned[idx].sprite);
            }
        }
    }

    private void HandleWeaponSelected(GunSO gunSO) {
        int selectedIndex = weaponMasterData.selectedIndex;
        inventoryItems[currentlySelectedIndex].DeselectItem();
        inventoryItems[selectedIndex].SelectItem();
        currentlySelectedIndex = selectedIndex;
    }

    public void SetInActiveLevel(bool inActiveLevel) {
        print("Setting in game ui in active level to " + inActiveLevel);
        this.inActiveLevel = inActiveLevel;
    }

}
