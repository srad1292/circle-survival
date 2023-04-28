using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] Transform postTransform;

    private LineRenderer myLineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myLineRenderer.positionCount = 2;
        myLineRenderer.SetPosition(0, playerTransform.position);
        myLineRenderer.SetPosition(1, postTransform.position);
    }
}
