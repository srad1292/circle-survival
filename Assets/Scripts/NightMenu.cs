using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightMenu : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToHide;
    [SerializeField] GameObject shopUI;
    [SerializeField] TextMeshProUGUI killScoreDisplay;

    int killScore;

    private void OnEnable() {
        foreach(GameObject obj in objectsToHide) {
            if(obj != null)
                obj.SetActive(false);
        }

        killScore = GameManager.killScore;
        killScoreDisplay.SetText(killScore.ToString());
    }

    private void OnDisable() {
        foreach (GameObject obj in objectsToHide) {
            if(obj != null)
                obj.SetActive(true);
        }
    }

    public void HandleItemBought(int price) {
        killScore -= price;
        killScoreDisplay.SetText(killScore.ToString());
    }
}
