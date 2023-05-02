using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }

    void Update()
    {
        
    }
}
