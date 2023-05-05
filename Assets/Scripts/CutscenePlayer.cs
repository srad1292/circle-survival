using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour
{
    [SerializeField] GameObject captor;
    [SerializeField] GameObject player;


    private void Start() {
        StartCoroutine(ShowSpeechBubble());    
    }

    IEnumerator ShowSpeechBubble() {
        SpeechBubble bubble = SpeechBubble.Create(captor.transform, new Vector3(1.5f, 1.5f, 0f), "Ah.  You're awake.");
        yield return new WaitForSeconds(1.5f);
        bubble.Setup("I have been waiting.");
        yield return new WaitForSeconds(1.5f);
        Destroy(bubble.gameObject);
    }


}
