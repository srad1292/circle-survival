using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager: MonoBehaviour
{

    [SerializeField] Enemy zombie;
    [SerializeField] Enemy slowMan;
    [SerializeField] Enemy shieldDeployer;

    private List<Wave> GetDayZero() {
        List<Wave> waves = new List<Wave>();
        waves.AddRange(new Wave[]{
            new Wave(8, new Enemy[] { zombie }, 0.4f, 0.92f, 2.2f, 3f, SpawnerEnum.Top),
            new Wave(8, new Enemy[] { zombie }, 0.4f, 0.92f, 2.2f, SpawnerEnum.Right),
            new Wave(8, new Enemy[] { zombie }, 0.4f, 0.92f, 2.2f, 5f, SpawnerEnum.Left),
            new Wave(8, new Enemy[] { zombie }, 0.4f, 0.92f, 2.2f, SpawnerEnum.Bottom),
            new Wave(8, new Enemy[] { zombie }, 0.4f, 0.92f, 2.2f),
            /*new Wave(9, new Enemy[] { zombie, shieldDeployer }, 0.4f, 0.92f, 2.2f),
            new Wave(15, new Enemy[] { zombie }, 0.4f, 0.92f, 2.2f),
            new Wave(8, new Enemy[] { zombie, slowMan }, 0.4f, 0.92f, 2.2f),
            new Wave(15, new Enemy[] { zombie }, 0.35f, 0.86f, 1.2f),*/
        });

        return waves;
    }

    private List<Wave> GetDayOne() {
        List<Wave> waves = new List<Wave>();
        waves.AddRange(new Wave[]{
            new Wave(8, new Enemy[] { zombie, shieldDeployer }, 0.4f, 0.92f, 2.2f),
            /*new Wave(9, new Enemy[] { zombie, shieldDeployer }, 0.4f, 0.92f, 2.2f),
            new Wave(15, new Enemy[] { zombie }, 0.4f, 0.92f, 2.2f),
            new Wave(8, new Enemy[] { zombie, slowMan }, 0.4f, 0.92f, 2.2f),
            new Wave(15, new Enemy[] { zombie }, 0.35f, 0.86f, 1.2f),*/
        });

        return waves;
    }

    private List<Wave> GetDayTwo() {
        List<Wave> waves = new List<Wave>();
        waves.AddRange(new Wave[]{
            new Wave(12, new Enemy[] { zombie }, 0.32f, 0.85f, 2.2f),
            new Wave(5, new Enemy[] { zombie }, 0.22f, 0.8f, 2.2f),
            new Wave(12, new Enemy[] { zombie }, 0.32f, 0.85f, 1.2f),
        });

        return waves;
    }


    public List<Wave> GetLevelByDay(int day) {

        if(day == 0) { return GetDayZero(); }
        else if(day == 1) { return GetDayOne(); }
        else if(day == 2) { return GetDayTwo(); }

        return new List<Wave>();
    }
    
}
