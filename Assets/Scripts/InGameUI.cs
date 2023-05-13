using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killScoreText;
    [SerializeField] InventoryItem[] inventoryItems;
    [SerializeField] WeaponMasterData weaponMasterData;

    
    private bool inActiveLevel = false;
    private int currentlySelectedIndex;
    private int killScore = 0;

    private void Start() {
        killScoreText.SetText(killScore.ToString());
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

    public void HandleEnemyKilled(int enemyKillScore) {
        killScore += enemyKillScore;
        killScoreText.SetText(killScore.ToString());
    }

}
