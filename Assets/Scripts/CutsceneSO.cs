using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cutscene", menuName = "Create Cutscene", order = 1)]
public class CutsceneSO : ScriptableObject
{
    public int dayToPlay;
    public CutsceneSegment[] segments;
}
