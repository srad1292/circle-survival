
[System.Serializable]
public class CutsceneSegment {

    public CutsceneConfig.Action action;
    public CutsceneConfig.Actor actor;
    public CutsceneConfig.CaptorDestination captorDestination;
    public float moveSpeed;
    public string[] dialog;

/*    public CutsceneSegment(CutsceneConfig.Action action) {
        this.action = action;
    }
*/
}
