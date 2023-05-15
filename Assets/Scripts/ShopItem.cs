using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] GunSO gunSO;
    [SerializeField] Image itemImage;
    [SerializeField] Button purchaseButton;
    [SerializeField] TextMeshProUGUI purchaseButtonText;
    [SerializeField] GameManager gameManager;
    [SerializeField] WeaponMasterData weaponMasterData;

    private void OnEnable() {
        itemImage.sprite = gunSO.sprite;
        purchaseButtonText.SetText(gunSO.cost + " KS");
        DetermineIfCanPurchase();
    }

    private void DetermineIfCanPurchase() {
        if(weaponMasterData.GetOwnedGuns().Contains(gunSO) || gameManager.killScore < gunSO.cost) {
            purchaseButton.enabled = false;
        } else {
            purchaseButton.enabled = true;
        }
    }

    public void BuyItem() {
        purchaseButton.enabled = false;
        weaponMasterData.GunPurchased(gunSO);
        gameManager.HandleItemBought(gunSO);
    }

   
}
