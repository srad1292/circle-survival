using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMenu : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToHide;

    private void OnEnable() {
        foreach(GameObject obj in objectsToHide) {
            obj.SetActive(false);
        }
    }

    private void OnDisable() {
        foreach (GameObject obj in objectsToHide) {
            obj.SetActive(true);
        }
    }
}
