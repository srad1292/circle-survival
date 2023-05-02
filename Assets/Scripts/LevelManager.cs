using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager: MonoBehaviour
{

    [SerializeField] Enemy zombie;

    private List<Wave> GetDayZero() {
        List<Wave> waves = new List<Wave>();
        waves.AddRange(new Wave[]{
            new Wave(20, new Enemy[] { zombie }, 0.2f, 0.8f, 1.2f),
            new Wave(10, new Enemy[] { zombie }, 0.2f, 0.8f, 1.2f),
        });

        return waves;
    } 


    public List<Wave> GetLevelByDay(int day) {
        if(day == 0) { return GetDayZero(); }
        
        return new List<Wave>();
    }
    
}
