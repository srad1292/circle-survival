using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    public GunSO gunSO;
    [SerializeField] Image backgroundPanel;
    [SerializeField] Image itemImage;
    [SerializeField] Button purchaseButton;
    [SerializeField] TextMeshProUGUI purchaseButtonText;
    [SerializeField] GameManager gameManager;
    [SerializeField] WeaponMasterData weaponMasterData;
    [SerializeField] NightMenu nightMenu;
    [SerializeField] ShopUI shopUI;

    private Color hoverColor;
    private Color normalColor;

    private void Start() {
        hoverColor = new Color(1f, 0.9137255f, 0.627451f, 0.6313726f);
        normalColor = new Color(0.4622642f, 0.4470007f, 0.4470007f, 0.3921569f);
        backgroundPanel.color = normalColor;
    }

    private void OnEnable() {
        backgroundPanel.color = normalColor;
        itemImage.sprite = gunSO.sprite;
        purchaseButtonText.SetText(gunSO.cost + " KS");
    }

    private void OnDisable() {
        backgroundPanel.color = normalColor;
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

    public void OnPointerEnter(PointerEventData eventData) {
        print("I am hovering over: " + gunSO.gunName);
        backgroundPanel.color = hoverColor;
        shopUI.TurnOnPreview(gunSO);
    }

    public void OnPointerExit(PointerEventData eventData) {
        print("I am no longer hovering over: " + gunSO.gunName);
        backgroundPanel.color = normalColor;
        shopUI.TurnOffPreview();
    }
}
