using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] Image weaponSprite;

    private Color unselectedColor;
    private Color selectedColor;

    private void Start() {
        unselectedColor = new Color(1f, 1f, 1f, 0.1647059f);
        selectedColor = new Color(0.9921569f, 0.9529412f, 0.4627451f, 0.5450981f);
    }

    public void SetWeaponSprite(Sprite sprite) {
        weaponSprite.enabled = true;
        weaponSprite.sprite = sprite;
    }

    public void SelectItem() {
        panel.color = selectedColor; 
    }

    public void DeselectItem() {
        panel.color = unselectedColor;
    }

}
