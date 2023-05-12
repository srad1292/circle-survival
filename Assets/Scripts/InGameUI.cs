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

    // Switched to new input system so I need to add these keys to input and move this to player input script
    private void Update() {
        print("In game UI In Active Level: " + inActiveLevel);
        if (inActiveLevel) {
            
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                weaponMasterData.SelectWeapon(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                print("selected item 2");
                weaponMasterData.SelectWeapon(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                weaponMasterData.SelectWeapon(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                weaponMasterData.SelectWeapon(3);
            }
        }
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
