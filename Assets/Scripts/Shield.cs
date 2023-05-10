using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public static GameObject Create(Transform parent) {
        GameObject shield = Instantiate(PrefabInjector.Instance.piShield, parent.position, Quaternion.identity);
        shield.transform.parent = parent;
        shield.transform.localScale = parent.localScale + new Vector3(0.8f, 0.8f, 0f);
        return shield;
    }
}
