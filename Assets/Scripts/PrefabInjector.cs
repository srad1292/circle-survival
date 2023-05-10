using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInjector : MonoBehaviour
{
    public static PrefabInjector Instance;

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }


    public Transform piSpeechBubble;
    public GameObject piShield;
}
