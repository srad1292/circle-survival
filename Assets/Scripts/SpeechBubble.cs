using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpeechBubble : MonoBehaviour
{

    public static SpeechBubble Create(Transform parent, Vector3 localPosition, string text) {
        Transform bubbleTransform = Instantiate(PrefabInjector.Instance.piSpeechBubble, parent);
        bubbleTransform.localPosition = localPosition;

        SpeechBubble bubble = bubbleTransform.GetComponent<SpeechBubble>();
        bubble.Setup(text);
        return bubble;
        
    }

    private SpriteRenderer bgSprite;
    private TextMeshPro textMeshPro;

    private void Awake() {
        bgSprite = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public void Setup(string text) {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(4f, 2.9f);
        bgSprite.size = textSize + padding;
        Vector3 offset = new Vector3(-1f, 0f, 0f);
        bgSprite.transform.localPosition = new Vector3(bgSprite.size.x / 2f, 0f) + offset;
    }
}
