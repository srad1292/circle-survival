using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public GunSO gunSO;
    [SerializeField] Image itemImage;
    [SerializeField] Button purchaseButton;
    [SerializeField] TextMeshProUGUI purchaseButtonText;
    [SerializeField] GameManager gameManager;
    [SerializeField] WeaponMasterData weaponMasterData;
    [SerializeField] NightMenu nightMenu;
    [SerializeField] ShopUI shopUI;

    private void OnEnable() {
        itemImage.sprite = gunSO.sprite;
        purchaseButtonText.SetText(gunSO.cost + " KS");
       
    }

    public void SetPurchaseable(bool canPurchase) {
        purchaseButton.interactable = canPurchase;
    }

    public void BuyItem() {
        SetPurchaseable(false);
        weaponMasterData.GunPurchased(gunSO);
        gameManager.HandleItemBought(gunSO);
        nightMenu.HandleItemBought(gunSO.cost);
        shopUI.DeterminePurchaseableItems();
    }


}
