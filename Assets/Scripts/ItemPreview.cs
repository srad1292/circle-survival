using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemPreview : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gunNameDisplay;
    [SerializeField] TextMeshProUGUI gunDescriptionDisplay;
    [SerializeField] Image gunSprite;
    [SerializeField] Image[] damageDisplay;
    [SerializeField] Image[] fireRateDisplay;


    public GunSO gunSO;

    public void SetPreviewItem(GunSO toPreview) {
        gunSO = toPreview;
        gunNameDisplay.SetText(gunSO.gunName);
        gunDescriptionDisplay.SetText(gunSO.description);
        gunSprite.sprite = gunSO.sprite;

        for (int idx = 0; idx < damageDisplay.Length; idx++) {
            if (idx < gunSO.damage) {
                damageDisplay[idx].gameObject.SetActive(true);
            }
            else {
                damageDisplay[idx].gameObject.SetActive(false);
            }
        }

        for (int idx = 0; idx < fireRateDisplay.Length; idx++) {
            if (idx < gunSO.fireRate) {
                fireRateDisplay[idx].gameObject.SetActive(true);
            }
            else {
                fireRateDisplay[idx].gameObject.SetActive(false);
            }
        }
    }
}
